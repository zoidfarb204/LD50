using Buildings;
using Enums;
using Inventory;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Resources
{
    public class Forrest : IBuilding
    {
        public BuildingType Type => BuildingType.Forrest;
        public Vector3Int TileLocation { get; set; }
        public Vector3 WorldLocation { get; set; }
        public IInventory Inventory { get; set; }
    }
}