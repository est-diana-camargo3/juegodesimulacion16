using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TerrenoFalso : MonoBehaviour
{
    private float vo = 0f, g = 9.81f, Cm, m = 1f, C = 1.3f;
    public float vac2, yaC2, tac2;
    public float vac3, yaC3, tac3;
    public float vac4, yaC4, tac4;
    public float vac5, yaC5, tac5;
    private float xac1, yac1;
    private float xac2, yac2, xauxF2, yauxF2; //SueloFalso1
    private float xac3, yac3, xauxF3, yauxF3; //SueloFalso2
    private float xac4, yac4, xauxF4, yauxF4; //SueloFalso3
    private float xac5, yac5, xauxF5, yauxF5; //SueloFalso4
    private bool caer2 = false;
    private bool caer3 = false;
    private bool caer4 = false;
    private bool caer5 = false;
    private float tiempoDeteccion = 0f;
    private bool colisionDetectada2 = false;
    private bool colisionDetectada3 = false;
    private bool colisionDetectada4 = false;
    private bool colisionDetectada5 = false;
    Vector2 Pos2 = Vector2.zero;
    Vector2 Pos3 = Vector2.zero;
    Vector2 Pos4 = Vector2.zero;
    Vector2 Pos5 = Vector2.zero;
    public GameObject Ob1, Ob2, Ob3, Ob4, Ob5;

    void Start()
    {
        Ob2 = GameObject.Find("SueloFalso1");
        Ob3 = GameObject.Find("SueloFalso2");
        Ob4 = GameObject.Find("SueloFalso3");
        Ob5 = GameObject.Find("SueloFalso4");

        Cm = C / m;

        vac2 = 0;
        yaC2 = Ob2.transform.position.y;
        tac2 = 0;
        Pos2.x = Ob2.transform.position.x;

        vac3 = 0;
        yaC3 = Ob3.transform.position.y;
        tac3 = 0;
        Pos3.x = Ob3.transform.position.x;

        vac4 = 0;
        yaC4 = Ob4.transform.position.y;
        tac4 = 0;
        Pos4.x = Ob4.transform.position.x;

        vac5 = 0;
        yaC5 = Ob5.transform.position.y;
        tac5 = 0;
        Pos5.x = Ob5.transform.position.x;
    }

    void Update()
    {
        xac1 = Ob1.transform.position.x;
        yac1 = Ob1.transform.position.y;
        xac2 = Ob2.transform.position.x;
        yac2 = Ob2.transform.position.y;
        xac3 = Ob3.transform.position.x;
        yac3 = Ob3.transform.position.y;
        xac4 = Ob4.transform.position.x;
        yac4 = Ob4.transform.position.y;
        xac5 = Ob5.transform.position.x;
        yac5 = Ob5.transform.position.y;

        xauxF2 = Mathf.Abs(xac1 - xac2);
        yauxF2 = Mathf.Abs(yac1 - yac2);
        xauxF3 = Mathf.Abs(xac1 - xac3);
        yauxF3 = Mathf.Abs(yac1 - yac3);
        xauxF4 = Mathf.Abs(xac1 - xac4);
        yauxF4 = Mathf.Abs(yac1 - yac4);
        xauxF5 = Mathf.Abs(xac1 - xac5);
        yauxF5 = Mathf.Abs(yac1 - yac5);

        // Detecta si el personaje pisa el SueloFalso1
        if (!colisionDetectada2 && xauxF2 <= 6 && yauxF2 <= 2.5)
        {
            colisionDetectada2 = true;
            tiempoDeteccion = Time.time; // Guardamos el tiempo actual
        }

        // Detecta si el personaje pisa el SueloFalso2
        if (!colisionDetectada3 && xauxF3 <= 6 && yauxF3 <= 2.5)
        {
            colisionDetectada3 = true;
            tiempoDeteccion = Time.time; // Guardamos el tiempo actual
        }

        // Detecta si el personaje pisa el SueloFalso3
        if (!colisionDetectada4 && xauxF4 <= 6 && yauxF4 <= 2.5)
        {
            colisionDetectada4 = true;
            tiempoDeteccion = Time.time; // Guardamos el tiempo actual
        }

        // Detecta si el personaje pisa el SueloFalso4
        if (!colisionDetectada5 && xauxF5 <= 6 && yauxF5 <= 2.5)
        {
            colisionDetectada5 = true;
            tiempoDeteccion = Time.time; // Guardamos el tiempo actual
        }

        // Después de 1 segundo desde la colisión, activar la caída del SueloFalso1
        if (colisionDetectada2 && !caer2 && Time.time >= tiempoDeteccion + 1f)
        {
            caer2 = true;
        }

        // Después de 1 segundo desde la colisión, activar la caída del SueloFalso2
        if (colisionDetectada3 && !caer3 && Time.time >= tiempoDeteccion + 1f)
        {
            caer3 = true;
        }

        // Después de 1 segundo desde la colisión, activar la caída del SueloFalso3
        if (colisionDetectada4 && !caer4 && Time.time >= tiempoDeteccion + 1f)
        {
            caer4 = true;
        }

        // Después de 1 segundo desde la colisión, activar la caída del SueloFalso4
        if (colisionDetectada5 && !caer5 && Time.time >= tiempoDeteccion + 1f)
        {
            caer5 = true;
        }

        if (caer2)
        {
            vac2 = vac2 + (Time.deltaTime * (-1 * g - (Cm * vac2)));
            yaC2 = yaC2 + (vac2 * Time.deltaTime);
            tac2 = tac2 + Time.deltaTime;
            Pos2.y = yaC2;
            Ob2.transform.position = Pos2;
        }

        if (caer3)
        {
            vac3 = vac3 + (Time.deltaTime * (-1 * g - (Cm * vac3)));
            yaC3 = yaC3 + (vac3 * Time.deltaTime);
            tac3 = tac3 + Time.deltaTime;
            Pos3.y = yaC3;
            Ob3.transform.position = Pos3;
        }

        if (caer4)
        {
            vac4 = vac4 + (Time.deltaTime * (-1 * g - (Cm * vac4)));
            yaC4 = yaC4 + (vac4 * Time.deltaTime);
            tac4 = tac4 + Time.deltaTime;
            Pos4.y = yaC4;
            Ob4.transform.position = Pos4;
        }

        if (caer5)
        {
            vac5 = vac5 + (Time.deltaTime * (-1 * g - (Cm * vac5)));
            yaC5 = yaC5 + (vac5 * Time.deltaTime);
            tac5 = tac5 + Time.deltaTime;
            Pos5.y = yaC5;
            Ob5.transform.position = Pos5;
        }
    }
}