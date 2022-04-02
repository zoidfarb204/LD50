using System.Collections;
using System.Collections.Generic;
using Mono.Cecil.Rocks;
using Resources;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapController : MonoBehaviour
{
    public Tilemap map;
    
    public List<IResource> Resources;

    public Tile rock;
    public Tile forrest;

    // Start is called before the first frame update
    void Start()
    {
        Resources = new List<IResource>();
        
        
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                int r = Random.Range(0, 2);
                Vector3Int p = new Vector3Int(x, y, 0);
                Tile tile = rock;

                if (x == 3 && y == 7)
                {
                    tile = forrest;
                    Resources.Add(new Forrest
                    {
                        Amount = 200,
                        Tile = tile,
                        Location = p
                    });
                }
                map.SetTile(p,tile);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

