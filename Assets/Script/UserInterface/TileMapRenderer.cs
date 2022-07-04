using UnityEngine;
using UnityEngine.Tilemaps;

namespace Script.UserInterface
{
    public class TileMapRenderer : MonoBehaviour
    {
        [SerializeField] private Tile land;
        [SerializeField] private Tile border;

        [SerializeField] private Tilemap tilemap;

        [SerializeField] private int tilemapSizeX = 20;
        
        [SerializeField] private int tilemapSizeY = 20;
        
        private void Awake()
        {
            for (int x = 0; x < tilemapSizeX + 2; x++)
            {
                for (int y = 0; y < tilemapSizeY + 2; y++)
                {
                    Vector3Int p = new Vector3Int(x,y,0);
                    if (x == 0 || y == 0 || x == tilemapSizeX + 1 || y == tilemapSizeY + 1)
                    {
                        tilemap.SetTile(p, border);
                    }
                    else
                    {
                        tilemap.SetTile(p, land);
                    }
                }
            }
        }
    }
}