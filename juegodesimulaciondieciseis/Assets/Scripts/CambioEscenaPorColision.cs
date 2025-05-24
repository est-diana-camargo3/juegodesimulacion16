using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenaPorColision : MonoBehaviour
{
    public LifeManager lifeManager;
    public SceneTransition sceneTransition;
    public string escenaFinal = "Fin";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo") && !lifeManager.IsInvulnerable())
        {
            lifeManager.LoseLife(true);
            ScoreManager.Instance.ModifyScore(-100);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NivelDos"))
        {
            lifeManager.esVictoria = true;
            ScoreManager.Instance.SaveFinalScore();
            PlayerPrefs.SetString("Resultado", "Victoria");
            
            if (sceneTransition != null)
                sceneTransition.CambiarEscenaConFade(escenaFinal);
            else
                SceneManager.LoadScene(escenaFinal);
        }
    }
}