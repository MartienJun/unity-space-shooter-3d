using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public Rigidbody RB;
    public Boundary Border;

    // Update is called once per frame
    void FixedUpdate()
    {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");
        
        Vector3 Movement = new Vector3(MoveHorizontal, 0.0f, MoveVertical);
        RB.velocity = Movement * Speed;

        RB.position = new Vector3(
            Mathf.Clamp(RB.position.x, Border.xMin, Border.xMax),
            0.0f,
            Mathf.Clamp(RB.position.z, Border.zMin, Border.zMax)
        );
    }
}
