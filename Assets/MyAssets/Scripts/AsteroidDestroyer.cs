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
                        ScoreController.Score = 0;
                        
                    }
                    if(other.CompareTag("Enemy"))
                    {
                        
                        Destroy(other.gameObject);
                        Destroy(gameObject);
                        Time.timeScale = 0;
                        GM.GameOver();
                        ScoreController.Score = 0;
                    }
                    if(other.CompareTag("Boss"))
                    {
                        
                        Destroy(other.gameObject);
                        Destroy(gameObject);
                        Time.timeScale = 0;
                        GM.GameOver();
                        ScoreController.Score = 0;
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
                        if(ScoreController.Score == 10)
                        {
                            
                            PlayerPrefs.SetInt("Score", ScoreController.Score);
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
                        ScoreController.Score = 0;
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
                        ScoreController.Score = 0;
                    }
                    if (other.CompareTag("PlayerBullet"))
                    {
                        PlayerPrefs.GetInt("Score", ScoreController.Score);
                        ScoreController.Score += 2;
                        
                        Destroy(other.gameObject);
                        Destroy(gameObject);
                        if (ScoreController.Score == 30)
                        {
                            PlayerPrefs.SetInt("Score", ScoreController.Score);
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
                        PlayerPrefs.GetInt("Score", ScoreController.Score);
                        
                        Destroy(other.gameObject);
                        BossHealth--;
                        if (BossHealth <= 0)
                        {
                            Destroy(gameObject);
                            ScoreController.Score += 100;
                            PlayerPrefs.SetInt("Score", ScoreController.Score);
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
