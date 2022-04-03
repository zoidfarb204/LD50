using System.Collections;
using System.Collections.Generic;
using Enums;
using Mono.Cecil.Rocks;
using Resources;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapController : MonoBehaviour
{
    public GridLayout grid;
    public Tilemap map;
    public BuildingController _buildingController;
    
    public Tile rock;
    public Tile forrest;
    public Tile hub;

    // Start is called before the first frame update
    void Start()
    {
        
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                int r = Random.Range(0, 2);
                Vector3Int p = new Vector3Int(x, y, 0);
                Tile tile = rock;

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
                break;
            case BuildingType.Forrest:
                map.SetTile(location,null);
                map.SetTile(location, forrest);
                break;
            default:
                return null;
        }
        
        return grid.CellToWorld(location);
    }
}

