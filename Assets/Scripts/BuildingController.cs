using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Buildings;
using Enums;
using Inventory;
using Resources;
using TMPro;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    private MapController _mapObject;

    
    public TextMeshProUGUI woodText;
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
        var woodSlot = Buildings.FirstOrDefault(x=> x.Type == BuildingType.Hub).Inventory.GetSlot(ResourceType.Wood);
        var woodAmount = (int) Math.Round(woodSlot.Amount);
        woodText.text = "Wood - " + woodAmount;
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
                WorldLocation = worldLocation.Value,
                Inventory = new Inventory.Inventory
                {
                    NumSlots = 10,
                    Slots = new List<ISlot>()
                }
            });
        }

        var forrestLocation = new Vector3Int(3, 7, 0);
        var forrestWorldLocation = _mapObject.PlaceBuilding(BuildingType.Forrest, forrestLocation);
        if (forrestWorldLocation != null)
        {
            var forrest = new Forrest
            {
                TileLocation = forrestLocation,
                WorldLocation = forrestWorldLocation.Value,
                Inventory = new Inventory.Inventory
                {
                    NumSlots = 1,
                    Slots = new List<ISlot>()
                }
            };
            var wood = forrest.Inventory.GetSlot(ResourceType.Wood);
            wood.Amount = 1000;
            Buildings.Add(forrest);
        } 
      
    }
}





