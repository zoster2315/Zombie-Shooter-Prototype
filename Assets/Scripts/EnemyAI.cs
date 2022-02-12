using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;

    [SerializeField] Color chaseRangeGizmoColor = new Color(1, 1, 0, 0.75F);

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    Animator animator;
    EnemyHealth enemyHealth;
    Transform target;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>().gameObject.transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth.IsDead)
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }
        distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (isProvoked)
            EngageTarget();
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
            //navMeshAgent.SetDestination(target.position);
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    void EngageTarget()
    {
        FaceTarget();
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
        if (navMeshAgent.enabled)
            navMeshAgent.SetDestination(target.position);
    }

    void AttackTarget()
    {
        if (animator != null)
            if (!animator.GetBool("Attack"))
            {
                animator.SetBool("Attack", true);
            }
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = chaseRangeGizmoColor;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
