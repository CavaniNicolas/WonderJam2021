using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Player m_player;
    private CameraFollowPlayer m_camera;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void FixedUpdate()
    {
        m_player = GameObject.Find("Player").GetComponent<Player>();
        m_camera = GameObject.Find("Main Camera").GetComponent<CameraFollowPlayer>();

        if (m_player.isDead)
        {
            m_camera.zoomOnPlayer();
        }
        else
        {
            m_camera.followPlayer();
        }
    }
}
