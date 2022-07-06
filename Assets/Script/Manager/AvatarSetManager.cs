using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Script.Character
{
    public class AvatarSetManager
    {
        private static AvatarSetManager _instance;

        public static AvatarSetManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AvatarSetManager();
                    Init();
                }

                return _instance;
            }
        }
        private List<AvatarSet> _avatarSets = new List<AvatarSet>();

        private static void Init()
        {
            string[] lines = File.ReadAllLines(Path.Combine(Application.streamingAssetsPath, "AvatarConfig.txt"));
            foreach (var line in lines)
            {
                _instance._avatarSets.Add(new AvatarSet(line));
            }
        }

        public bool HasAsset(string assetName)
        {
            foreach (AvatarSet set in _avatarSets)
            {
                if (set.AvatarName.Equals(assetName))
                {
                    return true;
                }
            }

            return false;
        }

        public AvatarSet GetAsset(string assetName)
        {
            foreach (AvatarSet set in _avatarSets)
            {
                if (set.AvatarName.Equals(assetName))
                {
                    return set;
                }
            }

            return null;
        }

        public List<AvatarSet> Get()
        {
            return new List<AvatarSet>(_avatarSets);
        }
    }
}