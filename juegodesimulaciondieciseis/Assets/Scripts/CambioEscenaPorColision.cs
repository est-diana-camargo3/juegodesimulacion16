using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenaPorColision : MonoBehaviour
{
    public LifeManager lifeManager;
    public SceneTransition sceneTransition;
    public string escenaFinal = "Fin";
    private bool isInvulnerable = false;
    public GameObject Coco1, Coco2, Coco3, Coco4, Coco5;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isInvulnerable = lifeManager.isInvulnerable;
        if (collision.gameObject.CompareTag("Obstaculo") && !isInvulnerable)
        {
            lifeManager.LoseLife(true);
            ScoreManager.Instance.ModifyScore(-100);
        }
        if (collision.gameObject.CompareTag("NivelDos"))
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Coco1 = GameObject.Find("Coco1");
        Coco2 = GameObject.Find("Coco2");
        Coco3 = GameObject.Find("Coco3");
        Coco4 = GameObject.Find("Coco4");
        Coco5 = GameObject.Find("Coco5");

        if (collision.gameObject.name == "Coco1")
        {
            Coco1.SetActive(false);
            ScoreManager.Instance.ModifyScore(200);
        }
        if (collision.gameObject.name == "Coco2")
        {
            Coco2.SetActive(false);
            ScoreManager.Instance.ModifyScore(200);
        }
        if (collision.gameObject.name == "Coco3")
        {
            Coco3.SetActive(false);
            ScoreManager.Instance.ModifyScore(200);
        }
        if (collision.gameObject.name == "Coco4")
        {
            Coco4.SetActive(false);
            ScoreManager.Instance.ModifyScore(200);
        }
        if (collision.gameObject.name == "Coco5")
        {
            Coco5.SetActive(false);
            ScoreManager.Instance.ModifyScore(200);
        }
    }
}