using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    [SerializeField]
    EnemyBase _controlledEnemy;
    [Header("Distances")]
    [SerializeField]
    float shootingDistance = 5f;
    [SerializeField]
    float runAwayDistance = 0f;
    [Header("Properties")]
    [SerializeField, Range(1f, 10f)]
    float runAwayPathing = 5f;
    [SerializeField, Range(0f, 1f)]
    float accurancy = 0.85f;
    void FixedUpdate()
    {
        Vector2 playerToEntity = (gameObject.transform.position - _controlledEnemy.Target.position);
        float entityToPlayerDistance = playerToEntity.magnitude;
        if (shootingDistance <= entityToPlayerDistance)
        {
            _controlledEnemy.MoveTo(_controlledEnemy.Target.position);
        }
        else if (runAwayDistance < entityToPlayerDistance && entityToPlayerDistance < shootingDistance)
        {
            _controlledEnemy.MoveTo(transform.position);
            //if (Mathf.Abs(Vector3.Angle(transform.forward, -playerToEntity)) < 360f * (1 - accurancy))
                _controlledEnemy.Attack();
        }
        else if (entityToPlayerDistance <= runAwayDistance)
        {
            _controlledEnemy.MoveTo((Vector2)_controlledEnemy.Target.position + playerToEntity * runAwayPathing);
        }
    }
}
