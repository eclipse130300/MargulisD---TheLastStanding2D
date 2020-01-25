using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    public bool gameIsActive;
    public bool gameOver;
    public bool startGame;
    private float countDownTimer;
    private Enemy enemyScript;
    private SpawnManager spawnManager;
    private Button restartButton;
    private int score;
    public TextMeshProUGUI scoreText;

    public GameObject enemyPref;
    public GameObject loseText;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score:" + 0;
        gameIsActive = true;
        countDownTimer = 20f;
        enemyScript = enemyPref.GetComponent<Enemy>();
        enemyScript.enemySpeed = 1;
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        countDownTimer -= Time.deltaTime;
        if (countDownTimer < 0)
        {
            countDownTimer = 20f;
            ChangeDifficulty();
        }
    }
    public void GameOver()
    {
       
        loseText.gameObject.SetActive(true);
        restartButton = GameObject.FindGameObjectWithTag("RestartButton").GetComponent<Button>();
        restartButton.onClick.AddListener(RestartGame);
    }
    void ChangeDifficulty()
    {
        enemyScript.enemySpeed++;
        spawnManager.enemiesMaxAmount++;
    }
    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LosingSecuence()
    {
        gameIsActive = false;
        Invoke("GameOver", 1f); //string ref
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score:" + score;
    }
}
