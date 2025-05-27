using UnityEngine;

public class PlataformaResortada : MonoBehaviour
{
    private float masa = 1f;        // Masa de la plataforma
    private float k = 5f;          // Constante del resorte
    private float b = 0.2f;           // Coeficiente de amortiguamiento
    private float destinoX = 140f;  // Cuánto se desplaza inicialmente
    
    private float xac1, xac2, yac1, yac2, xaux, yaux;
    private bool mover = false;
    private float tiempoDeteccionM = 0f;
    private bool colisionDetectadaM = false;

    private float x;   // Posición (desplazamiento desde el centro)
    private float v;   // Velocidad
    //private float a;   // Aceleración
    private Vector2 posicionInicial;

    public GameObject Ob1, PMovil;

    void Start()
    {
        PMovil = GameObject.Find("Pmovil1");
        posicionInicial = PMovil.transform.position;
        x = posicionInicial.x; // Empieza desplazada a la derecha
    }

    void Update()
    {
        xac1 = Ob1.transform.position.x;
        yac1 = Ob1.transform.position.y;
        xac2 = PMovil.transform.position.x;
        yac2 = PMovil.transform.position.y;
        Renderer M1 = PMovil.GetComponent<Renderer>();

        xaux = Mathf.Abs(xac1 - xac2);
        yaux = Mathf.Abs(yac1 - yac2);

        // Detecta si el personaje pisa el obstáculo
        if (!colisionDetectadaM && xaux <= M1.bounds.size.x / 2 && yaux <= 2.5)
        {
            colisionDetectadaM = true;
            tiempoDeteccionM = Time.time; // Guardamos el tiempo actual
        }

        // Después de 1 segundo desde la colisión, activar la caída
        if (colisionDetectadaM && !mover && Time.time >= tiempoDeteccionM + 1f)
        {
            mover = true;
        }

        if (mover)
        {
            // Desplazamiento desde la posición objetivo
            float desplazamiento = x - destinoX;

            // Fuerza del resorte (restauradora hacia el destino)
            float fuerza = -k * desplazamiento - b * v;

            // Aceleración
            float a = fuerza / masa;

            // Integración por Euler
            v += a * Time.deltaTime;
            x += v * Time.deltaTime;

            // Aplicar la nueva posición
            transform.position = new Vector2(x, posicionInicial.y);
        }
    }
}



/*
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class Mov_Resortado : MonoBehaviour
{
    public float F, B, M, K;
    private float A, V, X, xpo = 0, h = 0.1f, xo, xac1, xac2, yac1, yac2, xaux, yaux;
    Vector2 PosPlat = Vector2.zero, PosiVel = Vector2.zero, K1 = Vector2.zero, K2 = Vector2.zero, K3 = Vector2.zero, K4 = Vector2.zero;
    private bool mover = false;
    private float tiempoDeteccionM = 0f;
    private bool colisionDetectadaM = false;
    public GameObject Ob1, PMovil;

    // Start is called before the first frame update
    void Start()
    {
        PMovil = GameObject.Find("Pmovil1");
        PosiVel.x = PMovil.transform.position.x;
        PosiVel.y = xpo;
        PosPlat.x = PMovil.transform.position.x;
        PosPlat.y = PMovil.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        xac1 = Ob1.transform.position.x;
        yac1 = Ob1.transform.position.y;
        xac2 = PMovil.transform.position.x;
        yac2 = PMovil.transform.position.y;
        Renderer M1 = PMovil.GetComponent<Renderer>();

        xaux = Mathf.Abs(xac1 - xac2);
        yaux = Mathf.Abs(yac1 - yac2);

        // Detecta si el personaje pisa el obstáculo
        if (!colisionDetectadaM && xaux <= M1.bounds.size.x / 2 && yaux <= 2.5)
        {
            colisionDetectadaM = true;
            tiempoDeteccionM = Time.time; // Guardamos el tiempo actual
        }

        // Después de 1 segundo desde la colisión, activar la caída
        if (colisionDetectadaM && !mover && Time.time >= tiempoDeteccionM + 1f)
        {
            mover = true;
        }

        if (mover)
        {
            A = (F - (K * PosiVel.x) - (B * PosiVel.y)) / M;
            V = PosiVel.y + (A * Time.deltaTime);
            X = PosiVel.x + (V * Time.deltaTime);
            PosiVel.x = X;
            PosiVel.y = V;
            PosPlat.x = PosiVel.x;
            PMovil.transform.position = PosPlat;
        }
    }
}
*/