using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField]
    int _restoredHealth = 100;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.TryGetComponent(out Player player))
        {
            player.GetDmg(-_restoredHealth);
            OnPickUp();
        }
    }
    void OnPickUp()
    {
        Destroy(gameObject);
    }
}
