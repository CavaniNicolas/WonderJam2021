using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int currentCoins;
    public int maxPlayerHealth = 3;
    public int playerHealth;
    public float invulnTime = 3f;
    private float currentInvulnTime = 0f;
    public bool hasBeenDamaged = false;
    public Animator animator;

    public bool isDead = false;


    //to know if the player already has items
    public bool hasMinerHelmet;
    public bool hasTorch;
    public bool hasLeash;
    public bool hasShoes;
    public bool hasArmor;
    public int hasPotion;
    private GameObject audioManager;
    private void Awake()
    {
        audioManager = GameObject.Find("AudioManager");
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start() {
        currentCoins = 0;
        playerHealth = maxPlayerHealth;
    }

    void Update() {
        if(Input.GetButtonDown("usePotion"))
        {
            if(hasPotion > 0)
            {
                audioManager.GetComponent<AudioManager>().PlayPotionSound();
                hasPotion -= 1;
                playerHealth = maxPlayerHealth;
            }
        }

        if (hasBeenDamaged)
        {
            currentInvulnTime += Time.deltaTime;
            if (currentInvulnTime >= invulnTime)
            {
                currentInvulnTime = 0f;
                hasBeenDamaged = false;
            }
        }
    }

    public void setCoins(int coins)
    {
        currentCoins = coins;
    }

    public int getCoins()
    {
        return currentCoins;
    }

    public void TakeDamage(int damage)
    {
        audioManager.GetComponent<AudioManager>().PlayHeroHit();
        playerHealth -= damage;
        hasBeenDamaged = true;
        if (playerHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        animator.SetBool("isDead", true);
        isDead = true;
        Invoke("Revive", 2f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!isDead)
        {
            if(!hasBeenDamaged)
            {
                if (collision.gameObject.CompareTag("Enemy"))
                {
                    TakeDamage(collision.gameObject.GetComponent<EnemyBase>().damage);
                    hasBeenDamaged = true;
                }
            }

        }
    }

    private void Revive()
    {
        playerHealth = maxPlayerHealth;
        animator.SetBool("isDead", false);
        isDead = false;
        hasBeenDamaged = false;
        SceneManager.LoadScene("SceneOutsideNoPlayer");
    }
}
