using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // linked to the rigid body of the fireball
    public Rigidbody2D rb;
    public float speed = 5f;
    public int damage = 1;

    private Vector2 m_direction; // left or right

    // Start is called before the first frame update
    void Start()
    {
        m_direction = Vector2.right;
        m_rb.velocity = transform.right * m_direction.x * m_speed;
        Destroy(gameObject, 3);
    }

    public void setDirection(Vector2 direction)
    {
        m_direction = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
            collision.gameObject.GetComponent<Player>().hasBeenDamaged = true;
            Destroy(gameObject);
        }
    }
}
