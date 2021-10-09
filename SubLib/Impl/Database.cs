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
            }
            _connection = new SQLiteConnection($"Data Source={name};Version=3;");

            _connection.Open();

            var command = new SQLiteCommand(SQLRequests.CreateIfNotExists, _connection);
            command.ExecuteNonQuery();
        }

        ~Database()
        {
            _connection.Close();
        }

        public DatabaseStatus Delete(ISubscriber subscriber)
        {
            try
            {
                var command = new SQLiteCommand(SQLRequests.DeleteFrom, _connection);

                command.Parameters.AddWithValue("@TelegramId", subscriber.TelegramId);

                command.ExecuteNonQuery();

                return DatabaseStatus.OK;
            }
            catch (Exception)
            {
                return DatabaseStatus.Fail;
            }
        }

        public DatabaseStatus Insert(ISubscriber subscriber)
        {
            try
            {
                var command = new SQLiteCommand(SQLRequests.InsertInto, _connection);

                command.Parameters.AddWithValue("@TelegramId", subscriber.TelegramId);
                command.Parameters.AddWithValue("@TelegramUsername", subscriber.TelegramUsername);
                command.Parameters.AddWithValue("@SubscriptionStartDate", subscriber.SubscriptionStartDate.Ticks);
                command.Parameters.AddWithValue("@SubscriptionExpirationDate", subscriber.SubscriptionExpirationDate.Ticks);

                command.ExecuteNonQuery();

                return DatabaseStatus.OK;
            }
            catch (Exception)
            {
                return DatabaseStatus.Fail;
            }
        }

        public DatabaseStatus RowCount(out long rowCount)
        {
            try
            {
                var command = new SQLiteCommand(SQLRequests.RowCount, _connection);

                rowCount = (long)command.ExecuteScalar();

                return DatabaseStatus.OK;
            }
            catch (Exception)
            {
                rowCount = 0;
                return DatabaseStatus.Fail;
            }
        }
    }
}
