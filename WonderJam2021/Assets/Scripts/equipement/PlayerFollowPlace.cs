using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowPlace : MonoBehaviour
{
    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerMovement>().isFacingRight())
        {
            Vector3 position = player.GetComponent<Transform>().position + new Vector3(-0.4f,0,0);
            this.GetComponent<Transform>().position = position;
        }
        else
        {
            Vector3 position = player.GetComponent<Transform>().position + new Vector3(0.4f,0,0);
            this.GetComponent<Transform>().position = position;
        }
    }
}
