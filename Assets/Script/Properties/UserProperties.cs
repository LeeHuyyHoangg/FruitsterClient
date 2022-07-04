using System.Collections.Generic;
using System.Net;
using Script.Model;

namespace Script
{
    public class UserProperties
    {
        public static string UserId = null;
        public static bool LoginFailed = false;
        public static HttpStatusCode LoginStatusCode;
        public static bool RegisterFailed = false;
        public static HttpStatusCode RegisterStatusCode;

        public static string UserName;
        public static AvatarSet UserAvatarSet;

        public static Room UserRoom;
        public static List<User> UserRoomPlayers = null;
    }
}