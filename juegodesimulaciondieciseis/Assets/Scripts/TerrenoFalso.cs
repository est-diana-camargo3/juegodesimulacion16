using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TerrenoFalso : MonoBehaviour
{
    private float vo = 0f, g = 9.81f, Cm, C = 1.3f;
    public float vac, yac, tac, m, xac1, xac2, yac1, yac2, xaux, yaux;
    private bool caer = false;
    private float tiempoDeteccion = 0f;
    private bool colisionDetectada = false;
    Vector2 Pos = Vector2.zero;
    public GameObject Ob1, Ob2;

    void Start()
    {
        Ob1 = GameObject.Find("Mono");
        Ob2 = GameObject.Find("SueloFalso1");

        Cm = C / m;
        vac = 0;
        yac = this.transform.position.y;
        tac = 0;
        Pos.x = Ob2.transform.position.x;
    }

    void Update()
    {
        xac1 = Ob1.transform.position.x;
        yac1 = Ob1.transform.position.y;
        xac2 = Ob2.transform.position.x;
        yac2 = Ob2.transform.position.y;

        xaux = Mathf.Abs(xac1 - xac2);
        yaux = Mathf.Abs(yac1 - yac2);

        // Detecta si el personaje pisa el obstáculo
        if (!colisionDetectada && xaux <= 6 && yaux <= 2.5)
        {
            colisionDetectada = true;
            tiempoDeteccion = Time.time; // Guardamos el tiempo actual
        }

        // Después de 1 segundo desde la colisión, activar la caída
        if (colisionDetectada && !caer && Time.time >= tiempoDeteccion + 1f)
        {
            caer = true;
        }

        if (caer)
        {
            vac = vac + (Time.deltaTime * (-1 * g - (Cm * vac)));
            yac = yac + (vac * Time.deltaTime);
            tac = tac + Time.deltaTime;
            Pos.y = yac;
            Ob2.transform.position = Pos;
        }
    }
}