using System;
using System.Net;

namespace Script.Messages.CsMessages.GamePlay
{
    [Serializable]
    public class CsUserObtainFruit : CsMessage
    {
        public HttpStatusCode statusCode;

        public CsUserObtainFruit(HttpStatusCode statusCode)
        {
            this.statusCode = statusCode;
        }
    }
}