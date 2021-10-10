using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int health;
    public int damage;
    private GameObject audioManager;
    private void Awake() {
        audioManager = GameObject.Find("AudioManager");
    }
    public void TakeDamage(int damage)
    {
        audioManager.GetComponent<AudioManager>().PlayEnnemyHit();
        health -= damage;
        if (health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(this.gameObject);
    }
}
