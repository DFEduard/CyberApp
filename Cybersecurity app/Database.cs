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

        public Database()
        {
            if (!File.Exists(stringConnection))
            {
                SQLiteConnection.CreateFile(stringConnection);
                NonQuery(CreateDbModel());   
            }

        }

        private SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(stringConnection);
        }


        private string CreateDbModel()
        {
            string tableUser = "CREATE TABLE IF NOT EXISTS users ([ID] INTEGER PRIMARY KEY AUTOINCREMENT, [first_name] TEXT, [last_name] TEXT, [email] TEXT, [password] TEXT)";
            return tableUser;
        }

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
