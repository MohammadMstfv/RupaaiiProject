using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject playerPrefab;
    public GameObject ballPrefab;
    public GameObject sawBladePrefab;
    public GameObject bigSawbladePrefab;
    public Transform ballSpawnPoint;
    public Transform shoeSpawnPoint;
    public Transform bigBladeSpawnPoint;
    public int playerHealth = 3;
    public int coins = 0;
    public int highScore = 0;
    private int score = 0;

    /*void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }*/

    private void Start()
    {
        LoadData();
        SpawnPlayer();
        SpawnBall();
        SpawnBigSawblade();
    }

    private void Update()
    {
        
    }

    void SpawnPlayer()
    {
        Instantiate(playerPrefab, shoeSpawnPoint.position, Quaternion.identity);
    }

    void SpawnBall()
    {
        Instantiate(ballPrefab, ballSpawnPoint.position, Quaternion.identity);
    }
    void SpawnSawblade()
    {
        //select almost random position
        Instantiate(sawBladePrefab, Vector3.zero, Quaternion.identity);
    }
    void SpawnBigSawblade()
    {
        //select almost random position
        Instantiate(bigSawbladePrefab, bigBladeSpawnPoint.position, Quaternion.identity);
    }

    public void IncreaseScore()
    {
        score++;
        if (score > highScore)
        {
            highScore = score;
            SaveData();
        }
        Debug.Log("Score: " + score);
        UpdateUI();
    }

    public void ReduceHealth(int amount)
    {
        Debug.Log("Hit Sawblade");
        playerHealth -= amount;
        if (playerHealth <= 0)
        {
            GameOver();
        }
        Debug.Log("Health lowered");
        UpdateUI();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    void GameOver()
    {
        // Show GameOver UI and stop gameplay
        Debug.Log("Game Over");
    }

    void UpdateUI()
    {
        // Update score, coins, HP on UI
    }

    void SaveData()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.Save();
        Debug.Log("Data Saved");
    }

    void LoadData()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        coins = PlayerPrefs.GetInt("Coins", 0);
        Debug.Log("Data Loaded");
    }
}