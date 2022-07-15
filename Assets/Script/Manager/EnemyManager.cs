using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Script.Character
{
    public class EnemyManager
    {
        
        private static EnemyManager _instance;

        public static EnemyManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EnemyManager();
                    Init();
                }

                return _instance;
            }
        }
        private readonly List<GameObject> enemies = new List<GameObject>();

        private static void Init()
        {
            string[] lines = File.ReadAllLines(Path.Combine(Application.streamingAssetsPath, "EnemyConfig.txt"));
            foreach (var line in lines)
            {
                
                GameObject enemyPrefab = Resources.Load("Enemies/" + line + "/" + line ) as GameObject;
                _instance.enemies.Add(enemyPrefab);
            }
        }

        public bool HasEnemy(string enemyName)
        {
            foreach (GameObject enemy in enemies)
            {
                if (enemy.name==enemyName)
                {
                    return true;
                }
            }

            return false;
        }

        public GameObject GetEnemy(string enemyName)
        {
            foreach (GameObject enemy in enemies)
            {
                if (enemy.name==enemyName)
                {
                    return enemy;
                }
            }

            return null;
        }

        public List<GameObject> Get()
        {
            return new List<GameObject>(enemies);
        }
    }
}