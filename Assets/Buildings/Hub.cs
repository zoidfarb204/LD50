using Enums;
using Inventory;
using UnityEngine;

namespace Buildings
{
    public class Hub : IBuilding
    {
        public BuildingType Type => BuildingType.Hub;
        public Vector3Int TileLocation { get; set; }
        public Vector3 WorldLocation { get; set; }
        public IInventory Inventory { get; set; }
    }
}