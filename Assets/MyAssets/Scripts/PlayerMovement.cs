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
    public float Tilt;
    public GameObject Laser;
    public Transform LaserSpawn;
    public float FireRate;
    private float NextFire;

    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && Time.time > NextFire)
        {
            NextFire = Time.time + FireRate;
            Instantiate(Laser, LaserSpawn.position, LaserSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }

    void FixedUpdate()
    {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");
        
        Vector3 Movement = new Vector3(MoveHorizontal, 0.0f, MoveVertical);
        RB.velocity = Movement * Speed;
        
        RB.rotation = Quaternion.Euler(0.0f, 0.0f, RB.velocity.x * (-Tilt));

        RB.position = new Vector3(
            Mathf.Clamp(RB.position.x, Border.xMin, Border.xMax),
            0.0f,
            Mathf.Clamp(RB.position.z, Border.zMin, Border.zMax)
        );
    }
}
