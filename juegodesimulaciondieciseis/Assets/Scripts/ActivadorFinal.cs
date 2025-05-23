using UnityEngine;
using UnityEngine.UI;

public class ActivadorFinal : MonoBehaviour
{
    [Header("Elementos UI")]
    public GameObject fondoGameOver;
    public GameObject fondoGanaste;
    public Text textoPuntuacion; // Agrega este campo

    void Start()
    {
        // Ocultar ambos al inicio
        fondoGameOver.SetActive(false);
        fondoGanaste.SetActive(false);

        string resultado = PlayerPrefs.GetString("Resultado", "Derrota");

        if (resultado == "Victoria")
        {
            MostrarPantallaVictoria();
        }
        else
        {
            MostrarPantallaGameOver();
        }
    }

    void MostrarPantallaVictoria()
    {
        fondoGanaste.SetActive(true);
        fondoGameOver.SetActive(false);
        
        // Mostrar puntuación final
        if (textoPuntuacion != null)
        {
            int puntuacionFinal = PlayerPrefs.GetInt("FinalScore", 0);
            textoPuntuacion.text = puntuacionFinal.ToString();
        }
    }

    void MostrarPantallaGameOver()
    {
        fondoGameOver.SetActive(true);
        fondoGanaste.SetActive(false);
    }
}