using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UpgradeItem : Item
{
    [SerializeField] private Button upgradeButton;
    public UnityEvent OnChosenUpgrade;

    public void Upgrade()
    {
        OnChosenUpgrade.Invoke();
    }
}
