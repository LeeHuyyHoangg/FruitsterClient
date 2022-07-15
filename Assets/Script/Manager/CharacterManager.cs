using System;
using System.Collections.Generic;

namespace Script.Character
{
    public class CharacterManager
    {
        private static CharacterManager _instance;

        public static CharacterManager Instance => _instance;
        
        private Dictionary<String, ObjectScript> idToCharacter = new Dictionary<String, ObjectScript>();

        public void AddCharacter(string id)
        {
            
        }
        
    }
}