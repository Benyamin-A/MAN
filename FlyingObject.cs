using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObject : MonoBehaviour
{
    public float speed=15f;
    public Rigidbody2D rB;
    void Start()
    {
        rB.velocity = transform.right * speed;
    }

}
