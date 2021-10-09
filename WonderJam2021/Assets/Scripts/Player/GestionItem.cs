using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionItem : MonoBehaviour
{
    private GameObject player;
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
        //todo
    }

    public void BuyTorch()
    {
        //todo
    }

    public void BuyLeash()
    {
        //todo
    }

    public void BuyArmor()
    {

    }

    public void ResetItems()
    {

    }
}
