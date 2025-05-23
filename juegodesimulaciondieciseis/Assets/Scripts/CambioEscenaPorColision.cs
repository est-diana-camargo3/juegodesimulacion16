using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenaPorColision : MonoBehaviour
{
    [Header("Configuración de Escenas")]
    public string escenaGameOver = "GameOverScene";
    public string escenaFinal = "Fin"; // Escena que muestra ambos resultados
    
    [Header("Referencias")]
    public LifeManager lifeManager;
    public SceneTransition controladorDeTransicion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo") && !lifeManager.IsInvulnerable())
        {
            lifeManager.LoseLife(false);
            ScoreManager.Instance?.ObstacleHit();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NivelDos"))
        {
            CargarEscenaFinal(true); // True para Victoria
        }
    }

    private void CargarEscenaFinal(bool esVictoria)
{
    if (esVictoria)
    {
        ScoreManager.Instance?.SaveFinalScore();
    }
    
    PlayerPrefs.SetString("Resultado", esVictoria ? "Victoria" : "Derrota");
    PlayerPrefs.Save();
    
    if (controladorDeTransicion != null)
    {
        controladorDeTransicion.CambiarEscenaConFade(escenaFinal);
    }
    else
    {
        SceneManager.LoadScene(escenaFinal);
    }
}
}