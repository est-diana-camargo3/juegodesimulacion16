using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LifeManager : MonoBehaviour
{
    [Header("UI Config")]
    public Image[] lifeIcons;
    public Sprite fullLife;
    public Sprite emptyLife;
    
    [Header("Configuración")]
    public int vidasIniciales = 5;
    
    private int currentLives;
    private bool isInvulnerable = false;
    private float invulnerabilityTime = 2f;
    private float blinkInterval = 0.2f;
    private SpriteRenderer playerSprite;

    void Start()
    {
        currentLives = vidasIniciales;
        UpdateLivesUI();
        playerSprite = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
    }

    public void LoseLife(bool esVictoria)
{
    if (!isInvulnerable && currentLives > 0)
    {
        currentLives--;
        UpdateLivesUI();
        StartCoroutine(InvulnerabilityRoutine());

        if (currentLives <= 0 || (ScoreManager.Instance != null && ScoreManager.Instance.GetCurrentScore() <= 0))
        {
            PlayerPrefs.SetString("Resultado", esVictoria ? "Victoria" : "Derrota");
            SceneManager.LoadScene("Fin");
        }
    }
}

    // Método agregado para solucionar el error
    public int GetCurrentLives()
    {
        return currentLives;
    }

    IEnumerator InvulnerabilityRoutine()
    {
        isInvulnerable = true;
        float timer = 0f;
        bool visible = true;

        while (timer < invulnerabilityTime)
        {
            visible = !visible;
            playerSprite.enabled = visible;
            timer += blinkInterval;
            yield return new WaitForSeconds(blinkInterval);
        }

        playerSprite.enabled = true;
        isInvulnerable = false;
    }

    void UpdateLivesUI()
    {
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            lifeIcons[i].sprite = (i < currentLives) ? fullLife : emptyLife;
        }
    }

    public void ResetLives()
    {
        currentLives = vidasIniciales;
        UpdateLivesUI();
    }

    public bool IsInvulnerable()
    {
        return isInvulnerable;
    }
}