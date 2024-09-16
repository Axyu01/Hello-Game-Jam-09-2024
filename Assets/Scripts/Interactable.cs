using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool IsInRange;
    [SerializeField]
    KeyCode _interactKey;
    public UnityEvent InteractAction;

    void Update()
    {
        if (IsInRange) 
        {
            if (Input.GetKeyDown(_interactKey))
            {
                InteractAction.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsInRange = true;
            Debug.Log("in range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsInRange = false;
        Debug.Log("out of range");
    }
}
