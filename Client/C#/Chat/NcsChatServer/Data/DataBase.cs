using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LiteDB;

namespace NcsChatServer.Data
{
    public class DataBase
    {
        public static LiteDatabase Database;
        public static LiteCollection<UserData> UserCollection;

        public static void InitDataBase(string filePath = "./Data/user.db")
        {
            if (!Directory.Exists("./Data"))
            {
                Directory.CreateDirectory("./Data");
            }

            Database = new LiteDatabase(filePath);

            Program.ConsoleSystem.WriteLog($"[DataBase] Init Database - {filePath}");
            UserCollection = Database.GetCollection<UserData>("users");
        }
    }
}
