using System;
using System.Net;

namespace Script.Messages.CsMessages.GamePlay
{
    [Serializable]
    public class CsUserObtainFruit : CsMessage
    {
        public string fruitId;

        public CsUserObtainFruit( string fruitId )
        {
            this.fruitId = fruitId;
        }

    }
}