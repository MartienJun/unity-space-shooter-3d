using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public float Speed;
    public Rigidbody RB;
    
    void Start()
    {
        RB.velocity = transform.forward * Speed;
    }
}
