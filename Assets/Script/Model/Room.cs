using System;

namespace Script.Model
{
    [Serializable]
    public class Room
    {
        
        public string roomID;
        public string roomName;
        public bool hasPass;
        public int numberOfMembers;
        
        public Room(string roomId, string roomName, bool hasPass, int numberOfMembers)
        {
            this.roomID = roomId;
            this.roomName = roomName;
            this.hasPass = hasPass;
            this.numberOfMembers = numberOfMembers;
        }
    }
}