using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AsteroidDestroyer : MonoBehaviour
{
    
    public int BossHealth;
    private GameController GM;

    private void Start()
    {
        

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            GM = gameControllerObject.GetComponent<GameController>();
        }
        if (GM == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    


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
                        Time.timeScale = 0;
                        GM.GameOver();
                        
                    }
                    if(other.CompareTag("Enemy"))
                    {
                        
                        Destroy(other.gameObject);
                        Destroy(gameObject);
                        Time.timeScale = 0;
                        GM.GameOver();
                    }
                    if(other.CompareTag("Boss"))
                    {
                        
                        Destroy(other.gameObject);
                        Destroy(gameObject);
                        Time.timeScale = 0;
                        GM.GameOver();
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
                        ScoreController.Score += 1;
                        Destroy(other.gameObject);
                        Destroy(gameObject);
                        if(ScoreController.Score >= 10)
                        {
                            Time.timeScale = 0;
                            GM.NextStage();
                            
                        }
                        
                    }
                    if (other.CompareTag("Player"))
                    {
                        Destroy(other.gameObject);
                        Destroy(gameObject);
                        Time.timeScale = 0;
                        GM.GameOver();
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
                        Time.timeScale = 0;
                        GM.GameOver();
                    }
                    if (other.CompareTag("PlayerBullet"))
                    {
                        ScoreController.Score += 1;
                        Destroy(other.gameObject);
                        Destroy(gameObject);
                        if (ScoreController.Score == 30)
                        {
                            Time.timeScale = 0;
                            GM.NextStage();
                        }

                    }
                    if (other.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("Boss"))
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
                        BossHealth--;
                        if (BossHealth <= 0)
                        {
                            Destroy(gameObject);
                            
                            GM.WinBoss();
                            Time.timeScale = 0;
                        }
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
