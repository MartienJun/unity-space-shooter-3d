using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeaponController : MonoBehaviour
{
    public GameObject Bullet;
    public Transform[] ShotSpawns;
    public float Delay;
    public float FireRate;

    private AudioSource Shoot;

    void Start()
    {
        Shoot = GetComponent<AudioSource>();
        InvokeRepeating("Fire", Delay, FireRate);
    }

    void Fire()
    {
        foreach (var ShotSpawn in ShotSpawns)
        {
            Instantiate(Bullet, ShotSpawn.position, ShotSpawn.rotation);
            
        }
        Shoot.Play();
    }
}


