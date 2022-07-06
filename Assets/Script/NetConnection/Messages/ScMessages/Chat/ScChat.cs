using System;
using System.Net;
using UnityEngine;

namespace Script.Messages.ScMessages
{
    [Serializable]
    public class ScChat : ScMessage
    {
        public string message;
        
        public ScChat(string message)
        {
            this.message = message;
        }

        public override void OnMessage(Session session)
        {
            Debug.Log(message);
        }
    }
}