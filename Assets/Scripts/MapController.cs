using System.Collections;
using System.Collections.Generic;
using Mono.Cecil.Rocks;
using Resources;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapController : MonoBehaviour
{
    public GridLayout grid;
    public Tilemap map;
    public BuildingController _buildingController;
    
    public List<IResource> Resources;
    public Vector3 hubWorldLocation;
    public Tile rock;
    public Tile forrest;
    public Tile hub;

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
                        WorldPosition = grid.CellToWorld(p),
                        TilePosition =  p
                    });
                }
                map.SetTile(p,tile);
            }
        }
        
        _buildingController.InitBuildings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3? PlaceBuilding(BuildingType type, Vector3Int location)
    {
        switch (type)
        {
            case BuildingType.Hub:
                map.SetTile(location,null);
                map.SetTile(location,hub);
                return grid.CellToWorld(location);
            default:
                return null;
        }
    }
}

