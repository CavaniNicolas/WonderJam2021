using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int health;
    public int damage;
    public SpriteRenderer sprite;

    public void TakeDamage(int damage)
    {
        health -= damage;
        TurnRed();
        Invoke("TurnWhite", 0.5f);
        if (health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(this.gameObject);
    }

    void TurnRed()
    {
        sprite.color = new Color(255, 0, 0);
    }

    void TurnWhite()
    {
        sprite.color = new Color(255, 255, 255);
    }

    private void Update()
    {
        
    }
}
