using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 0.125f;
    public float attackRange = 4;
    public int damage;

    public SpriteRenderer ghostSprite;

    //OffSet
    private static Vector3 offsetRight = new Vector2(1, 1);
    private static Vector3 offsetLeft = new Vector2(-1, 1);
    private Vector3 offset = offsetLeft;
    private IEnumerator offsetCoroutine;
    private bool offsetCoroutineRunning = false;

    private bool isAttacking = false;
    private Vector3 attackPos;
    private IEnumerator attackCoroutine;
    private bool attackCoroutineRunning = false;

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        if (player.GetComponent<PlayerMovement>().isFacingRight())
        {
            attackPos = new Vector3(player.transform.position.x + attackRange, player.transform.position.y, player.transform.position.z);
        }
        else
        {
            attackPos = new Vector3(player.transform.position.x - attackRange, player.transform.position.y, player.transform.position.z);
        }
        
        if(!player.GetComponent<Player>().isDead)
        {
            if (Input.GetButtonDown("Attack") && !attackCoroutineRunning)
            {
                Attack();
            }
        }
    }


    void FixedUpdate()
    {
        //Follow player if not attacking
        if (!isAttacking)
        {
            if (player.GetComponent<PlayerMovement>().isFacingRight())
            {
                if(offset != offsetLeft && !offsetCoroutineRunning)
                {
                    offsetCoroutine = OffsetLerp(offsetRight, offsetLeft, 0.5f);
                    StartCoroutine(offsetCoroutine);
                }
            }
            else
            {
                if (offset != offsetRight && !offsetCoroutineRunning)
                {
                    offsetCoroutine = OffsetLerp(offsetLeft, offsetRight, 0.5f);
                    StartCoroutine(offsetCoroutine);
                }
            }
            Vector3 desiredPosition = player.transform.position + offset;

            // Adjust position to player position
            transform.position = Vector3.Lerp(transform.position, desiredPosition, 1 - Mathf.Pow(1 - moveSpeed, Time.deltaTime * 60));
        }
    }

    IEnumerator OffsetLerp(Vector3 startPos, Vector3 endPos, float duration)
    {
        if (!attackCoroutineRunning)
        {
            offsetCoroutineRunning = true;
            float timeElapsed = 0;

            while (timeElapsed < duration)
            {
                offset = Vector3.Lerp(startPos, endPos, timeElapsed / duration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            offset = endPos;
            if(player.GetComponent<PlayerMovement>().isFacingRight())
            {
                ghostSprite.flipX = false;
            }
            else
            {
                ghostSprite.flipX = true;
            }
            offsetCoroutineRunning = false;
        }
    }

    void Attack()
    {
        if (player.GetComponent<PlayerMovement>().isFacingRight())
        {
            ghostSprite.flipX = false;
        }
        else
        {
            ghostSprite.flipX = true;
        }

        if (!attackCoroutineRunning)
        {
        attackCoroutine = GhostPosLerp(this.transform.position, player.transform.position, attackPos, 0.1f);
        StartCoroutine(attackCoroutine);
        }
    }

    IEnumerator GhostPosLerp(Vector3 startPos, Vector3 endPos1, Vector3 endPos2, float duration)
    {
        attackCoroutineRunning = true;
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            this.transform.position = Vector3.Lerp(startPos, endPos1, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        timeElapsed = 0;
        this.transform.position = endPos1;

        isAttacking = true;
        while (timeElapsed < duration)
        {
            this.transform.position = Vector3.Lerp(endPos1, endPos2, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        timeElapsed = 0;
        this.transform.position = endPos2;

        while (timeElapsed < duration)
        {
            this.transform.position = Vector3.Lerp(endPos2, endPos1, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        this.transform.position = endPos1;

        isAttacking = false;
        attackCoroutineRunning = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isAttacking && collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyBase>().TakeDamage(damage);
            isAttacking = false;
        }
    }
}