using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestroyer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boundary")
        {
            return;
        }

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
