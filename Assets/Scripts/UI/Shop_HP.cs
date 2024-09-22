using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_HP : MonoBehaviour
{
    [SerializeField]
    int _restoredHealth = 100;
    Button _button;
    [SerializeField]
    int _cost = 5;
    [SerializeField]
    Text _description;

    void Start()
    {
        _description.text = $"Heal for {_restoredHealth}hp\nCost:{_cost}";  
    }
    public void AddHP()
    {
        if (GameManager.Instance.Coins >= _cost)
        {
            GameManager.Instance.FightWorldPlayer.GetDmg(-_restoredHealth);
            GameManager.Instance.Announcer.Announce("Sooooo fresh");
            GameManager.Instance.Coins -= _cost;
        }
        else
        {
            GameManager.Instance.Announcer.Announce($"Can't heal, no money!");
            return;
        }    
    }
}
