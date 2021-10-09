using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionItem : MonoBehaviour
{
    public GameObject Hat;
    private GameObject player;
    public GameObject torch;
    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
    }

    public void BuyBoots()
    {
        player.GetComponent<PlayerMovement>().jumpCountMax = 2;
        
    }

    public void BuyHelmet()
    {
        Hat.SetActive(true);
    }

    public void BuyTorch()
    {
        torch.SetActive(true);
    }

    public void BuyLeash()
    {
        //todo
    }

    public void BuyArmor()
    {
        player.GetComponent<Player>().maxPlayerHealth = 6;
        player.GetComponent<Player>().playerHealth = 6;
    }

    public void ResetItems()
    {
        player.GetComponent<PlayerMovement>().jumpCountMax = 1;
        player.GetComponent<Player>().maxPlayerHealth = 3;
        player.GetComponent<Player>().playerHealth = 3;
        Hat.SetActive(false);
        torch.SetActive(false);
    }
}
