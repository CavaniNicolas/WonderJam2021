using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public float maxX = 20;
    public float minX = 0;

    public bool m_canFollowY = false;

    public float maxY = 20;
    public float minY = 0;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        if(!player)
            Debug.Log("player not found");
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Adjust camera position to player position

        float smoothedPosition_X = Mathf.Max(minX, Mathf.Min(maxX, smoothedPosition.x));
        float smoothedPosition_Y = 0.0f;

        if (m_canFollowY)
        {
            smoothedPosition_Y = Mathf.Max(minY, Mathf.Min(maxY, smoothedPosition.y));

        }

        this.transform.position = new Vector3(smoothedPosition_X, smoothedPosition_Y, -50.0f);
        

    }
}
