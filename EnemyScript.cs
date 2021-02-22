using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth<=0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("enemy died.");

        GetComponent<Collider>().enabled = false;
        this.enabled = false;
        Destroy(gameObject);
    }
}

