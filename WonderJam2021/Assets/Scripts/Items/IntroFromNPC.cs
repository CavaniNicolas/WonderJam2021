using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroFromNPC : MonoBehaviour
{

    public GameObject[] itemToBuy;
    public GameObject NPCText;

    public bool IntroDone = false;
    private GameObject audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("AudioManager");
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
        audioManager.GetComponent<AudioManager>().PlayVoice1();
        NPCText.GetComponent<DisplayTextNPC>().DisplayExactTextOnBox("Hello traveler...");
        yield return new WaitForSeconds(timeToWait);
        audioManager.GetComponent<AudioManager>().PlayVoice2();
        NPCText.GetComponent<DisplayTextNPC>().DisplayExactTextOnBox("I see you've been struck by bad fortune");
        yield return new WaitForSeconds(timeToWait);
        audioManager.GetComponent<AudioManager>().PlayVoice3();
        NPCText.GetComponent<DisplayTextNPC>().DisplayExactTextOnBox("This Ghost is now linked to you forever");
        yield return new WaitForSeconds(timeToWait);
        audioManager.GetComponent<AudioManager>().PlayVoice2();
        NPCText.GetComponent<DisplayTextNPC>().DisplayExactTextOnBox("Get the artifact hidden in the castle to cut the link !");
        yield return new WaitForSeconds(timeToWait);
        audioManager.GetComponent<AudioManager>().PlayVoice1();
        NPCText.GetComponent<DisplayTextNPC>().DisplayExactTextOnBox("Thanks to the link you can control the Ghost");
        yield return new WaitForSeconds(timeToWait);
        audioManager.GetComponent<AudioManager>().PlayVoice3();
        NPCText.GetComponent<DisplayTextNPC>().DisplayExactTextOnBox("It will help you attack enemies !");
        yield return new WaitForSeconds(timeToWait);
        audioManager.GetComponent<AudioManager>().PlayVoice1();
        NPCText.GetComponent<DisplayTextNPC>().DisplayExactTextOnBox("You can buy some things in my shop as well ;)");
        yield return new WaitForSeconds(timeToWait);
        audioManager.GetComponent<AudioManager>().PlayVoice1();
        NPCText.GetComponent<DisplayTextNPC>().DisplayExactTextOnBox("Good luck !");
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
