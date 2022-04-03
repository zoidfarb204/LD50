using Enums;

namespace Inventory
{
    public class Slot : ISlot
    {
        public ResourceType Type { get; set; }
        public float Amount { get; set; }
    }
}