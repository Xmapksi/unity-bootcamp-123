using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealth;

    public Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();
            Destroy(gameObject,0.80f);
        }
        else
        {
            //Play hurt animation
            animator.SetTrigger("Hurt");
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");

        animator.SetBool("isDeath",true);

    }
}
