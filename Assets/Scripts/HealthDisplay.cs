using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    TextMeshProUGUI healthText;
    DamageTaker playerHealthComponent;
    float playerHealth;
    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        playerHealthComponent = FindObjectOfType<Player>().GetComponent<DamageTaker>();
       // healthText.text = playerHealthComponent.GetHealth().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        float playerHealth = playerHealthComponent.GetHealth();

        if (this.playerHealth == playerHealth) return;

        healthText.text = (playerHealth <= 0) ? "0" : playerHealth.ToString();

        this.playerHealth = playerHealth;
    }
}
