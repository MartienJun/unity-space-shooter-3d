using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRotater : MonoBehaviour
{
    public float Rotate;
    public Rigidbody RB;

    void Start()
    {
        RB.angularVelocity = Random.insideUnitSphere * Rotate;
    }
}
