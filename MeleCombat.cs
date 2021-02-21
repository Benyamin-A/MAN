using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class MeleCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage=40;
    public LayerMask enemyLayers;
    public void OnMelee(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Attack();
        }
    }

    void Attack()
    {
        Collider[] hitEnemiesColliders=Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider enemy in hitEnemiesColliders)
        {
            Debug.Log("we hit " + enemy.name);
            enemy.GetComponent<EnemyScript>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
