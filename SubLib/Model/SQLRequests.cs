using System;
using System.Collections.Generic;
using System.Text;

namespace SubLib.Model
{
    public class SQLRequests
    {
        public static string CreateIfNotExists = @"CREATE TABLE IF NOT EXISTS Users " +
                "(" +
                "Id INTEGER PRIMARY KEY AUTOINCREMENT," +
                "TelegramId INTEGER," +
                "TelegramUsername NVARCHAR(50)," +
                "SubscriptionStartDate INTEGER," +
                "SubscriptionExpirationDate INTEGER" +
                ");";

        public static string InsertInto = @"INSERT INTO Users (TelegramId, TelegramUsername, SubscriptionStartDate, SubscriptionExpirationDate) " +
            "VALUES (@TelegramId, @TelegramUsername, @SubscriptionStartDate, @SubscriptionExpirationDate)";

        public static string DeleteFrom = @"DELETE FROM Users WHERE TelegramId = @TelegramId";

        public static string RowCount = @"SELECT COUNT(*) FROM Users";

        public static string IsExists = @"SELECT COUNT(*) FROM Users WHERE TelegramId = @TelegramId";
    }
}
