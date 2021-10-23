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

        public DatabaseStatus IsExists(ISubscriber subscriber, out bool isExists)
        {
            try
            {
                var command = new SQLiteCommand(SQLRequests.IsExists, _connection);

                command.Parameters.AddWithValue("@TelegramId", subscriber.TelegramId);

                var rowCount = (long)command.ExecuteScalar();
                isExists = (rowCount > 0);

                return DatabaseStatus.OK;
            }
            catch (Exception)
            {
                isExists = false;
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

        public DatabaseStatus Select(long count, out List<ISubscriber> subscribers)
        {
            try
            {
                var command = new SQLiteCommand(SQLRequests.Select, _connection);

                command.Parameters.AddWithValue("@subscribersCount", count);

                var databaseSubscribers = new List<ISubscriber>();
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    var subscriber = new Subscriber();
                    subscriber.TelegramId = Convert.ToInt64(reader[@"TelegramId"]);
                    subscriber.TelegramUsername = Convert.ToString(reader[@"TelegramUsername"]);
                    subscriber.SubscriptionStartDate = new DateTime(Convert.ToInt64(reader[@"SubscriptionStartDate"]));
                    subscriber.SubscriptionExpirationDate = new DateTime(Convert.ToInt64(reader[@"SubscriptionExpirationDate"]));

                    databaseSubscribers.Add(subscriber);
                }
                subscribers = databaseSubscribers;

                return DatabaseStatus.OK;
            }
            catch (Exception)
            {
                subscribers = null;
                return DatabaseStatus.Fail;
            }
        }
    }
}
