using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ActionBaseDisplay : MonoBehaviour
{
    public Text AmmoText;
    public Slider CooldownSlider;

    public ActionBase actionBase;

    private void Start()
    {
        if (actionBase != null && CooldownSlider != null)
        {
            CooldownSlider.maxValue = actionBase._actionCooldown;
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
        }
    }
}
