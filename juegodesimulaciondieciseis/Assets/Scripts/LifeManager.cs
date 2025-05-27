using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
public class LifeManager : MonoBehaviour
{
    public Image[] lifeIcons;
    public Sprite fullLife;
    public Sprite emptyLife;
    public bool esVictoria = false;

    private int currentLives = 5;
    public bool isInvulnerable = false;
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
    void Update()
    {
        CheckPlayerOutOfBounds();
    }

    void CheckPlayerOutOfBounds()
    {
        if (playerSprite == null) return;

        Vector3 viewportPos = Camera.main.WorldToViewportPoint(playerSprite.transform.position);

        if ( viewportPos.y < 0 || viewportPos.y > 1) //(viewportPos.x < 0 || viewportPos.x > 1 ||
        {
            // Forzar derrota solo si aún no se ha activado
            if (currentLives > 0)
            {
                currentLives = 0;
                UpdateLivesUI();
                PlayerPrefs.SetString("Resultado", "Derrota");
                SceneManager.LoadScene("Fin");
            }
        }
    }
}