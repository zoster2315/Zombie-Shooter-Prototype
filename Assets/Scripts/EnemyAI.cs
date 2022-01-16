using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;

    [SerializeField] Color chaseRangeGizmoColor = new Color(1, 1, 0, 0.75F);

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    Animator animator;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (isProvoked)
            EngageTarget();
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
            //navMeshAgent.SetDestination(target.position);
        }
    }

    void EngageTarget()
    {
        if (distanceToTarget > navMeshAgent.stoppingDistance)
            ChaseTarget();

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
            AttackTarget();
    }

    void ChaseTarget()
    {
        if (animator != null)
        {
            animator.SetTrigger("Move");
            animator.SetBool("Attack", false);
        }
        navMeshAgent.SetDestination(target.position);
    }

    void AttackTarget()
    {
        if (animator != null)
            if (!animator.GetBool("Attack"))
            {
                animator.SetBool("Attack", true);
            }
        Debug.Log($"{name} attacked {target.name}");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = chaseRangeGizmoColor;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
