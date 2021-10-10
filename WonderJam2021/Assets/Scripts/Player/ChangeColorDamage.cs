using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorDamage : MonoBehaviour
{
    public GameObject player;
    private SpriteRenderer sprite;
    private Player playerScript;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        playerScript = player.GetComponent<Player>();
    }

    private void Update()
    {
        if(player != null)
        {

            if (playerScript.hasBeenDamaged && !playerScript.isDead)
            {
                sprite.color = new Color(255, 0, 0);
            }
            else
            {
                sprite.color = new Color(255, 255, 255);
            }
        }
    }
}
