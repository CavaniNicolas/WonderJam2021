using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class WraithGFX : EnemyBase
{

    public AIPath m_aiPath;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //wraith orientation
        if (m_aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
        } else if (m_aiPath.desiredVelocity.x <= -0.01)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
}
