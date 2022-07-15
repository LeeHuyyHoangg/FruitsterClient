using System;
using System.Net;
using Script.Messages.ScMessages;

namespace Script.Messages.CsMessages.GamePlay
{
    [Serializable]
    public class ScUserObtainFruit : ScMessage
    {
        public HttpStatusCode statusCode;
        public override void OnMessage(Session session)
        {
            throw new NotImplementedException();
        }
    }
}