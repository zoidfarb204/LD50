using Enums;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Resources
{
    public interface IResource
    {
        string Name { get; }
        TileBase Tile { get; set; }
        int Amount { get; set; }
        ResourceType Type { get; }
        Vector3Int TilePosition { get; set; }
        Vector3 WorldPosition { get; set; }
        void Gather(Gatherer gatherer);
    }
}