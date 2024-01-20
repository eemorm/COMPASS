using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{

    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public MeleeWeaponData weaponData;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public AudioSource attackSource;
    public AudioClip attackClip;
    public Canvas inventorypanel;
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                attackSource.PlayOneShot(attackClip);
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

        if (inventorypanel.enabled)
        {
            attackSource.enabled = false;
        }
        else
        {
            attackSource.enabled = true;
        }
    }

    void Attack()
    {
        // Play the melee attack animation
        animator.Play(weaponData.meleeAttackAnimation.name);

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<EnemyHealth>().TakeDamage(weaponData.damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
