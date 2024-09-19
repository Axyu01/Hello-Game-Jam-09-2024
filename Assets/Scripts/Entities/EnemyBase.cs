using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MovingEntityBase
{
    protected Transform _target;
    [SerializeField] float _movingForce = 5f;
    [SerializeField] NavMeshAgent _agent;
    new void Start()
    {
        base.Start();
        _target = GameManager.Instance.FightWorldPlayer.transform;
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
        UpdateBehaviour();
        _agent.SetDestination(_target.position);
        if (_agent.path.corners.Length > 0)
        {
            Rigidbody.AddForce(((Vector2)(_agent.path.corners[0] - transform.position)).normalized * _movingForce,ForceMode2D.Force);
        }
        _agent.nextPosition = transform.position;
    }
    private void Update()
    {
        if(_target != null)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, _target.transform.position - transform.position);
        }       
    }
    public virtual void UpdateBehaviour()
    {
        if (_action == null)
        {
            return;
        }
        if ((_target.position - transform.position).magnitude < 4f && _action.OnCooldown == false)
        {
            _action.TakeAction(_target.position);
        }
    }
}
