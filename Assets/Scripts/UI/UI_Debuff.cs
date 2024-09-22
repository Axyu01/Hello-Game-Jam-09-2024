using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Debuff : MonoBehaviour
{
    public Slider DebuffSlider;
    [SerializeField]
    EntityBase _entity;

    private void Start()
    {
        DebuffSlider.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(_entity == null) return;
        if (GameManager.Instance.FightWorldPlayer.IsDebuffed)
        {
            DebuffSlider.gameObject.SetActive(true);
            DebuffSlider.value = _entity.DebuffTimeLeft / _entity.DebuffTime;
        }
        else
            DebuffSlider.gameObject.SetActive(false);
    }
}
