using Enums;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Resources
{
    public interface IResource
    {
        string Name { get; }
        TileBase Tile { get; set; }
        float Amount { get; set; }
        ResourceType Type { get; }
        Vector3Int TilePosition { get; set; }
        Vector3 WorldPosition { get; set; }
        float Gather(float gatherSpeed, float time);
        void AdjustAmount(float extra);
    }
}