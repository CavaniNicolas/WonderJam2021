using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Info : MonoBehaviour
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
