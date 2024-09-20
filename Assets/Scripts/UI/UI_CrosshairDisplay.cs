using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    public Image CrosshairImage;
    private Canvas _canvas;

    void Start()
    {
        _canvas = GetComponentInParent<Canvas>();
    }

    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.transform as RectTransform, mousePosition, _canvas.worldCamera, out Vector2 localPoint);
        CrosshairImage.rectTransform.localPosition = localPoint;

        if (WorldSwitcher.IsChillWorldActive)
        {
            Cursor.visible = true;
            CrosshairImage.enabled = false;
        }
        else
        {
            Cursor.visible = false;
            CrosshairImage.enabled = true;
        }
    }
    void OnDestroy()
    {
        Cursor.visible = true;
    }
}
