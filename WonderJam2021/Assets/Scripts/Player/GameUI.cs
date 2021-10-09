using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    public GameObject player;
    public TMP_Text HealthText;
    public TMP_Text PotionText;
    public TMP_Text GoldText;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        HealthText.text = player.GetComponent<Player>().playerHealth.ToString();
        PotionText.text = player.GetComponent<Player>().hasPotion.ToString();
        GoldText.text = player.GetComponent<Player>().getCoins().ToString();
    }
}
