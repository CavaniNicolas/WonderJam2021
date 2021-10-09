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
    public int maxPlayerHealth = 3;
    public int playerHealth;
    private void Start() {
        currentCoins = 0;
        playerHealth = maxPlayerHealth;
    }
    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }
    void Update() {
        if(Input.GetButtonDown("usePotion"))
        {
            if(hasPotion > 0)
            {
                hasPotion -= 1;
                playerHealth = maxPlayerHealth;
            }
        }
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
