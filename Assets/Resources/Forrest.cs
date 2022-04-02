using Enums;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Resources
{
    public class Forrest : IResource
    {
        public string Name => "Forrest";
        public TileBase Tile { get; set; }
        public int Amount { get; set; }
        public ResourceType Type => ResourceType.Wood;
        public Vector3Int Location { get; set; }
    }
}