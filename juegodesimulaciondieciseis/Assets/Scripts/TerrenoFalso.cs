using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TerrenoFalso : MonoBehaviour
{
    private float vo = 0f, g = 9.81f, Cm, C = 1.3f;
    public float vac, yac, tac, m, xac1, xac2, yac1, yac2, xaux, yaux;
    private int To = 0;
    Vector2 Pos = Vector2.zero;
    public GameObject Ob1, Ob2;

    // Start is called before the first frame update
    void Start()
    {
        Ob1 = GameObject.Find("Mono");
        Ob2 = GameObject.Find("Obstaculo2");

        Cm = C / m;
        vac = 0;
        yac = this.transform.position.y;
        tac = 0;
        Pos.x = 0;
    }

    // Update is called once per frame
    void Update()
    {
        xac1 = Ob1.transform.position.x;
        yac1 = Ob1.transform.position.y;
        xac2 = Ob2.transform.position.x;
        yac2 = Ob2.transform.position.y;

        xaux = Mathf.Abs(xac1 - xac2);
        yaux = Mathf.Abs(yac1 - yac2);
        if (xaux <= 1 && yaux <= 1)
        {
            Debug.Log("Mono pisa Obstaculo2");//Mensaje por consola que confirma el choque.
            To = 1;
        }
        if (To == 1)
        {
            vac = vac + (Time.deltaTime * (-1 * g - (Cm * vac)));
            yac = yac + (vac * Time.deltaTime);
            tac = tac + Time.deltaTime;
            Pos.y = yac;
            this.transform.position = Pos;
        }
    }
}
