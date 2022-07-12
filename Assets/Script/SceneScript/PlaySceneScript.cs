using System;
using System.Collections;
using System.Collections.Generic;
using Script.UserInterface;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlaySceneScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> playerGameObjects;

    private Tilemap tilemap;

    private Camera camera;
    // Start is called before the first frame update
    void Awake()
    {
        tilemap = GameObject.Find("Tilemap").GetComponent<Tilemap>();
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        Debug.Log(tilemap);
        Debug.Log(camera);
        tilemap.GetComponent<TilemapCollider2D>().usedByComposite = true;
    }

    private void Start()
    {
        PolygonCollider2D polygonCollider2D = tilemap.GetComponent<PolygonCollider2D>();

        // polygonCollider2D.SetPath(0, tilemap.CellToWorld(new Vector3Int(0,0,0)));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
