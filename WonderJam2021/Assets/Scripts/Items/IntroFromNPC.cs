using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroFromNPC : MonoBehaviour
{

    public GameObject[] itemToBuy;
    public GameObject NPCText;

    public bool IntroDone = false;


    // Start is called before the first frame update
    void Start()
    {
        if(IntroDone)
        {
            SetItemAvailable();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!IntroDone) {
            IntroDone = true;
            StartCoroutine(HandleDialogue());
        }
    }

    IEnumerator HandleDialogue()
    {
        float timeToWait = 3.0f;
        NPCText.GetComponent<DisplayTextNPC>().DisplayExactTextOnBox("Fuck Fuck Fuck");
        yield return new WaitForSeconds(timeToWait);
        NPCText.GetComponent<DisplayTextNPC>().DisplayExactTextOnBox("Quoi pourquoi tu juges");
        yield return new WaitForSeconds(timeToWait);
        NPCText.GetComponent<DisplayTextNPC>().DisplayExactTextOnBox("tu sais quoi ? ta daronne...");
        yield return new WaitForSeconds(timeToWait);
        NPCText.GetComponent<DisplayTextNPC>().DisplayExactTextOnBox("gneuh gneuh pas les daronnes");
        yield return new WaitForSeconds(timeToWait);

        Invoke("SetItemAvailable", 1.0f);
    }


    public void SetItemAvailable()
    {
        foreach (GameObject item in itemToBuy)
        {
            item.GetComponent<BoxCollider2D>().enabled = true;
        }

        
    }
}
