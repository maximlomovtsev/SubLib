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
                "TelegramUsername NVARCHAR(50)" +
                ");";

        public static string InsertInto = @"INSERT INTO Users (TelegramId, TelegramUsername) VALUES (@TelegramId, @TelegramUsername)";

        public static string DeleteFrom = @"DELETE FROM Users WHERE TelegramId = @TelegramId";

        public static string RowCount = @"SELECT COUNT(Id) FROM Users";
    }
}
