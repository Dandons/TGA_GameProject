using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    public InventorySlot[] inventorySlots;
    void UseItem(int slot)
    {
        if(inventorySlots[slot].item!=null){
            if(inventorySlots[slot].UseItem()){
                return;
            }
        }
    }
}
