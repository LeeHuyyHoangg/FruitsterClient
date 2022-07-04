using System;
using System.Net;

namespace Script.Messages.ScMessages
{
    [Serializable]
    public class ScLogin : ScMessage
    {
        public HttpStatusCode statusCode;
        public string uid;
        
        public override void OnMessage(Session session)
        {
            if (statusCode.Equals(HttpStatusCode.OK))
            {
                UserProperties.UserId = uid;
            }
            else
            {
                UserProperties.LoginFailed = true;
            }
        }
    }
}