using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getItem : MonoBehaviour
{
    private GameObject itemToBuy;
    private bool canBuy = false;
    public GameObject player;
    private bool canOpenChest = false;
    private GameObject chestToOpen;
    public GameObject text;

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
            //ShowText(other.GetItemName);
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
        Debug.Log("j'essaye d'achete la/le : " + text);
    }
    
    //to buy an item and/or not get its effect
    private void BuyItem()
    {
        int coins = player.GetComponent<Player>().getCoins();
        int cost = itemToBuy.GetComponent<Item_Info>().GetItemCost();
        string itemName = itemToBuy.GetComponent<Item_Info>().GetItemName();
        if (itemName == "Miner_helmet")
        {
            if(player.GetComponent<Player>().hasMinerHelmet == false)
            {
                
                if (cost <= coins)
                {
                    player.GetComponent<Player>().hasMinerHelmet = true;
                    player.GetComponent<GestionItem>().BuyHelmet();
                    coins -= cost;
                    DisplayText("J'ai acheté le casque de mineur !!");
                }
                else
                {
                    DisplayText("Je n'ai pas assez de sous pour ça");
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
                    DisplayText("J'ai acheteé la torche !!");
                }
                else
                {
                    DisplayText("Je n'ai pas assez de sous pour ça");
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
                    DisplayText("J'ai acheté la laisse électrique !!");
                }
                else
                {
                    DisplayText("Je n'ai pas assez de sous pour ça");
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
                    DisplayText("J'ai acheté la laisse électrique !!");
                }
                else
                {
                    DisplayText("Je n'ai pas assez de sous pour ça");
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
                    DisplayText("J'ai acheté les bottes ailées !!");
                }
                else
                {
                    DisplayText("Je n'ai pas assez de sous pour ça");
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
                    DisplayText("J'ai acheté 1 potion !!");
                }
                else
                {
                    DisplayText("Je n'ai pas assez de sous pour ça");
                }
                player.GetComponent<Player>().setCoins(coins);
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
        
    }
}
