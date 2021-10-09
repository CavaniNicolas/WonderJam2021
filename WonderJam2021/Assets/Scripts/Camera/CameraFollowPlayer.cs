using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public float maxX = 20;
    public float minX = 0;

    [Range(0, 100)]
    public int currentStage = 0;


    void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Adjust camera position to player position

        float smoothedPosition_X  = Mathf.Max(minX, Mathf.Min(maxX, smoothedPosition.x));
        this.transform.position = new Vector3(smoothedPosition_X, 0.0f, -50.0f);
        
    }
}
