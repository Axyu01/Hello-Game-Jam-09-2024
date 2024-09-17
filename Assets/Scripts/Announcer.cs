using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Announcer : MonoBehaviour
{
    [SerializeField]
    Text _announcement;
    //[SerializeField]
    //AnimationCurve _fadeCurve = AnimationCurve.Linear(0f,1f,1f,0f);
    [SerializeField]
    float _fadeTime = 3f;
    float _fadeLeft = 0;
    [SerializeField]
    Gradient _gradient;

    // Update is called once per frame
    void Update()
    {
        if(_fadeLeft < 0)
        {
            _fadeLeft = 0;
        }
        else
        {
            _fadeLeft -= Time.deltaTime;
            _announcement.color = _gradient.Evaluate((_fadeTime-_fadeLeft)/_fadeTime);
        }
    }
    public void Announce(string text)
    {
        _announcement.text = text;
        _fadeLeft = _fadeTime;
    }
}
