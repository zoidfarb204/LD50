using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    private MapController _mapObject;

    // Start is called before the first frame update
    public List<IBuilding> Buildings { get; set; }
    void Start()
    {
        Buildings = new List<IBuilding>();
        _mapObject =  GameObject.Find("MapController").GetComponent<MapController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitBuildings()
    {
        var hubLocation = new Vector3Int(4, 2,0);
        var worldLocation = _mapObject.PlaceBuilding(BuildingType.Hub, hubLocation);
        if (worldLocation != null)
        {
            Buildings.Add(new Hub
            {
                TileLocation = hubLocation,
                WorldLocation = worldLocation.Value
            });
        }
    }
}

public class Hub : IBuilding
{
    public BuildingType Type => BuildingType.Hub;
    public Vector3Int TileLocation { get; set; }
    public Vector3 WorldLocation { get; set; }
}

public interface IBuilding
{
    public BuildingType Type { get; }
    public Vector3Int TileLocation { get; set; }
    public Vector3 WorldLocation { get; set; }
}

public enum BuildingType
{
    Hub
}
