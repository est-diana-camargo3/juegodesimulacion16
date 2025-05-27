using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    
    public Text scoreText;
    public int initialScore = 1000;
    public int pointsLostPerSecond = 20;
    public int pointsLostPerObstacle = 100;
    
    private int currentScore;
    private float timeAccumulator;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        currentScore = initialScore;
        UpdateScoreDisplay();
    }

    void Update()
    {
        timeAccumulator += Time.deltaTime;
        if (timeAccumulator >= 1f)
        {
            ModifyScore(-pointsLostPerSecond);
            timeAccumulator = 0f;
        }
    }

    public void ModifyScore(int amount)
    {
        currentScore += amount;
        if (currentScore <= 0)
        {
            currentScore = 0;
            FindObjectOfType<LifeManager>().LoseLife(false);
        }
        UpdateScoreDisplay();
    }

    public void SaveFinalScore()
    {
        PlayerPrefs.SetInt("FinalScore", currentScore);
    }

    void UpdateScoreDisplay()
    {
        if (scoreText != null)
            scoreText.text = "Puntos: " + currentScore;
    }
}