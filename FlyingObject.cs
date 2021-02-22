using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObject : MonoBehaviour
{
    
    public float speed=15f;
    public Rigidbody rB;
    public LayerMask enemyLayers;
    public int attackDamage=20;
    private Vector3 halfExtends = new Vector3(0.5f, 0.05f, 0.5f);

    void Start()
    {
        rB.velocity = transform.right * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        ArrowHit();
    }
    void ArrowHit()
    {
        Collider[] hitEnemiesColliders = Physics.OverlapBox(this.transform.position, halfExtends, rB.transform.rotation,enemyLayers);
        foreach (Collider enemy in hitEnemiesColliders)
        {
            Debug.Log("we hit " + enemy.name);
            enemy.GetComponent<EnemyScript>().TakeDamage(attackDamage);
        }
    }

}
