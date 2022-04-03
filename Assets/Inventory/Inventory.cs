using System.Collections.Generic;
using System.Linq;
using Enums;

namespace Inventory
{
    public class Inventory : IInventory
    {
        public int NumSlots { get; set; }
        public List<ISlot> Slots { get; set; }
       
        
        public ISlot GetSlot(ResourceType type)
        {
            var slot = Slots.FirstOrDefault(x => x.Type == type);
            if (slot == null && HasEmptySlot())
            {
                return AddSlot(type);
            }

            return slot;
        }

        public bool HasEmptySlot()
        {
            Slots.RemoveAll(x => x.Amount == 0);
            if (Slots.Count <= NumSlots)
            {
                return true;
            }

            return false;
        }

        public Slot AddSlot(ResourceType type)
        {
            var slot = new Slot { Type = type, Amount = 0 };
            Slots.Add(slot);
            return slot;
        }

        public static void TransferInventory(ISlot destination, ISlot source, float amount)
        {
            if (destination.Type == source.Type)
            {
                if (source.Amount <= amount)
                {
                    destination.Amount += source.Amount;
                    source.Amount = 0;
                }
                else
                {
                    source.Amount -= amount;
                    destination.Amount += amount;
                }
            }
        }
    }
}