using Nettention.Proud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattingCommon
{
    public class Vars
    {
        public static System.Guid m_Version = new System.Guid("{ 0x3ae33249, 0xecc6, 0x4980, { 0xbc, 0x5d, 0x7b, 0xa, 0x99, 0x9c, 0x7, 0x39 } }");
        public static int m_serverPort = 33334;

        static Vars() { }
    }

    public class User
    {
        public HostID HostId;
        public string UserName;
        public int UserId { get; set; }

        private static int userId = 0;

        public User(string userName, HostID hostId)
        {
            this.UserId = ++userId;
            this.UserName = userName;
            this.HostId = hostId;
        }

        public User() 
        {
            UserName = "Unknown";
        }
    }
}
