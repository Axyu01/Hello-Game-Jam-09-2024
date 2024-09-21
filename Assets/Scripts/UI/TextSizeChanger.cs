using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSizeChanger : MonoBehaviour
{

    public Text uiText;
    public float AnimationDuration = 0.4f;
    public float enlargedFontSize = 20f;

    private int _originalFontSize;
    private string _lastvalue;

    void Start()
    {
        _originalFontSize = uiText.fontSize;
        _lastvalue = uiText.text;
    }

    void Update()
    {
        if (uiText.text != _lastvalue)
        {
            _lastvalue = uiText.text;
            StartCoroutine(AnimateText());
        }
    }

    private IEnumerator AnimateText()
    {
        float elapsedTime = 0f;
        while (elapsedTime < AnimationDuration)
        {
            float t = elapsedTime / AnimationDuration;
            uiText.fontSize = (int)Mathf.Lerp(_originalFontSize, (int)enlargedFontSize, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        uiText.fontSize = (int)enlargedFontSize;
        yield return new WaitForSeconds(0.1f);

        elapsedTime = 0f;
        while( elapsedTime < AnimationDuration)
        {
            float t = elapsedTime / AnimationDuration;
            uiText.fontSize = (int)Mathf.Lerp(enlargedFontSize, (int)_originalFontSize, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        uiText.fontSize = _originalFontSize;
    }

    public void UpdateText(string newText)
    {
        uiText.text = newText;
    }
}
