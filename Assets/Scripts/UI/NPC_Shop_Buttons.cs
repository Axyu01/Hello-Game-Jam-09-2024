using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC_Shop_Buttons : MonoBehaviour
{
    [SerializeField]
    Button _button;
    [SerializeField]
    Image _image;
    [SerializeField]
    Text _description;
    [SerializeField]
    GameObject _boughtWeapon;
    [SerializeField]
    bool _weaponIsForFightWorld = true;
    [SerializeField]
    int _cost  = 5;
    void Start()
    {
        _description.text = $"{_boughtWeapon.name}\nCost:{_cost}";
        _prevImageColor = _image.color;
        _prevDescriptionColor = _description.color;
    }
    Color _prevImageColor = Color.white;
    Color _prevDescriptionColor = Color.white;
    bool _colorChanged = false;
    private void Update()
    {
        if (GameManager.Instance.Coins < _cost)
        {
            //_button.interactable = false;
            if (_colorChanged == false)
            {
                _prevImageColor = _image.color;
                _prevDescriptionColor = _description.color;
                _colorChanged = true;
            }
            Color c = _image.color;
            c.a = 0.2f;
            _image.color = c;
            c = _description.color;
            c.a = 0.2f;
            _description.color = c;
        }
        else
        {
            //_button.interactable = true;
            _image.color = _prevImageColor;
            _description.color = _prevDescriptionColor;
            _colorChanged = false;
        }
    }
    public void AfterBuy()
    {
        if(GameManager.Instance.Coins >= _cost)
        {
            GameManager.Instance.Announcer.Announce($"Bought {_boughtWeapon.name}!");
            GameManager.Instance.Coins -= _cost;
        }
        else
        {
            GameManager.Instance.Announcer.Announce($"Can't buy {_boughtWeapon.name}!");
            return;
        }
        //_button.interactable = false;
        //Color c = _image.color;
        //c.a = 0.2f;
        //_image.color = c;
        //_description.text = "SOLD";
        if (_weaponIsForFightWorld)
        {
            GameManager.Instance.FightWorldPlayer.ChangeWeapon(_boughtWeapon);
        }
        else
        {
            GameManager.Instance.ChillWorldPlayer.ChangeWeapon(_boughtWeapon);
        }

    }

   
}
