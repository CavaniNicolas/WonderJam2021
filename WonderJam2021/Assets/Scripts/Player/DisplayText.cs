using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayText : MonoBehaviour
{
    private float timer;
    public TMP_Text TextBox;
    private bool add;

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


    public void DisplayTextOnBox(string addingText)
    {
        Debug.Log(addingText);
        TextBox.text = addingText;
        timer = 0;
        add = true;
    }
}
