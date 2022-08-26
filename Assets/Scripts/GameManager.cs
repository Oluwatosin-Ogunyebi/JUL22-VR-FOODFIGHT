using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //Add Score.
    //GetScore.
    //Set Timer.
    //Start and Reset Game.
    //Spawning Food Items to food stand.
    private float timer = 0;
    private int score;
    private bool isGameRunning = false;


    public Collider foodSpawnArea;
    public GameObject[] foodItems;
    public float gameTimer;
    public TMP_Text timerText;
    public TMP_Text scoreText;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }


    }

    private void Start()
    {
        //StartGame();
        timerText.text = "TIMER: " + gameTimer;
    }
    public bool checkGameRunning()
    {
        return isGameRunning;
    }

    public int getScore()
    {
        return score;
    }

    public int getTime()
    {
        return Mathf.FloorToInt(timer);
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "SCORE: "+ score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void StartGame()
    {
        timer = gameTimer;
        isGameRunning = true;
        ResetScore();
    }

    public void GameOver()
    {
        isGameRunning = false;
    }

    public void SpawnFoodItem()
    {
        int randomValue = Random.Range(0, foodItems.Length);
        GameObject randomFood = foodItems[randomValue];
        float x = Random.Range(foodSpawnArea.bounds.min.x, foodSpawnArea.bounds.max.x);
        float y = Random.Range(foodSpawnArea.bounds.min.y, foodSpawnArea.bounds.max.y);
        float z = Random.Range(foodSpawnArea.bounds.min.z, foodSpawnArea.bounds.max.z);

        Vector3 randomPosition = new Vector3(x, y, z);

        Instantiate(randomFood, randomPosition, Quaternion.identity);
    }

    private void Update()
    {
        Debug.Log("Score is: " + getScore());

        SetTimer();

    }

    public void SetTimer()
    {
        if (timer > 0 && isGameRunning)
        {
            timer -= Time.deltaTime;
            timerText.text = "TIMER: " + getTime();
            Debug.Log("Time is: " + getTime());
        }
        else
        {
            GameOver();
        }
    }
}
