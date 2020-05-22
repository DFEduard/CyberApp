using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Data;

namespace Cybersecurity_app
{
    /// <summary>
    /// Class: Database
    /// Write by: Florentin Eduard Decu
    /// Description: This class can be used to insert, updated, delete and select data from a database. Database used is SQLite
    /// If there is no database file the constructor will create the database file plus the model of the database
    /// </summary>
    public class Database
    {
        //String connection for database
        private string stringConnection = "Cyber_App_DB.sqlite3";
        // Flag to check if there is any sql injection attack 
        private bool sqlInjectionAttack = false;
        // Array of sql keywords
        private string[] sqlInjectionChecker = { "create", "select", "update", "insert", "drop", "table", "beign", "end", "alter",
                                          "cursor","delete","cast","exec","kill","fetch","sysobject","syscolumns","execute",
                                          "--",";--",";","/*","*/","char","@","vchar","nvarchar","@@", "if not exist", "values(",
                                           "delete from", "set", "create table", "'", "*", "from"};


        /// <summary>
        /// The constructor will create the database if there is no database
        /// </summary>
        public Database()
        {
            //Check if database is created 
            if (!File.Exists(stringConnection))
            {
                //Create database file
                SQLiteConnection.CreateFile(stringConnection);
                //Create database model 
                CreateDbModel();
            }

        }

        /// <summary>
        /// Create DB connection
        /// </summary>
        /// <returns>SQLite connection</returns>
        private SQLiteConnection GetConnection()
        {
            
            return new SQLiteConnection($"Data source = {stringConnection}");
        }

        /// <summary>
        /// Create database model
        /// </summary>
        /// <returns>Query to create users table</returns>
        private void CreateDbModel()
        {
            //Query to create users table 
            string createTableUser = "CREATE TABLE IF NOT EXISTS users" +
                "([ID] INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "[first_name] TEXT, [last_name] TEXT, " +
                "[email] TEXT, [password] TEXT, " +
                "[two_factor_authentication] BOOL)";

            //Query to create unique codes table
            string createTableUniqueCodes = "CREATE TABLE IF NOT EXISTS unique_codes" +
                "([ID] INTEGER PRIMARY KEY AUTOINCREMENT," +
                "[user_id] INTEGER, " +
                "[code] TEXT, " +
                "[time] real, " +
                "FOREIGN KEY (user_id) REFERENCES users(id))";

            //Query database to create the tables 
            NonQuery(createTableUser);
            NonQuery(createTableUniqueCodes);

        }

        /// <summary>
        /// Query reader for database with parameters
        /// </summary>
        /// <param name="query"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public DataTable QueryReader(string query, Action<SQLiteParameterCollection> sqlParameters)
        {
            DataTable restul = new DataTable();
            using (SQLiteConnection myConnection = GetConnection())
            using (SQLiteCommand command = new SQLiteCommand(query,myConnection))
            {
                sqlParameters(command.Parameters);
                myConnection.Open();
                restul.Load(command.ExecuteReader(CommandBehavior.CloseConnection));
            }

            return restul;
        }

        /// <summary>
        /// Query reader for database with no parameters
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable QueryReader(string query)
        {
            DataTable restul = new DataTable();
            using (SQLiteConnection myConnection = GetConnection())
            using (SQLiteCommand command = new SQLiteCommand(query, myConnection))
            {
                myConnection.Open();
                restul.Load(command.ExecuteReader(CommandBehavior.CloseConnection));
            }

            return restul;
        }

        /// <summary>
        /// Non query for database with parameters
        /// </summary>
        /// <param name="query"></param>
        /// <param name="sqliteParameters"></param>
        public void NonQuery(string query, Action<SQLiteParameterCollection> sqliteParameters)
        {
            using (SQLiteConnection myConnection = GetConnection())
            using (SQLiteCommand command = new SQLiteCommand(query, myConnection))
            {
                if (!sqlInjectionAttack)
                {
                    myConnection.Open();
                    sqliteParameters(command.Parameters);
                    command.ExecuteNonQuery();
                    myConnection.Close();
                }

            }
        }
   


        /// <summary>
        /// Non query for database with no parameters
        /// </summary>
        /// <param name="query"></param>
        public void NonQuery(string query)
        {
            using (SQLiteConnection myConnection = GetConnection())
            using (SQLiteCommand command = new SQLiteCommand(query, myConnection))
            {
                myConnection.Open();
                command.ExecuteNonQuery();
                myConnection.Close();
            }
        }

        /// <summary>
        /// Method used to check a text for sql injection
        /// </summary>
        /// <param name="input">Plain text</param>
        /// <returns></returns>
        public bool CheckSqlInjection(string input)
        {
            //Split the user's input into array 
            string[] splitInput = input.Split(' ');
            //Save sql keywords found
            string sqlKeywords = "";
            
            //Loop through all items from the array 
            for (int i = 0; i < splitInput.Length; i++)
            {
                //Check if sql injection checker contain the current text 
                if (sqlInjectionChecker.Contains(splitInput[i].ToLower()))
                {
                    if (i == 0)
                    {
                        //Add first sql keyword found
                        sqlKeywords = splitInput[i];
                    }
                    else if (i > 0) 
                    {
                        //Add the sql keyword found with a space delimiter
                        sqlKeywords += " " + splitInput[i];
                    }
                }
                
            }

            //Check the lenngh of the sql keywords string
            if (sqlKeywords.Length >= 2) // above two or equal (e.g select *, drop table, etc. )
            {
                sqlInjectionAttack = true;
            }
            else
            {
                sqlInjectionAttack = false;
            }
            //Return result 
            return sqlInjectionAttack;
        }
    }
}
