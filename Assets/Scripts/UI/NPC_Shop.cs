using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class NPC_Shop : MonoBehaviour
{
    [SerializeField]
    GameObject ShopUI;
    private bool _isShopActive;
    

    public void ShopExit()
    {
        if (_isShopActive == true)
            {
                ShopUI.SetActive(false);
            }
    }

  





}
