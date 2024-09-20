using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    int _value = 100;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.TryGetComponent(out Player player))
        {
            GameManager.Instance.Coins += _value;
            OnPickUp();
        }
    }
    void OnPickUp()
    {
        Destroy(gameObject);
    }
}
