using Enums;
using Inventory;
using UnityEngine;

namespace Buildings
{
    public interface IBuilding
    {
        public BuildingType Type { get; }
        public Vector3Int TileLocation { get; set; }
        public Vector3 WorldLocation { get; set; }
        public IInventory Inventory { get; set; }
    }
}