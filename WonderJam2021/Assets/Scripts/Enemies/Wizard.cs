using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{

    public float attackSpeed; // in seconds

    private float lastShotTime;

    public Transform firePoint;
    public GameObject fireBallPrefab;

    private void FixedUpdate()
    {
        if (Time.realtimeSinceStartup - lastShotTime > attackSpeed)
        {
            shoot();
            lastShotTime = Time.realtimeSinceStartup;
        }
    }

    private void shoot()
    {
        Instantiate(fireBallPrefab, firePoint.position, firePoint.rotation);
    }
}
