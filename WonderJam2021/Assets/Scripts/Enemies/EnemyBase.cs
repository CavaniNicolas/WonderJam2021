using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int health;
    public int damage;

    public GameObject audioManager;

    private void Awake() {
        audioManager = GameObject.Find("AudioManager");
    }

    public SpriteRenderer sprite;

    public void TakeDamage(int damage)
    {
        audioManager.GetComponent<AudioManager>().PlayEnnemyHit();
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
