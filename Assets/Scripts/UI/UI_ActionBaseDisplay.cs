using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ActionBaseDisplay : MonoBehaviour
{
    public Text AmmoText;
    public Slider CooldownSlider;
    public Image CooldownCircle;

    private void Start()
    {
        ActionBase actionBase = GetCurrentPlayerAction();
        if (actionBase != null && CooldownSlider != null)
        {
            CooldownCircle.fillAmount = 0f;
        }
    }

    private void Update()
    {
        ActionBase actionBase = GetCurrentPlayerAction();
        if (actionBase != null)
        {
            if (AmmoText != null)
            {
                AmmoText.text = $"AMMO:{actionBase.CurrentAmmo}";
            }

            if (CooldownSlider != null)
            {
                CooldownSlider.value = 1f - actionBase.CooldownLeft / actionBase.ActionCooldown;
            }
            if(CooldownCircle != null)
            {
                CooldownCircle.fillAmount = actionBase.CooldownLeft / actionBase.ActionCooldown;
            }
        }
        if(actionBase != null && actionBase.CurrentAmmo == 0 && Input.GetKey(KeyCode.Mouse0) && CooldownCircle.fillAmount == 0f)
        {
            Debug.Log("No ammo");
           /* if (!isShowingNoAmmo)
            {
                StartCoroutine(ShowNoAmmoText());
            }
           */
        }

    }
    public ActionBase GetCurrentPlayerAction()
    {
        Player currentPlayer;
        if (WorldSwitcher.IsChillWorldActive)
        {
            currentPlayer = GameManager.Instance.ChillWorldPlayer;
        }
        else
        {
            currentPlayer = GameManager.Instance.FightWorldPlayer;
        }
        return currentPlayer.Action;
    }
}
