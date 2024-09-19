using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour
{
    public Text Coins;
    public GameManager gameManager;

    void Update()
    {
        
        if (gameManager != null)
        {
            Coins.text = gameManager.Coins.ToString();
        }
    }
}