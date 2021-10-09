using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{

    public float attackSpeed; // in milliseconds

    private float lastShotTime;

    public Transform firePoint;
    public GameObject fireBallPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Time.realtimeSinceStartup - lastShotTime > attackSpeed)
        {
            print(Time.realtimeSinceStartup);
            shoot();
            lastShotTime = Time.realtimeSinceStartup;
        }
    }

    private void shoot()
    {
        Instantiate(fireBallPrefab, firePoint.position, firePoint.rotation);
    }
}
