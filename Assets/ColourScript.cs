using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourScript : MonoBehaviour
{
    public Image green1;
    public Image green2;
    public Image red1;
    public Image red2;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("This is a message to the console!");
        if (WorldSwitcher.IsChillWorldActive)
        {
            Debug.Log("T");
            green1.enabled = true;
            green2.enabled = true;
            red1.enabled = false;  
            red2.enabled = false;
        }
        else
        {
            Debug.Log("F");
            green1.enabled = false;
            green2.enabled = false;
            red1.enabled = true;
            red2.enabled = true;
        }
    }
}
