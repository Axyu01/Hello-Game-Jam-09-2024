using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopAnimator : MonoBehaviour
{
    [SerializeField]
    Animator _animator;
    public void CloseShop()
    {
        _animator.SetTrigger("ShopExit");
    }
    public void OpenShop()
    {
        gameObject.SetActive(true);
        _animator.SetTrigger("ShopEnter");
    }
    public void SetInactive()
    {
        gameObject.SetActive(false);
    }
}
