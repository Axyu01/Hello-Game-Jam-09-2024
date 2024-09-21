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
        if (movement != Vector2.zero)
        {
            _animator.SetFloat("Speed", movement.y);
            
            if (movement.x != 0)
            {
                bool direction = movement.x > 0 ? false : true;
                _animator.SetBool("Direction", direction);
            }
        }
    }
}
