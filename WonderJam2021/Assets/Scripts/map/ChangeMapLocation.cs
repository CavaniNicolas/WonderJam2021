using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMapLocation : MonoBehaviour
{
    private GameObject player, ghost, rope;
    private void Awake() {
        player= GameObject.Find("Player");
        ghost = GameObject.Find("Ghost");
        player.GetComponent<Transform>().position = this.gameObject.GetComponent<Transform>().position;
        ghost.GetComponent<Transform>().position = this.gameObject.GetComponent<Transform>().position;
        
    }
}
