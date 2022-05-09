using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive=0;
    public Transform spawnPoint;
    public float timeBeetweenWaves=5f;
    public Text waveCountdownText;
    private float countdown=5f;
    public GameObject basicEnemyPrefab;
    public GameObject toughEnemyPrefab;
    public GameObject fastEnemyPrefab;
    void Update()
    {
        Debug.Log(EnemiesAlive);
        if(EnemiesAlive>0)
        {
            return;
        }
        if(countdown<=0f)
        {
            StartCoroutine(SpawnWave());
            countdown=timeBeetweenWaves;
            return;
        }
        countdown-=Time.deltaTime;
        countdown=Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        
        waveCountdownText.text=string.Format("{0:00.00}",countdown);
    }
    private int basicCount=3, toughCount=0, fastCount=0;
    IEnumerator SpawnWave()
    {      
        PlayerStats.Points+=50;
        while(EnemiesAlive<=0)
        {
            StartCoroutine(SpawnBasicEnemy(basicEnemyPrefab, basicCount));
            StartCoroutine(SpawnToughEnemy(toughEnemyPrefab, toughCount));
            StartCoroutine(SpawnFastEnemy(fastEnemyPrefab, fastCount));
            yield return new WaitForSeconds(1f);
        }
 
    }
    IEnumerator SpawnBasicEnemy(GameObject enemy, int count)
    {
        for(int i=0;i<count;i++)
        {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
        yield return new WaitForSeconds(1f);
        }
        
        basicCount++;

    }
    IEnumerator SpawnToughEnemy(GameObject enemy, int count)
    {
        for(int i=0;i<count;i++)
        {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
        yield return new WaitForSeconds(1f);
        }
        
        toughCount++;
    }
    IEnumerator SpawnFastEnemy(GameObject enemy, int count)
    {
        for(int i=0;i<count;i++)
        {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
        yield return new WaitForSeconds(1f);
        }
        
        fastCount++;
    }
}
