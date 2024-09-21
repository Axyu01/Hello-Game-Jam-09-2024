using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour
{
    public Text Coins;


    void Update()
    {
        Coins.text = GameManager.Instance.Coins.ToString();
    }
}