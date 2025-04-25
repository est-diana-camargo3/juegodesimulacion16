using UnityEngine;

public class ActivadorFinal : MonoBehaviour
{
    public GameObject fondoGameOver;
    public GameObject fondoGanaste;
    public GameObject textoGanaste;

    void Start()
    {
        string resultado = PlayerPrefs.GetString("Resultado", "Derrota");

        if (resultado == "Victoria")
        {
            fondoGanaste.SetActive(true);
            textoGanaste.SetActive(true);
        }
        else
        {
            fondoGameOver.SetActive(true);
        }
    }
}
