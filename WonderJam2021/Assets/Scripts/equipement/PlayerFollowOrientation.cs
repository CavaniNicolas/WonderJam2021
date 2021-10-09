using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowOrientation : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {

        if (player.GetComponent<PlayerMovement>().isFacingRight())
        {
            this.GetComponent<Transform>().eulerAngles = new Vector3(0,0,-90);
        }
        else
        {
            this.GetComponent<Transform>().eulerAngles = new Vector3(0,0,90);
        }
    }
}
