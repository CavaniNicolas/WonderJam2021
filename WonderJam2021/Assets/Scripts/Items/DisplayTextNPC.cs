using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayTextNPC : MonoBehaviour
{
    private float timer;
    public TMP_Text TextBox;
    private bool add;
    private GameObject player;
    private void Awake() {
        player = GameObject.Find("Player");
        player.GetComponent<GetItem>().NPCDialog = this.gameObject;
    }
    // Update is called once per frame
    private void Update() {
        timer += Time.deltaTime;
        if(timer < 2)
        {
            
        }
        else if (add)
        {
            add = false;
            TextBox.text = "";
        }
        

    }


    public void DisplayTextOnBox(string text)
    {
        if(text == "Torch")
        {
            TextBox.text = "You need light around you ? \n only 40 golds and it's for ya";
            timer = 0;
            add = true;
        }
        else if(text == "Shoes")
        {
            TextBox.text = "That's legendary Boots. \n You can jump in air with that. 100 Golds !!";
            timer = 0;
            add = true;
        }
        else if(text == "Potion")
        {
            TextBox.text = "Small pot for ya ? 10 golds each";
            timer = 0;
            add = true;
        }
        else if(text == "Electric_leash")
        {
            TextBox.text = "Want to tame your monster with force, i see.\n 60 golds to do that.";
            timer = 0;
            add = true;
        }
        else if(text == "Armor")
        {
            TextBox.text = "You aren't strong enough to not need armor ? 30 golds";
            timer = 0;
            add = true;
        }
        else if(text == "Miner_helmet")
        {
            TextBox.text = "frontlight ? 40 golds.";
            timer = 0;
            add = true;
        }
        
    }
}
