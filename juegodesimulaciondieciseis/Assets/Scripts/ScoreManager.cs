using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [Header("Configuración")]
    public int initialScore = 1000;
    public int pointsLostPerSecond = 20;
    public int pointsLostPerObstacle = 100;

    [Header("UI")]
    public Text scoreText;

    private int currentScore;
    private bool isGameActive = true;
    private float timeAccumulator = 0f;
    private const float updateFrequency = 1f; // Actualizar cada segundo

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentScore = initialScore;
        UpdateScoreDisplay();
    }

    void Update()
    {
        if (!isGameActive) return;

        timeAccumulator += Time.deltaTime;

        if (timeAccumulator >= updateFrequency)
        {
            ModifyScore(-pointsLostPerSecond);
            timeAccumulator = 0f;
        }
    }

    public void ModifyScore(int amount)
    {
        currentScore += amount;
        UpdateScoreDisplay();

        if (currentScore <= 0)
        {
            GameOver();
        }
    }

    public void ObstacleHit()
    {
        ModifyScore(-pointsLostPerObstacle);
    }

    void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = Mathf.Max(0, currentScore).ToString();
        }
    }

    void GameOver()
    {
        isGameActive = false;
        currentScore = 0;
        UpdateScoreDisplay();

        LifeManager lifeManager = FindObjectOfType<LifeManager>();
        if (lifeManager != null)
        {
            lifeManager.LoseLife(false);
        }
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }
    // Agrega esto al final de la clase ScoreManager
public void SaveFinalScore()
{
    PlayerPrefs.SetInt("FinalScore", currentScore);
    PlayerPrefs.Save();
}

public int LoadFinalScore()
{
    return PlayerPrefs.GetInt("FinalScore", 0);
}
}