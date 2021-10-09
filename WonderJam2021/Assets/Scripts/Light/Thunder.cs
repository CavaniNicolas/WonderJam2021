using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    private float timeToWait;
    private float timer;
    private GameObject[] thunderLight;
    private void Awake() {
        thunderLight = GameObject.FindGameObjectsWithTag("ThunderLight");
        timeToWait = 2f;

    }
    // Update is called once per frame
    private void FixedUpdate() {
        timer += Time.deltaTime;
        if(timer >= timeToWait)
        {
            timer = 0;
            Invoke("LitThunder",0f);
            Invoke("UnLitThunder",0.1f);
            Invoke("LitThunder",0.5f);
            Invoke("UnLitThunder",0.6f);
            timeToWait = Random.Range(8,12);
        }
    }

    void LitThunder()
    {
        //add thundersound
        foreach (GameObject Light in thunderLight)
        {
            Light.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().intensity = 1f;
        }
    }
    void UnLitThunder()
    {
        foreach (GameObject Light in thunderLight)
        {
            Light.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().intensity = 0.2f;
        }
    }
}
