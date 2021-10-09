using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    private GameObject itemToBuy;
    private bool canBuy = false;
    public GameObject player;
    private bool canOpenChest = false;
    private GameObject chestToOpen;
    public GameObject text;
    private GameObject NPCDialog;

    void Awake() {
        NPCDialog = GameObject.Find("Dialog NPC");
    }

    void Update() {
        if (canBuy)
        {
            if(Input.GetButtonDown("Interact"))
            {
                
                BuyItem();
            }
        }

        if (canOpenChest)
        {
            if(Input.GetButtonDown("Interact"))
            {
                OpenChest();
            }
        }
    }

    //OnTriggerEnter and OnTriggerExit to know if the player is in a Item To Buy Area
    public void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Item")
        {
            ShowText(other.gameObject.GetComponent<ItemInfo>().GetItemName());
            canBuy = true;
            itemToBuy = other.gameObject;
        }

        if(other.tag == "Chest")
        {
            canOpenChest = true;
            chestToOpen = other.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Item")
        {
            canBuy = false;
        }
        if(other.tag == "Chest")
        {
            canOpenChest = false;
        }
    }
    
    //to return something to the player such has how much that cost or the property of the item to make pnj talk
    void ShowText(string text)
    {
        NPCDialog.GetComponent<DisplayTextNPC>().DisplayTextOnBox(text);
    }
    
    //to buy an item and/or not get its effect
    private void BuyItem()
    {
        int coins = player.GetComponent<Player>().getCoins();
        int cost = itemToBuy.GetComponent<ItemInfo>().GetItemCost();
        string itemName = itemToBuy.GetComponent<ItemInfo>().GetItemName();
        if (itemName == "Miner_helmet")
        {
            if(player.GetComponent<Player>().hasMinerHelmet == false)
            {
                
                if (cost <= coins)
                {
                    player.GetComponent<Player>().hasMinerHelmet = true;
                    player.GetComponent<GestionItem>().BuyHelmet();
                    coins -= cost;
                    DisplayText("I bought a frontlight");
                    itemToBuy.SetActive(false); 
                }
                else
                {
                    DisplayText("Not enough Gold");
                }
                player.GetComponent<Player>().setCoins(coins);
            }
        }
        else if (itemName == "Torch")
        {
            if(player.GetComponent<Player>().hasTorch == false)
            {
                
                if (cost <= coins)
                {
                    player.GetComponent<Player>().hasTorch = true;
                    player.GetComponent<GestionItem>().BuyTorch();
                    coins -= cost;
                    DisplayText("I bought the Torch !");
                    itemToBuy.SetActive(false);
                }
                else
                {
                    DisplayText("Not enough Gold");
                }
                player.GetComponent<Player>().setCoins(coins);
            }
        }
        else if (itemName == "Electric_leash")
        {
            if(player.GetComponent<Player>().hasLeash == false)
            {
                
                if (cost <= coins)
                {
                    player.GetComponent<Player>().hasLeash = true;
                    player.GetComponent<GestionItem>().BuyLeash();
                    coins -= cost;
                    DisplayText("I bought Electric Leash.");
                    itemToBuy.SetActive(false);
                }
                else
                {
                    DisplayText("Not enough Gold");
                }
                player.GetComponent<Player>().setCoins(coins);
            }
        }
        else if (itemName == "Armor")
        {
            if(player.GetComponent<Player>().hasArmor == false)
            {
                
                if (cost <= coins)
                {
                    player.GetComponent<Player>().hasArmor = true;
                    player.GetComponent<GestionItem>().BuyArmor();
                    coins -= cost;
                    DisplayText("I bought the armor");
                    itemToBuy.SetActive(false);
                }
                else
                {
                    DisplayText("Not enough Gold");
                }
                player.GetComponent<Player>().setCoins(coins);
            }
        }
        else if (itemName == "Shoes")
        {
            if(player.GetComponent<Player>().hasShoes == false)
            {
                
                if (cost <= coins)
                {
                    player.GetComponent<Player>().hasShoes = true;
                    player.GetComponent<GestionItem>().BuyBoots();
                    coins -= cost;
                    DisplayText("I got Legendary Boots");
                    itemToBuy.SetActive(false);
                }
                else
                {
                    DisplayText("Not enough Gold");
                }
                player.GetComponent<Player>().setCoins(coins);
            }
        }
        else if (itemName == "Potion")
        {
            if(player.GetComponent<Player>().hasPotion < 3)
            {
                
                if (cost <= coins)
                {
                    player.GetComponent<Player>().hasPotion += 1;
                    coins -= cost;
                    DisplayText("I bought a pot !");
                }
                else
                {
                    DisplayText("Not enough Gold");
                }
                player.GetComponent<Player>().setCoins(coins);
            }
            else if (player.GetComponent<Player>().hasPotion >= 3)
            {
                DisplayText("I already have enough of these in my pocket");
            }
        }
    }
    void DisplayText(string textToAdd)
    {
        text.GetComponent<DisplayText>().DisplayTextOnBox(textToAdd);
    }
    void OpenChest()
    {
        int coinsGet = Random.Range(10, 21);
        int currentcoins = player.GetComponent<Player>().getCoins();
        currentcoins += coinsGet;
        player.GetComponent<Player>().setCoins(currentcoins);
        DisplayText("+ "+ coinsGet + " Golds");
        chestToOpen.SetActive(false);
    }
}
