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
        public Vector3Int TilePosition { get; set; }
        public Vector3 WorldPosition { get; set; }
        public void Gather(Gatherer gatherer)
        {
            throw new System.NotImplementedException();
        }
    }
}