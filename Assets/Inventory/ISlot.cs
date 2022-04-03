using Enums;

namespace Inventory
{
    public interface ISlot
    {
        ResourceType Type { get; set; }
        float Amount { get; set; }
    }
}