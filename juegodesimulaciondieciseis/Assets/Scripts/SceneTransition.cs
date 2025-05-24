using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{
    public Image panelNegro;
    public float velocidad = 1f;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float alpha = 1f;
        while (alpha > 0f)
        {
            alpha -= Time.deltaTime * velocidad;
            panelNegro.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }

    public void CambiarEscenaConFade(string escena)
    {
        StartCoroutine(FadeYTransicion(escena));
    }

    IEnumerator FadeYTransicion(string escena)
    {
        float alpha = 0f;
        while (alpha < 1f)
        {
            alpha += Time.deltaTime * velocidad;
            panelNegro.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        SceneManager.LoadScene(escena);
    }
}