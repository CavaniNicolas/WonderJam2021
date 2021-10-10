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

    private float speakTimer = 3; 

    private void Awake() {
        player = GameObject.Find("Player");
        player.GetComponent<GetItem>().NPCDialog = this.gameObject;
    }
    
    // Update is called once per frame
    private void Update() {
        timer += Time.deltaTime;
        if(timer < speakTimer)
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
            TextBox.text = "You need light around you ? \n only 40 coins and it's for ya";
            timer = 0;
            add = true;
        }
        else if(text == "Shoes")
        {
            TextBox.text = "That's legendary Boots. \n You can jump in air with that. 100 coins !!";
            timer = 0;
            add = true;
        }
        else if(text == "Potion")
        {
            TextBox.text = "Small potion for ya ? 10 coins each";
            timer = 0;
            add = true;
        }
        else if(text == "Electric_leash")
        {
            TextBox.text = "Want to increase the power of your link with the Ghost, i see.\n It will make killing monster easier, 60 golds to do that.";
            timer = 0;
            add = true;
        }
        else if(text == "Armor")
        {
            TextBox.text = "You need armor for more durability ? 50 golds";
            timer = 0;
            add = true;
        }
        else if(text == "Miner_helmet")
        {
            TextBox.text = "A nice light to see in front of you ? 40 golds.";
            timer = 0;
            add = true;
        }
        
    }



    public void DisplayExactTextOnBox(string text)
    {
        TextBox.text = text;
        timer = 0;
        add = true;
    }
}
