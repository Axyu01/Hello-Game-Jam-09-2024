using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcHandler : MonoBehaviour
{
    [SerializeField]
    ShopAnimator ShopAnimator;
    public void Interaction()
    {
        Debug.Log("witam");
    }

    public void Shop()
    {
        ShopAnimator.OpenShop();
    }
}
