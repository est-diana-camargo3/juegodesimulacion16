using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
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
    
    public Image panelNegro;
    public float velocidad = 1f;

    public void CambiarEscenaConFade(string nuevaEscena)
    {
        StartCoroutine(FadeYTransicion(nuevaEscena));
    }

    IEnumerator FadeYTransicion(string escena)
    {
        // Fade to black
        float alpha = 0f;
        while (alpha < 1f)
        {
            alpha += Time.deltaTime * velocidad;
            panelNegro.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        // Cambiar de escena
        SceneManager.LoadScene(escena);
    }
}
