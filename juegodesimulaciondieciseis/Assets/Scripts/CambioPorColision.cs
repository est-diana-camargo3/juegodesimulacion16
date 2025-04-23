using UnityEngine;

public class CambioPorColision : MonoBehaviour
{
    public SceneTransition controladorDeTransicion;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GameOver"))
        {
            controladorDeTransicion.CambiarEscenaConFade("GameOverScene");
        }
        else if (other.gameObject.CompareTag("NivelDos"))
        {
            controladorDeTransicion.CambiarEscenaConFade("Nivel2Scene");
        }
    }
}
