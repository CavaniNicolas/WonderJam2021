using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Player m_player;
    private Camera m_mainCamera;
    public Camera m_playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        m_player = GameObject.Find("Player").GetComponent<Player>();
        m_mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

/*        m_playerCamera.enabled = true;
        m_mainCamera.enabled = false;*/

        if (m_player.isDead)
        {
            //m_camera
        }
    }
}
