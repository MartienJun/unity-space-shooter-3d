﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject Bullet;
    public Transform ShotSpawn;
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
        Instantiate(Bullet, ShotSpawn.position, ShotSpawn.rotation);
        Shoot.Play();
    }
}
