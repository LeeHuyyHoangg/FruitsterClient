using System.Collections.Generic;
using Script.Model;

namespace Script.Messages.ScMessages
{
    public class ScGetRoomList : ScMessage
    {
        public List<Room> roomList;

        public override void OnMessage(Session session)
        {
            RoomScript.Instance.rooms = roomList;
        }
    }
}