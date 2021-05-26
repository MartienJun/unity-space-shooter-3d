using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestroyer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        switch (gameObject.tag)
        {
            case "Player":
                {
                    if(other.CompareTag("Asteroid"))
                    {
                        
                        Destroy(other.gameObject);
                        Destroy(gameObject);
                    }
                    if(other.CompareTag("Enemy"))
                    {
                        
                        Destroy(other.gameObject);
                        Destroy(gameObject);
                    }
                    if(other.CompareTag("Boss"))
                    {
                        
                        Destroy(other.gameObject);
                        Destroy(gameObject);
                    }
                    if (other.CompareTag("Boundary"))
                    {
                        return;
                    }
                }
                break;
            case "Asteroid":
                {
                    if(other.CompareTag("PlayerBullet"))
                    {
                        
                        Destroy(other.gameObject);
                        Destroy(gameObject);
                    }
                    if (other.CompareTag("Player"))
                    {
                        
                        Destroy(other.gameObject);
                        Destroy(gameObject);
                    }
                    if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
                    {
                        return;
                    }
                }
                break;
            case "Enemy":
                {
                    if(other.CompareTag("Player"))
                    {
                        
                        Destroy(other.gameObject);
                        Destroy(gameObject);
                    }
                    if (other.CompareTag("PlayerBullet"))
                    {
                        
                        Destroy(other.gameObject);
                        Destroy(gameObject);
                    }
                    if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
                    {
                        return;
                    }
                }
                break;
            case "Boss":
                {
                    if (other.CompareTag("PlayerBullet"))
                    {
                        
                        Destroy(other.gameObject);
                        Destroy(gameObject);
                    }
                    if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
                    {
                        return;
                    }

                }
                
                break;
        }
        /*if(other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }
        
        Destroy(other.gameObject);
        Destroy(gameObject);*/
    }
}
