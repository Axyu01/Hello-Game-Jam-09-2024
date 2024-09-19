using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyBase : MovingEntityBase
{
    protected Transform _target;
    public Transform Target { get { return _target; } }
    [SerializeField] float _movingForce = 5f;
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] GameObject _dropedItemPrefab;
    bool _dontInstantiateDropedItem = false;
    new void Awake()
    {
        base.Awake();
        SceneManager.activeSceneChanged += ((Scene current,Scene next) => { _dontInstantiateDropedItem = true; });
        EditorApplication.playModeStateChanged += (PlayModeStateChange stateChange) =>
        {
            if(stateChange == PlayModeStateChange.ExitingPlayMode)
            {
                _dontInstantiateDropedItem = true;
            }
        };
    }
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
    public void Attack()
    {
        if (_action == null)
        {
            return;
        }
        _action.TakeAction(_target.position);
    }
    public void MoveTo(Vector2 position)
    {
        _agent.SetDestination(position);
    }
    private new void OnDestroy()
    {
        base.OnDestroy();
        if(_dropedItemPrefab != null && _dontInstantiateDropedItem == false)
        {
            Instantiate(_dropedItemPrefab,transform.position,Quaternion.identity,transform.parent);
        }
    }
}
