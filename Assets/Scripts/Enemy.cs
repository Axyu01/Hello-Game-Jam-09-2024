using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float force = 5f;
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();   
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.updatePosition = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        agent.SetDestination(target.position);
        if (agent.path.corners.Length > 0)
        {
            rb.AddForce(((Vector2)(agent.path.corners[0] - transform.position)).normalized * force,ForceMode2D.Force);
        }
        agent.nextPosition = transform.position;
    }
}
