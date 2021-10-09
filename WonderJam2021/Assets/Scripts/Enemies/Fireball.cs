using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // linked to the rigid body of the fireball
    public Rigidbody2D m_rb;
    public float m_speed = 5f;

    private Vector2 m_direction; // left or right

    // Start is called before the first frame update
    void Start()
    {
        m_direction = Vector2.right;
        m_rb.velocity = transform.right * m_direction.x * m_speed;
        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.name);
        Destroy(gameObject);
    }
}
