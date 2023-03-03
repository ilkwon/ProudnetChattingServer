using Nettention.Proud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattingCommon
{
    public class Marshaler : Nettention.Proud.Marshaler
    {
        public static void Write(Message msg, User user)
        {
            msg.Write(user.HostId);
            msg.Write(user.UserName);
            msg.Write(user.UserId);
        }

        public static User Read(Message msg, out User user)
        {
            msg.Read(out HostID hostId);
            msg.Read(out string userName);
            msg.Read(out int  userId);

            user = new User();
            user.HostId = hostId;
            user.UserName = userName;
            user.UserId = userId;

            return user;
        }
    }
}
