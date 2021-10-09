using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionItem : MonoBehaviour
{
    public GameObject Hat;
    private GameObject player;
    public GameObject torch;
    public GameObject ghost;
    public GameObject rope;

    public int upgradeDamageLeash = 3;
    public Color upgradeColorLeash = new Color(0, 255, 255);
    public int upgradeArmorHealth = 6;


    private int jumpCountMaxDefault, maxPlayerHealthDefault, ghostDamageDefault;
    private Color ropeStartColorDefault, ropeEndColorDefault;

    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;

        jumpCountMaxDefault = player.GetComponent<PlayerMovement>().jumpCountMax;
        maxPlayerHealthDefault = player.GetComponent<Player>().maxPlayerHealth;
        ghostDamageDefault = ghost.GetComponent<Ghost>().damage;
        ropeStartColorDefault = rope.GetComponent<LineRenderer>().startColor;
        ropeEndColorDefault = rope.GetComponent<LineRenderer>().endColor;
    }

    public void BuyBoots()
    {
        player.GetComponent<PlayerMovement>().jumpCountMax = 2;
        
    }

    public void BuyHelmet()
    {
        Hat.SetActive(true);
    }

    public void BuyTorch()
    {
        torch.SetActive(true);
    }

    public void BuyLeash()
    {
        ghost.GetComponent<Ghost>().damage = upgradeDamageLeash;
        rope.GetComponent<LineRenderer>().startColor = upgradeColorLeash;
        rope.GetComponent<LineRenderer>().endColor = upgradeColorLeash;
    }

    public void BuyArmor()
    {
        player.GetComponent<Player>().maxPlayerHealth = upgradeArmorHealth;
        player.GetComponent<Player>().playerHealth = upgradeArmorHealth;
    }

    public void ResetItems()
    {
        player.GetComponent<PlayerMovement>().jumpCountMax = jumpCountMaxDefault;
        player.GetComponent<Player>().maxPlayerHealth = maxPlayerHealthDefault;
        player.GetComponent<Player>().playerHealth = maxPlayerHealthDefault;
        ghost.GetComponent<Ghost>().damage = ghostDamageDefault;
        rope.GetComponent<LineRenderer>().startColor = ropeStartColorDefault;
        rope.GetComponent<LineRenderer>().endColor = ropeEndColorDefault;
        Hat.SetActive(false);
        torch.SetActive(false);
    }
}
