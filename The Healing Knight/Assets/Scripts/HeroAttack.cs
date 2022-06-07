using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    private bool attack = false ;
    private Animator anim;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 40;

    void Start()
    {
        attack = false;
    }

    private void Awake() 
    {
        anim = GetComponent<Animator>();
    }//Awake

    public void Attack()
    {
        attack = true;

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }

    public void StopAttack()
    {
        attack = false;
    }

    void Update()
    {
        anim.SetBool("attack", attack != false);

        if(attack == true)
        {
            anim.SetTrigger("attack");
        }
    }

    private void OnDrawGizmosSelected() 
    {
        if(attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
