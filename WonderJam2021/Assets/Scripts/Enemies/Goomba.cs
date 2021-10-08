using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : MonoBehaviour
{
    public GameObject platform;
    private float platformLeft;
    private float platformRight;

    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        platformLeft = platform.transform.position.x - platform.transform.localScale.x / 2;
        platformRight = platform.transform.position.x + platform.transform.localScale.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (transform.position.x + transform.localScale.x / 2 >= platformRight || transform.position.x - transform.localScale.x / 2 <= platformLeft)
        {
            speed *= -1;
        }

        transform.position = transform.position + new Vector3(speed * Time.fixedDeltaTime, 0, 0);
    }
}
