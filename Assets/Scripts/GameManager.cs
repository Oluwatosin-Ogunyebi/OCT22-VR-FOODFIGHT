using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Add Score
    // Set Timer
    //Spawning New Food Items
    //Manage our Game state

    //public AudioSource audioSource;

    public static GameManager Instance;
    public Collider foodSpawnArea;
    public GameObject[] foodItems;

    private float timer = 0;
    private int score;
    private bool isGameRunning = false;

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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getScore()
    {
        return score;
    }

    public bool checkGame()
    {
        return isGameRunning;
    }

    public int getTimer()
    {
        return Mathf.FloorToInt(timer);
    }

    public void AddScore()
    {
        score++;
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
}
