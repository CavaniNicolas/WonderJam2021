using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    public GameObject player;
    public TMP_Text HealthText;
    public TMP_Text PotionText;
    public TMP_Text GoldText;
    public Animator animator;

    public Image shoeLogo;
    public Image lightBackLogo;
    public Image headLightLogo;
    public Image armorLogo;
    public Image leashLogo;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        HealthText.text = player.GetComponent<Player>().playerHealth.ToString();
        PotionText.text = player.GetComponent<Player>().hasPotion.ToString();
        GoldText.text = player.GetComponent<Player>().getCoins().ToString();
        
        if(player.GetComponent<Player>().hasMinerHelmet)
        {
            headLightLogo.color = new Color(255, 255, 255, 255);
        }
        else
        {
            headLightLogo.color = new Color(0, 0, 0, 255);
        }
        if(player.GetComponent<Player>().hasTorch)
        {
            lightBackLogo.color = new Color(255, 255, 255, 255);
        }
        else
        {
            lightBackLogo.color = new Color(0, 0, 0, 255);
        }
        if(player.GetComponent<Player>().hasLeash)
        {
            leashLogo.color = new Color(255, 255, 255, 255);
        }
        else
        {
            leashLogo.color = new Color(0, 0, 0, 255);
        }
        if(player.GetComponent<Player>().hasShoes)
        {
            shoeLogo.color = new Color(255, 255, 255, 255);
        }
        else
        {
            shoeLogo.color = new Color(0, 0, 0, 255);
        }
        if(player.GetComponent<Player>().hasArmor)
        {
            armorLogo.color = new Color(255, 255, 255, 255);
        }
        else
        {
            armorLogo.color = new Color(0, 0, 0, 255);
        }
    }

    public void FadeIn()
    {
        animator.SetBool("FadeIn", true);
    }
    public void FadeOut()
    {
        animator.SetBool("FadeIn", false);
    }

}
