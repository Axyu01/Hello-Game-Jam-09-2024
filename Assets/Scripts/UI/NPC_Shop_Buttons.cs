using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC_Shop_Buttons : MonoBehaviour
{
    [SerializeField]
    Button _button;
    [SerializeField]
    Image _image;
    

    public void AfterBuy()
    {



        _button.interactable = false;
        Color c = _image.color;
        c.a = 0.2f;
        _image.color = c;

    }

   
}
