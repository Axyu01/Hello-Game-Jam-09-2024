using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIController : MonoBehaviour
{
    [SerializeField]
    GameObject ShopUI;
    [SerializeField]
    Image Blur;
    [SerializeField]
    Animator shopAnimator;
    [SerializeField]
    private bool isShopVisible;

    void Start()
    {
        Blur.gameObject.SetActive(false);
    }

    public void ToggleShopView()
    {
        if (isShopVisible)
        {
            shopAnimator.Play("ShopOUT");
            StartCoroutine(HideBlurAfterAnimation());
        }
        else
        {
            shopAnimator.Play("ShopIN");
            Blur.gameObject.SetActive(true);
        }
        isShopVisible = !isShopVisible;
    }

    private IEnumerator HideBlurAfterAnimation()
    {
        yield return new WaitForSeconds(shopAnimator.GetCurrentAnimatorStateInfo(0).length);
        Blur.gameObject.SetActive(false );
    }
}
