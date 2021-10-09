using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 direction; // left or right
    private float velocity;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.right;
        velocity = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.position = transform.position += new Vector3(velocity * direction.x * Time.deltaTime, 0f, 0f);
    }
}
