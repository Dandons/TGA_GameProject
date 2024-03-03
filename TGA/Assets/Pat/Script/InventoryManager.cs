using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    public Item testItem;
    public InventorySlot[] inventorySlots;
    void AddItem(Item item)
    {
        Debug.Log("run");
        foreach (InventorySlot slot in inventorySlots)
        {
            Debug.Log(slot.itemID);
            Debug.Log(item.id);
            if (item.id == slot.itemID)
            {
                slot.AddItem();
                Debug.Log("added");
                return;
            }
        }
        foreach (InventorySlot slot in inventorySlots)
        {
            if (slot.itemID == "")
            {
                Debug.Log("set");
                slot.SetSlot(item);
                return;
            }
        }
    }
    void UseItem(int slot)
    {
        if (inventorySlots[slot].item != null)
        {
            if (inventorySlots[slot].UseItem())
            {
                return;
            }
        }
    }

    [ContextMenu("testAdd")]
    void test()
    {
        AddItem(testItem);
    }
}
