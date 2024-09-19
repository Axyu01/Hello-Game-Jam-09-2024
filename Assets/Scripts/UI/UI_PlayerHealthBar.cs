using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_PlayerHealthBar : MonoBehaviour
{
    public Text HealthText;
    //public Slider HealthSlider;
    public void Update()
    {
        HealthText.text = $"HEALTH:{GameManager.Instance.FightWorldPlayer.Health}";
    }
    /*void Start()
    {

        if (gameManager != null && HealthSlider != null)
        {
            HealthSlider.maxValue = gameManager.MaxHealth;
        }
    }

    private void Update()
    {
        if (gameManager != null)
        {

            if(HealthText != null) 
            {
                healthText.text = GameManager.currentHealth.ToString();
            }

            if (HealthSlider != null)
            {
                HealthSlider.value = GameManager.currentHealth;
            }
        }
    }*/
}

