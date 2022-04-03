using System.Collections.Generic;
using Enums;

namespace Inventory
{
    public interface IInventory
    {
        int NumSlots { get; set; }
        List<ISlot> Slots { get; set; }
        ISlot GetSlot(ResourceType type);
    }
}