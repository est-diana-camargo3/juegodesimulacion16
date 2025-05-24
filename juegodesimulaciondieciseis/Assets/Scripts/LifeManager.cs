using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LifeManager : MonoBehaviour
{
    public Image[] lifeIcons;
    public Sprite fullLife;
    public Sprite emptyLife;
    public bool esVictoria = false;

    private int currentLives = 5;
    private bool isInvulnerable = false;
    private float invulnerabilityTime = 2f;
    private float blinkInterval = 0.2f;
    private SpriteRenderer playerSprite;

    void Start()
    {
        playerSprite = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        UpdateLivesUI();
    }

    public void LoseLife(bool isObstacle)
    {
        if (!isInvulnerable && currentLives > 0)
        {
            currentLives--;
            UpdateLivesUI();
            StartCoroutine(InvulnerabilityRoutine());

            if (currentLives <= 0)
            {
                PlayerPrefs.SetString("Resultado", "Derrota");
                SceneManager.LoadScene("Fin");
            }
        }
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

    public int GetCurrentLives()
    {
        return currentLives;
    }

     void UpdateLivesUI()
    {
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            lifeIcons[i].sprite = (i < currentLives) ? fullLife : emptyLife;
        }
    }

    public bool IsInvulnerable()
    {
        return isInvulnerable;
    }
}