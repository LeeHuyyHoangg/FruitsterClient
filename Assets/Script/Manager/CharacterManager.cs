using System;
using System.Collections.Generic;

namespace Script.Character
{
    public class CharacterManager
    {
        private static CharacterManager _instance;

        public static CharacterManager Instance => _instance;
        
        private Dictionary<String, CharacterScript> idToCharacter = new Dictionary<String, CharacterScript>();

        public void AddCharacter(string id)
        {
            
        }
        
    }
}