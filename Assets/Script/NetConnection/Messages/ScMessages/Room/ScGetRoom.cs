using System;
using System.Collections.Generic;
using System.Net;
using Script.Model;

namespace Script.Messages.ScMessages
{
    public class ScGetRoom : ScMessage
    {
        public HttpStatusCode statusCode;
        public string roomID;
        public string roomName;
        public List<User> userList;
        public override void OnMessage(Session session)
        {
            if (statusCode == HttpStatusCode.OK)
            {
                UserProperties.UserRoom.RoomName = roomName;
                UserProperties.UserRoom.RoomID = roomID;
                UserProperties.UserRoom.OtherPlayers = userList;
            }
        }
    }
}