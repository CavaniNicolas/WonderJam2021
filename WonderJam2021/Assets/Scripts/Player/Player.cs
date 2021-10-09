using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int currentCoins;

    //to know if the player already has items
    public bool hasMinerHelmet;
    public bool hasTorch;
    public bool hasLeash;
    public bool hasShoes;
    public bool hasArmor;
    public int hasPotion;
    private void Start() {
        currentCoins = 0;
    }
    public void setCoins(int coins)
    {
        currentCoins = coins;
    }
    public int getCoins()
    {
        return currentCoins;
    }
}
