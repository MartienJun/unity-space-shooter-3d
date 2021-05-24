using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] Asteroits;
    public Vector3 SpawnValue;
    public int AsteroitCount;
    public float SpawnWait;
    public float StartWait;
    public float WaveWait;

    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    // Update is called once per frame
    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(StartWait);
        while(true)
        {
            GameObject Asteroit = Asteroits[Random.Range(0, Asteroits.Length)];
            for(int asteroit = 0; asteroit < AsteroitCount; asteroit++)
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
}
