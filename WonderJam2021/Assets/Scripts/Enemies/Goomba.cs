using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : MonoBehaviour
{
    public GameObject platform;
    private float platformLeft;
    private float platformRight;

    public float speed = 1f;
    private int direction; // 1 goes right, -1 goes left
    private float velocity;
    public LayerMask playerMask; // player layer

    // Start is called before the first frame update
    void Start()
    {
        platformLeft = platform.transform.position.x - platform.transform.localScale.x / 2;
        platformRight = platform.transform.position.x + platform.transform.localScale.x / 2;
        velocity = speed;
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // goomba now goes left
        if (transform.position.x + transform.localScale.x / 2 >= platformRight)
        {
            direction = -1;
        }

        // goomba now goes right
        if (transform.position.x - transform.localScale.x / 2 <= platformLeft)
        {
            direction = 1;
        }

        // have goomba run faster if the player is on the same platform
        if (IsPlayerOnPlatform())
            velocity = speed * 3;
        else
            velocity = speed;

        // moves the goomba
        transform.position = transform.position + new Vector3(velocity * direction * Time.fixedDeltaTime, 0, 0);
    }

    private bool IsPlayerOnPlatform()
    {
        float distance;
        if (direction > 0)
        {// if goomba goes right
            distance = platformRight - transform.position.x + transform.localScale.x / 2;
        }
        else
        { // if goomba goes left
            distance = transform.position.x + transform.localScale.x / 2 - platformLeft;
        }
        print(distance);

        return Physics2D.Raycast(transform.position, new Vector2(direction, 0), distance, playerMask);

        // // ca cest casse
        // return Physics2D.BoxCast(transform.position/* + new Vector3(0, transform.localScale.y, 0)*/, new Vector2(transform.localScale.x, transform.localScale.y), 0f, new Vector2(direction, 0), distance, playerMask);
    }
}
