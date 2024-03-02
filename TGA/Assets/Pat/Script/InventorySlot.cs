using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] TMP_Text stackCount;
    [SerializeField] Sprite sprite;
    [HideInInspector] public string itemID;
    [HideInInspector] public Item item;
    [HideInInspector] public int stack = 0;
    [HideInInspector] public int maxStack = 1;
    void Start()
    {
        stackCount.text = "";
    }
    public void SetSlot(Item _item)
    {
        item = _item;
        sprite = _item.sprite;
        itemID = _item.id;
        maxStack = _item.maxStack;
    }
    public bool AddItem()
    {
        if (stack < maxStack)
        {
            stack += 1;
            stackCount.text = stack.ToString();
            return true;
        }
        else{return false;}
    }
    public bool RemoveItem()
    {
        if (itemID[0] != 'K')
        {
            stack -= 1;
            if (stack <= 1)
            {
                stackCount.text = "";
            }
            if (stack <= 0)
            {
                ClearSlot();
            }
            return true;
        }
        else{return false;}
    }
    public bool UseItem()
    {
        if(itemID[0]!='K'){  
            item.UseItem();
            RemoveItem();
            return true;
        }
        else{return false;}
    }
    public void ClearSlot()
    {
        sprite = null;
        item = null;
        itemID = null;
        stack = 0;
        maxStack = 1;
        stackCount.text = "";
    }
}
