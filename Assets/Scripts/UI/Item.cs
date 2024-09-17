using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] protected Sprite infographic;
    [SerializeField] protected string description;

    public virtual void SetItemInfo(Image infographicImage, Text descriptionText)
    {
        if (infographicImage != null)
            infographicImage.sprite = infographic;

        if (descriptionText != null)
            descriptionText.text = description;
    }
}
