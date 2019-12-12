using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;

namespace NcsChatServer.Data
{
    public class UserData
    {
        [BsonId]
        public string Id { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }
    }
}
