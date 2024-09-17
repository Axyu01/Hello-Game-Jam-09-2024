using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MovingEntityBase
{
    [SerializeField] Transform _target;
    [SerializeField] float _movingForce = 5f;
    [SerializeField] NavMeshAgent _agent;
    new void Start()
    {
        base.Start();
        _health = _maxHealth;
        if (_agent == null)
        {
            _agent = GetComponent<NavMeshAgent>();
        }
        if (_agent == null)
        {
            Debug.LogError("Missing NavMeshAgent Component!");
        }
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _agent.updatePosition = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _agent.SetDestination(_target.position);
        if (_agent.path.corners.Length > 0)
        {
            Rigidbody.AddForce(((Vector2)(_agent.path.corners[0] - transform.position)).normalized * _movingForce,ForceMode2D.Force);
        }
        _agent.nextPosition = transform.position;
    }
    public virtual void UpdateBehaviour()
    {

    }
}
