using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    public Transform _playerTransform;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void UpdateAnimation(Vector2 movement)
    {
        _animator.SetFloat("Speed", movement.y);

        if (movement.y == 0)
        {
            _animator.SetFloat("Speed", Mathf.Abs(movement.x));
            if (movement.x != 0)
            {
                transform.localScale = new Vector3(movement.x < 0 ? 0.75f : -0.75f, 0.75f, 1);
            }
        }
        else
        {
            if (movement.x > 0)
            {
                transform.localScale = new Vector3(!(movement.y < 0) ? -0.75f : 0.75f, 0.75f, 1);
            }
            else if (movement.x < 0)
            {
                transform.localScale = new Vector3(!(movement.y > 0) ? -0.75f : 0.75f, 0.75f, 1);
            }
        }
    }
}
