using UnityEngine;
using UnityEngine.UI;

public class ActivadorFinal : MonoBehaviour
{
    public GameObject fondoGameOver;
    public GameObject fondoGanaste;
    public Text textoPuntuacion;

    void Start()
    {
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
        textoPuntuacion.gameObject.SetActive(true);
        textoPuntuacion.text = "Puntuación: " + PlayerPrefs.GetInt("FinalScore", 0);
    }

    void MostrarPantallaGameOver()
    {
        fondoGameOver.SetActive(true);
    }
}