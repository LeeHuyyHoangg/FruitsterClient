using System;

namespace Script.Model
{
    [Serializable]
    public class User
    {
        public string userID;
        public string userName;
        
        public User(string userId, string userName)
        {
            this.userID = userId;
            this.userName = userName;
        }
    }
}