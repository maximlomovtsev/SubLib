using SubLib.Interfaces;
using SubLib.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.IO;

namespace SubLib.Impl
{
    public class Database : IDatabase
    {
        private SQLiteConnection _connection;
        public Database(string name)
        {
            if(!File.Exists(name))
            {
                SQLiteConnection.CreateFile(name);
                _connection = new SQLiteConnection($"Data Source={name};Version=3;");
            }
        }

        public DatabaseStatus Open()
        {
            try
            {
                _connection.Open();
                return DatabaseStatus.OK;
            }
            catch (Exception)
            {
                return DatabaseStatus.Fail;
            }
        }
        public DatabaseStatus Close()
        {
            try
            {
                _connection.Close();
                return DatabaseStatus.OK;
            }
            catch (Exception)
            {
                return DatabaseStatus.Fail;
            }
        }
    }
}
