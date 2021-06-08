using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] Asteroits;
    public Text WinText;
    public Text GameOverText;
    public Vector3 SpawnValue;
    public int AsteroitCount;
    public float SpawnWait;
    public float StartWait;
    public float WaveWait;


    private bool BossKilled;
    private bool gameOver;
    private bool Win;
    
   

    void Start()
    {
        WinText.text = "";
        GameOverText.text = "";

        BossKilled = false;
        gameOver = false;
        
        Win = false;
        
        StartCoroutine(SpawnWave());
    }

    
    private void Update()
    {
        if (gameOver)
        {
            GameOverText.text = "Press R To Restart";
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Time.timeScale = 1;
            }
            
        }

        if (Win)
        {
            WinText.text = "Press Space To Continue";
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Time.timeScale = 1;
            }
        }

        if (BossKilled)
        {
            WinText.text = "YOU WIN !";
            
        }
    }

    // Update is called once per frame
    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(StartWait);
        while (true)
        {
            GameObject Asteroit = Asteroits[Random.Range(0, Asteroits.Length)];
            for (int asteroit = 0; asteroit < AsteroitCount; asteroit++)
            {
                Vector3 SpawnPosition = new Vector3(Random.Range(
                    (-SpawnValue.x), SpawnValue.x),
                    SpawnValue.y,
                    SpawnValue.z
                );
                Quaternion SpawnRotation = Quaternion.identity;

                Instantiate(Asteroit, SpawnPosition, SpawnRotation);

                yield return new WaitForSeconds(SpawnWait);

            }

                yield return new WaitForSeconds(WaveWait);
            
        }
    }

    

    public void GameOver()
    {
        gameOver = true;
    }

    public void NextStage()
    {
        Win = true;
    }

    public void WinBoss()
    {
        BossKilled = true;
    }
}
