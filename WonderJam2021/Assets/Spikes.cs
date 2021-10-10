using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public BoxCollider2D m_collider2D;
    public SpriteRenderer m_sprite;

    public int m_damage;

    public float m_cooldown; // how long before spikes get out again
    private float m_lastShotTime;

    public float m_lastingTime; // how long the spikes stay out
    private float m_beginUpTime;

    private bool m_isUp;
    private GameObject audioManager;
    private void Awake()
    {
        audioManager = GameObject.Find("AudioManager");
    }
    private void FixedUpdate()
    {

        // time the spikes should wait before next attack
        if (Time.realtimeSinceStartup - m_lastShotTime > m_cooldown && !m_isUp)
        {
            audioManager.GetComponent<AudioManager>().PlaySpikeSound();
            m_collider2D.enabled = true;
            m_sprite.enabled = true;

            m_isUp = true;

            m_beginUpTime = Time.realtimeSinceStartup;
        }

        // time the spikes should stay up
        if (Time.realtimeSinceStartup - m_beginUpTime > m_lastingTime && m_isUp)
        {
            m_collider2D.enabled = false;
            m_sprite.enabled = false;

            m_isUp = false;

            m_lastShotTime = Time.realtimeSinceStartup;
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
            // damage the player if he touches the spikes
    //        collision.gameObject.GetComponent<Player>().TakeDamage(m_damage);
    //    }
    //}
    //the player is doing that now
}
