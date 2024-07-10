using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public TextMeshProUGUI healthText;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        healthText.text = "Health: " + currentHealth;
    }

    void Die()
    {
        // 遊戲結束邏輯
    }
}
