using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyBase : MovingEntityBase
{
    protected static List<EnemyBase> Enemies = new List<EnemyBase>();
    protected EntityBase _target;
    public EntityBase Target { get { return _target; } }
    [SerializeField] float _movingForce = 5f;
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] GameObject _dropedItemPrefab;
    bool _dontInstantiateDropedItem = false;
    [SerializeField]
    float _peerMinimalDistance = 2f;
    List<EnemyBase> _nearbyPeers = new List<EnemyBase>();
    new void Awake()
    {
        base.Awake();
        Enemies.Add(this);
    }
    new void Start()
    {
        base.Start();
        StartCoroutine(FindNearbyPeers());
        _target = GameManager.Instance.FightWorldPlayer;
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
    new void FixedUpdate()
    {
        base.FixedUpdate();
        Vector2 socialDistancing = CalculateSocialDistancing();
        if (_agent.path.corners.Length > 0)
        {
            Rigidbody.AddForce((((Vector2)(_agent.path.corners[0] - transform.position)).normalized +socialDistancing.normalized).normalized * _movingForce,ForceMode2D.Force);
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
        _action.TakeAction(_target.transform.position,_target);
    }
    public void MoveTo(Vector2 position)
    {
        _agent.SetDestination(position);
    }
    public override void DestroyThisEntity()
    {
        if (_dropedItemPrefab != null)
        {
            Instantiate(_dropedItemPrefab, transform.position, Quaternion.identity, transform.parent);
        }
        base.DestroyThisEntity();
    }
    private new void OnDestroy()
    {
        base.OnDestroy();
        Enemies.Remove(this);
    }
    public static int EnemiesOverallCount()
    {
        return Enemies.Count;
    }
    IEnumerator FindNearbyPeers()
    {
        while (true)
        {
            RaycastHit2D[] hits = new RaycastHit2D[4];
            hits = Physics2D.CircleCastAll((Vector2)transform.position, _peerMinimalDistance, (Vector2)transform.position, 0f, 1 << gameObject.layer);
            _nearbyPeers = new List<EnemyBase>();
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider.TryGetComponent(out EnemyBase peer) && peer != this)
                {
                    _nearbyPeers.Add(peer);
                }
            }
            /*
            List<EnemyBase> peers = new List<EnemyBase>();
            foreach (var peer in Enemies)
            {
                if (peer != this)
                    peers.Add(peer);
            }
            */

            yield return new WaitForSeconds(5f);
        }
    }
    public Vector2 CalculateSocialDistancing()
    {
        return Vector2.zero;
        Vector2 socialDistancing = Vector2.zero;
        foreach (var peer in _nearbyPeers)
        {
            Vector2 addedDistancing = transform.position - peer.transform.position;
            if (addedDistancing.magnitude > _peerMinimalDistance)
            {
                addedDistancing = Vector2.zero;
            }
            else
            {
                addedDistancing = (_peerMinimalDistance - addedDistancing.magnitude) * addedDistancing.normalized;
            }
            socialDistancing += addedDistancing;
        }
        return socialDistancing.normalized;
    }
}
