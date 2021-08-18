using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] powerUps;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
       
        
    }
    public void StartCoroutineFunctions()
    {
        StartCoroutine(EnemySpawn());
        StartCoroutine(PowerUpSpawn());
    }
    IEnumerator EnemySpawn()
    {
        while (gameManager.gameOver==false)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-5, 5),6,0),Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
    IEnumerator PowerUpSpawn()
    {
        while (true)
        {
            int randomPowerUp = Random.Range(0, powerUps.Length);
            Instantiate(powerUps[randomPowerUp], new Vector3(Random.Range(-5, 5), 6, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
        
    }
   

}
