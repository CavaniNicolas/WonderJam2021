using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PlayerDetection : MonoBehaviour
{
    public AIPath m_aiPath;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            m_aiPath.maxSpeed = 10f;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            m_aiPath.maxSpeed = 3.5f;
        }
    }
}
