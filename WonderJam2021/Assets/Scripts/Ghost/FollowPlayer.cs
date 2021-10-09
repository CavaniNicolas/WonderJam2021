using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public SpriteRenderer ghostSprite;


    void FixedUpdate()
    {
        if(player.GetComponent<PlayerMovement>().isFacingRight())
        {
            offset = new Vector2(-1f, 1f);
            ghostSprite.flipX = false;
        }
        else
        {
            offset = new Vector2(1f, 1f);
            ghostSprite.flipX = true;
        }
        Vector3 desiredPosition = player.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Adjust position to player position
        this.transform.position = smoothedPosition;
    }
}