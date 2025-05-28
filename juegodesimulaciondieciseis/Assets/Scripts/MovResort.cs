using UnityEngine;

public class PlataformaResortada : MonoBehaviour
{
    private float masa = 1f;        // Masa de la plataforma
    private float k = 5f;          // Constante del resorte
    private float b = 0.2f;           // Coeficiente de amortiguamiento
    private float destinoX1 = 140f;  // Cuánto se desplaza inicialmente
    private float destinoX2 = 320f;  // Cuánto se desplaza inicialmente

    private float xac1, yac1;
    private float xac2, yac2, xauxM2, yauxM2; //Pmovil1
    private float xac3, yac3, xauxM3, yauxM3; //Pmovil2
    private bool mover1 = false;
    private bool mover2 = false;
    private float tiempoDeteccionM = 0f;
    private bool colisionDetectadaM1 = false;
    private bool colisionDetectadaM2 = false;

    private float x1, x2;   // Posición (desplazamiento desde el centro)
    private float v1, v2;   // Velocidad
    //private float a;   // Aceleración
    private Vector2 posicionInicial1, posicionInicial2;

    public GameObject Ob1, PMovil1, PMovil2;

    void Start()
    {
        Ob1 = GameObject.Find("Mono");
        PMovil1 = GameObject.Find("Pmovil1");
        PMovil2 = GameObject.Find("Pmovil2");
        posicionInicial1 = PMovil1.transform.position;
        posicionInicial2 = PMovil2.transform.position;
        x1 = posicionInicial1.x; 
        x2 = posicionInicial2.x; 
    }

    void Update()
    {
        xac1 = Ob1.transform.position.x;
        yac1 = Ob1.transform.position.y;

        xac2 = PMovil1.transform.position.x;
        yac2 = PMovil1.transform.position.y;

        xac3 = PMovil2.transform.position.x;
        yac3 = PMovil2.transform.position.y;

        Renderer M1 = PMovil1.GetComponent<Renderer>();
        Renderer M2 = PMovil2.GetComponent<Renderer>();

        xauxM2 = Mathf.Abs(xac1 - xac2);
        yauxM2 = Mathf.Abs(yac1 - yac2);

        xauxM3 = Mathf.Abs(xac1 - xac3);
        yauxM3 = Mathf.Abs(yac1 - yac3);

        // Detecta si el personaje pisa la plataforma movil 1
        if (!colisionDetectadaM1 && xauxM2 <= M1.bounds.size.x / 2 && yauxM2 <= 2.5)
        {
            colisionDetectadaM1 = true;
            tiempoDeteccionM = Time.time; // Guardamos el tiempo actual
        }

        // Después de 1 segundo desde la colisión, activar la caída
        if (colisionDetectadaM1 && !mover1 && Time.time >= tiempoDeteccionM + 1f)
        {
            mover1 = true;
        }

        // Detecta si el personaje pisa la plataforma movil 2
        if (!colisionDetectadaM2 && xauxM3 <= M2.bounds.size.x / 2 && yauxM3 <= 2.5)
        {
            colisionDetectadaM2 = true;
            tiempoDeteccionM = Time.time; // Guardamos el tiempo actual
        }

        // Después de 1 segundo desde la colisión, activar la caída
        if (colisionDetectadaM2 && !mover2 && Time.time >= tiempoDeteccionM + 1f)
        {
            mover2 = true;
        }

        if (mover1)
        {
            // Desplazamiento desde la posición objetivo
            float desplazamiento = x1 - destinoX1;

            // Fuerza del resorte (restauradora hacia el destino)
            float fuerza = -k * desplazamiento - b * v1;

            // Aceleración
            float a = fuerza / masa;

            // Integración por Euler
            v1 += a * Time.deltaTime;
            x1 += v1 * Time.deltaTime;

            // Aplicar la nueva posición
            PMovil1.transform.position = new Vector2(x1, posicionInicial1.y);
        }

        if (mover2)
        {
            // Desplazamiento desde la posición objetivo
            float desplazamiento = x2 - destinoX2;

            // Fuerza del resorte (restauradora hacia el destino)
            float fuerza = -k * desplazamiento - b * v2;

            // Aceleración
            float a = fuerza / masa;

            // Integración por Euler
            v2 += a * Time.deltaTime;
            x2 += v2 * Time.deltaTime;

            // Aplicar la nueva posición
            PMovil2.transform.position = new Vector2(x2, posicionInicial2.y);
        }
    }
}