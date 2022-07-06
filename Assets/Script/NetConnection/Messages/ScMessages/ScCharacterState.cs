using UnityEngine;

namespace Script.Messages.ScMessages
{
    public class ScCharacterState : ScMessage
    {
        public string id;
        public Vector2 location;
        public Vector2 direction;
        public CharacterState state;
        public override void OnMessage(Session session)
        {
            throw new System.NotImplementedException();
        }
    }
}