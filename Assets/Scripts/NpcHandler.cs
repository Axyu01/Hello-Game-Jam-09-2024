using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcHandler : MonoBehaviour
{
    [SerializeField]
    GameObject ShopUi;
    private bool _isShopActive;
    public void Interaction()
    {
        Debug.Log("witam");
    }

    public void Shop()
    {
        if (_isShopActive == false)
        {
            ShopUi.SetActive(true);
        }
    }
}
