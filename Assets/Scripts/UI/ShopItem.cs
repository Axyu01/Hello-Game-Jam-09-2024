using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopItem : Item
{
    [SerializeField] private int cost;
    [SerializeField] private string costInfo;
    [SerializeField] private Button buyButton;

    public UnityEvent OnSuccessfulSale;
    public UnityEvent OnDismissedSale;

    public virtual bool CanBuy()
    {
        return true;
    }

    public void BuyItem()
    {
        if (CanBuy())
        {
            OnSuccessfulSale.Invoke();
        }
        else
        {
            OnDismissedSale.Invoke();
        }
    }
}
