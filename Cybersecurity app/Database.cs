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
    public class Database
    {
        private string stringConnection = "Cyber_App_DB.sqlite3";


        /// <summary>
        /// The constructor will create the database if there is no database
        /// </summary>
        public Database()
        {
            if (!File.Exists(stringConnection))
            {
                SQLiteConnection.CreateFile(stringConnection);
                NonQuery(CreateDbModel());   
            }

        }

        /// <summary>
        /// Create DB connection
        /// </summary>
        /// <returns></returns>
        private SQLiteConnection GetConnection()
        {
            return new SQLiteConnection($"Data source = {stringConnection}");
        }

        /// <summary>
        /// Create database model
        /// </summary>
        /// <returns>Query to create users table</returns>
        private string CreateDbModel()
        {
            string tableUser = "CREATE TABLE IF NOT EXISTS users([ID] INTEGER PRIMARY KEY AUTOINCREMENT, [first_name] TEXT, [last_name] TEXT, [email] TEXT, [password] TEXT)";
            return tableUser;
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
        /// <param name="sqlParameters"></param>
        public void NonQuery(string query, Action<SQLiteParameterCollection> sqlParameters)
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


    }
}
