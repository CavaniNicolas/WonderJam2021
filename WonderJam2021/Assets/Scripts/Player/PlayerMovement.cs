using UnityEngine;
using UnityEngine.Playables;

public class PlayerMovement : MonoBehaviour
{
    // public Variables
    public float moveSpeed = 10;
    public float jumpForce = 10;
    public int jumpCountMax = 1; // Si besoin pour faire un double saut
    public Transform groundCheck; // placer l'empty groundCheck au milieu du perso au niveau des pieds
    public LayerMask platformMask; // Le layermask des plateformes
    public Player playerStat;

    public Animator animator;       // utilise pour les animation
    public SpriteRenderer sprite;
    public PlayableDirector director;   // for intro cutscene

    public bool CanPlay = true;     // use to stop input for director

    // private Variables
    private Rigidbody2D rigidBodyComponent;
    private CapsuleCollider2D capsuleColliderComponent;
    private int jumpsCount = 1;
    private bool isJumpKeyPressed;
    private float horizontalnput;
    private bool isGrounded = true;
    private bool m_FacingRight = true; // ou le personnage regarde
    private GameObject audioManager;
    private float timer = 0f;
    private float timeBetweenFootStep = 0.3f;
    private bool stepCount;

    void Awake()
    {
        audioManager = GameObject.Find("AudioManager");
        rigidBodyComponent = GetComponent<Rigidbody2D>(); // On recupere le rigidbody du player
        capsuleColliderComponent = GetComponent<CapsuleCollider2D>(); // On recupere le capsule collider du player
    }

    private void Start()
    {
        jumpsCount = jumpCountMax;
    }

    void Update()
    {
        if((director == null || director.state != PlayState.Playing ) && CanPlay)
        {
            if(!playerStat.isDead)
            {
                // Jump input
                if (Input.GetButtonDown("Jump"))
                {
                    isJumpKeyPressed = true;
                }

                // Horizontal movement input
                horizontalnput = Input.GetAxisRaw("Horizontal");


                // Animationn 
                FlipHandle(horizontalnput * Time.fixedDeltaTime);   // flip the animation
                animator.SetBool("IsRunning", Mathf.Abs(horizontalnput) >0);
            }
            else
            {
                isJumpKeyPressed = false;
                horizontalnput = 0;
            }
        }
    }

    // FixedUpdate is called every physics update
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        GroundedCheck();
        // Saut
        if (isJumpKeyPressed && jumpsCount > 0 && (isGrounded || this.gameObject.GetComponent<Player>().hasShoes) )
        {
            rigidBodyComponent.velocity = new Vector2(rigidBodyComponent.velocity.x, 0f); // Met la velocit� y � 0 pour double saut
            Vector2 jumpVector = Vector2.up* jumpForce ;
            //Debug.Log(jumpForce);
            rigidBodyComponent.AddForce(jumpVector, ForceMode2D.Impulse); // Ajout force verticale
            jumpsCount--;

            animator.SetBool("isJumping", true);

        }

        // D�placement horizontal
        rigidBodyComponent.velocity = new Vector2(horizontalnput * moveSpeed * 10f * Time.fixedDeltaTime, rigidBodyComponent.velocity.y);
        if (rigidBodyComponent.velocity.sqrMagnitude > 0 && isGrounded == true)
        {
            if (timer > timeBetweenFootStep)
            {
                timer = 0;
                if (stepCount)
                {
                    audioManager.GetComponent<AudioManager>().PlayStep1();
                    stepCount = false;
                }
                else
                {
                    audioManager.GetComponent<AudioManager>().PlayStep2();
                    stepCount = true;
                }

            }
        }
        // Reset jump input
        isJumpKeyPressed = false;
    }

    public void GroundedCheck() // Check si le player est sur le sol avec un BoxCast
    {
        RaycastHit2D hit = Physics2D.BoxCast(groundCheck.position, new Vector2(capsuleColliderComponent.size.x * 0.8f, 0.1f), 0.0f, Vector2.down, 0f, platformMask);

        if (hit.collider != null)
        {
            jumpsCount = jumpCountMax; // Reset compteur de saut
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
        else
        {
            isGrounded = false;
            animator.SetBool("isJumping", true);
        }
    }



    private void FlipHandle(float move)
    {
        if (move > 0 && !m_FacingRight)
        {
            // ... flip the player.
            sprite.flipX = false;
            m_FacingRight = !m_FacingRight;
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && m_FacingRight)
        {
            // ... flip the player.
            sprite.flipX = true;
            m_FacingRight = !m_FacingRight;

        }
    }

    public bool isFacingRight()
    {
        return m_FacingRight;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            this.transform.parent = null;
        }
    }

}
