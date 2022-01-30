using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    float hitPoints = 100f;

    Animator animator;
    bool isDead = false;

    public bool IsDead { get { return isDead; } }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Die();
            
        }
    }

    void Die()
    {
        if (isDead)
            return;
        isDead = true;
        animator.SetTrigger("Die");
    }
}
