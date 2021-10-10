using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : EnemyBase
{

    public float m_attackSpeed; // in seconds

    private float m_lastShotTime;

    public Transform m_firePoint;
    public GameObject m_fireBallPrefab;

    public bool m_isFacingRight = true;
    private Vector2 m_direction = Vector2.right;

    private void FixedUpdate()
    {
        if ((m_isFacingRight && m_direction == Vector2.left) || (!m_isFacingRight && m_direction == Vector2.right))
        {
            transform.Rotate(0f, 180f, 0f);
            if (m_isFacingRight)
                m_direction = Vector2.right;
            else
                m_direction = Vector2.left;
        }

        if (Time.realtimeSinceStartup - m_lastShotTime > m_attackSpeed)
        {
            shoot();
            m_lastShotTime = Time.realtimeSinceStartup;
        }
    }

    private void shoot()
    {
        audioManager.GetComponent<AudioManager>().PlayFireballSound();
        GameObject fireball = Instantiate(m_fireBallPrefab, m_firePoint.position, m_firePoint.rotation);
        fireball.GetComponent<Fireball>().setDirection(m_direction);
    }
}
