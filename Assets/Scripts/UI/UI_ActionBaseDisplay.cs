using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ActionBaseDisplay : MonoBehaviour
{
    public Text AmmoText;
    public Slider CooldownSlider;
    public Image CooldownCircle;

    public ActionBase actionBase;

    private void Start()
    {
        if (actionBase != null && CooldownSlider != null)
        {
            CooldownSlider.maxValue = actionBase._actionCooldown;
            CooldownCircle.fillAmount = 0f;
        }
    }

    private void Update()
    {
        if (actionBase != null)
        {
            if (AmmoText != null)
            {
                AmmoText.text = actionBase.CurrentAmmo.ToString();
            }

            if (CooldownSlider != null)
            {
                CooldownSlider.value = actionBase._cooldownLeft;
            }
            if(CooldownCircle != null)
            {
                CooldownCircle.fillAmount = actionBase._cooldownLeft / actionBase._actionCooldown;
            }
        }
    }
}
