using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{

    public float m_attackSpeed; // in seconds

    private float m_lastShotTime;

    public Transform m_firePoint;
    public GameObject m_fireBallPrefab;

    private void FixedUpdate()
    {
        if (Time.realtimeSinceStartup - m_lastShotTime > m_attackSpeed)
        {
            shoot();
            m_lastShotTime = Time.realtimeSinceStartup;
        }
    }

    private void shoot()
    {
        Instantiate(m_fireBallPrefab, m_firePoint.position, m_firePoint.rotation);
    }
}
