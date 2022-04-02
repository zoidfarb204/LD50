using Enums;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Resources
{
    public class Forrest : IResource
    {
        public string Name => "Forrest";
        public TileBase Tile { get; set; }
        public float Amount { get; set; }
        public ResourceType Type => ResourceType.Wood;
        public Vector3Int TilePosition { get; set; }
        public Vector3 WorldPosition { get; set; }
        public float Gather(float gatherSpeed, float time)
        {
            var harvested = gatherSpeed * time;
            Amount -= harvested;
            return harvested;
        }

        public void AdjustAmount(float extra)
        {
            this.Amount += extra;
        }
    }
}