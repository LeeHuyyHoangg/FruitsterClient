using System;
using UnityEngine;

namespace Script.Messages.CsMessages
{
    [Serializable]
    public class CsCharacterState
    {
        public string id;
        public Vector2 location;
        public Vector2 direction;
        public CharacterState state;

        public CsCharacterState(string id, Vector2 location, Vector2 direction, CharacterState state)
        {
            this.id = id;
            this.location = location;
            this.direction = direction;
            this.state = state;
        }
    }
}