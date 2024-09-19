using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    public RectTransform CrosshairImage;
    private Canvas _canvas;

    void Start()
    {
        _canvas = GetComponentInParent<Canvas>();
    }

    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.transform as RectTransform, mousePosition, _canvas.worldCamera, out Vector2 localPoint);
        CrosshairImage.localPosition = localPoint;
    }
}
