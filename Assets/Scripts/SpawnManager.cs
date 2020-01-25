using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Camera cam;
    public GameObject enemyPref;
    public int enemiesMaxAmount;
    public int enemyCount;
    Vector2 enemySpawnPosition;
    private float enemiesSpawnPositionX;
    private float xSpawnRange;
    private float enemiesSpawnPositionY;
    private bool isAbleToInvoke = true;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        enemiesMaxAmount = 5;
        // data to spawn enemies just outside the boarders of a camera
        xSpawnRange = cam.orthographicSize * cam.aspect -2; //width
        enemiesSpawnPositionY = cam.orthographicSize + 1; //height
        
    }

    // Update is called once per frame
    void Update()
    {  
        //counts enemy, spawns wave based on the count
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && isAbleToInvoke)
        {
                Invoke("SpawnEnemyWave", 2f); // string ref
                isAbleToInvoke = false;  
        }
    }
    public void SpawnEnemyWave()
    {
        if (gm.gameIsActive)
        {
            for (enemyCount = 0; enemyCount < enemiesMaxAmount; enemyCount++)
            {
                enemiesSpawnPositionX = Random.Range(-xSpawnRange, xSpawnRange);
                enemySpawnPosition = new Vector2(enemiesSpawnPositionX, enemiesSpawnPositionY);
                Instantiate(enemyPref, enemySpawnPosition, enemyPref.transform.rotation);
                if (enemyCount == enemiesMaxAmount - 1)
                {
                    isAbleToInvoke = true;
                }
            }
        }
    }
}
