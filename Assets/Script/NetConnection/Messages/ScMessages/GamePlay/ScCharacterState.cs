using System;
using UnityEngine;

namespace Script.Messages.ScMessages
{
    [Serializable]
    public class ScCharacterState : ScMessage
    {
        public string id;
        public float locationX;
        public float locationY;
        public float directionX;
        public float directionY;
        public ObjectState state;
        public override void OnMessage(Session session)
        {
            throw new System.NotImplementedException();
        }
    }
}