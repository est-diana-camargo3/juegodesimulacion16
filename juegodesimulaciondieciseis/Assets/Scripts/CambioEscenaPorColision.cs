using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenaPorColision : MonoBehaviour
{
    public bool esVictoria; // marcar true si es la caverna

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Guardar info si es victoria o derrota
            PlayerPrefs.SetString("Resultado", esVictoria ? "Victoria" : "Derrota");

            // Cargar la escena Fin
            SceneManager.LoadScene("Fin");
        }
    }
}
