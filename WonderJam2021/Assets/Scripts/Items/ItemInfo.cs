using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    public string itemName;
    public int itemCost;

    public int GetItemCost()
    {
        return itemCost;
    }
    
    public string GetItemName()
    {
        return itemName;
    }

}
