using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.Windows;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private float jumpForce;
    
    private float IzqDer;

    private float xac1, yac1; //Posicion Mono
    private float xac2, yac2, xaux, yaux; //Posicion SueloFalso1 - Abs Mono Vs SueloFalso1
    private float xp1, yp1, xaux1, yaux1; //Posicion Suelo1 - Abs Mono Vs Suelo1
    private float xp2, yp2, xaux2, yaux2; //Posicion Suelo2 - Abs Mono Vs Suelo2
    private float xp3, yp3, xaux3, yaux3; //Posicion Suelo2 - Abs Mono Vs Suelo3
    private float xp4, yp4, xaux4, yaux4; //Posicion Suelo2 - Abs Mono Vs Suelo4

    private Rigidbody2D Mono;
    private float velocidadMaxima = 10f;
    private bool EstaEnElSuelo = false;
    public GameObject Ob1, Ob2, Suelo1, Suelo2, Suelo3, Suelo4;

    // Start is called before the first frame update
    void Start()
    {
        Mono = GetComponent<Rigidbody2D>();
        Ob1 = GameObject.Find("Mono");
        Ob2 = GameObject.Find("SueloFalso1");
        Suelo1 = GameObject.Find("Suelo1");
        Suelo2 = GameObject.Find("Suelo2");
        Suelo3 = GameObject.Find("Suelo3");
        Suelo4 = GameObject.Find("Suelo4");
    }

    // Update is called once per frame
    void Update()
    {
        Renderer S1 = Suelo1.GetComponent<Renderer>();
        Renderer S2 = Suelo2.GetComponent<Renderer>();
        Renderer S3 = Suelo3.GetComponent<Renderer>();
        Renderer S4 = Suelo4.GetComponent<Renderer>();

        IzqDer = Input.GetAxisRaw("Horizontal");

        xac1 = Ob1.transform.position.x;
        yac1 = Ob1.transform.position.y;
        
        xac2 = Ob2.transform.position.x;
        yac2 = Ob2.transform.position.y;

        xp1 = Suelo1.transform.position.x;
        yp1 = Suelo1.transform.position.y;

        xp2 = Suelo2.transform.position.x;
        yp2 = Suelo2.transform.position.y;

        xp3 = Suelo3.transform.position.x;
        yp3 = Suelo3.transform.position.y;

        xp4 = Suelo4.transform.position.x;
        yp4 = Suelo4.transform.position.y;

        xaux = Mathf.Abs(xac1 - xac2);
        yaux = Mathf.Abs(yac1 - yac2);

        xaux1 = Mathf.Abs(xac1 - xp1);
        yaux1 = Mathf.Abs(yac1 - yp1);

        xaux2 = Mathf.Abs(xac1 - xp2);
        yaux2 = Mathf.Abs(yac1 - yp2);

        xaux3 = Mathf.Abs(xac1 - xp3);
        yaux3 = Mathf.Abs(yac1 - yp3);

        xaux4 = Mathf.Abs(xac1 - xp4);
        yaux4 = Mathf.Abs(yac1 - yp4);

        // Detectar si está en el suelo1
        if (xaux1 <= S1.bounds.size.x/2 && yaux1 <= 2.5)
        {
            EstaEnElSuelo = true;

            // Corregir posición para que no atraviese el suelo1
            Vector3 pos = transform.position;
            pos.y = yp1 + 2.5f;
            Mono.transform.position = pos;

            // Detener velocidad vertical si está en el suelo
            Mono.velocity = new Vector2(Mono.velocity.x, 0f);
        }
        // Detectar si está en el suelo2
        else if (xaux2 <= S2.bounds.size.x / 2 && yaux2 <= 2.5)
        {
            EstaEnElSuelo = true;

            // Corregir posición para que no atraviese el suelo1
            Vector3 pos = transform.position;
            pos.y = yp2 + 2.5f;
            Mono.transform.position = pos;

            // Detener velocidad vertical si está en el suelo
            Mono.velocity = new Vector2(Mono.velocity.x, 0f);
        }
        // Detectar si está en el suelo3
        else if (xaux3 <= S3.bounds.size.x / 2 && yaux3 <= 2.5)
        {
            EstaEnElSuelo = true;

            // Corregir posición para que no atraviese el suelo1
            Vector3 pos = transform.position;
            pos.y = yp3 + 2.5f;
            Mono.transform.position = pos;

            // Detener velocidad vertical si está en el suelo
            Mono.velocity = new Vector2(Mono.velocity.x, 0f);
        }
        // Detectar si está en el suelo4
        else if (xaux4 <= S4.bounds.size.x / 2 && yaux4 <= 2.5)
        {
            EstaEnElSuelo = true;

            // Corregir posición para que no atraviese el suelo1
            Vector3 pos = transform.position;
            pos.y = yp4 + 2.5f;
            Mono.transform.position = pos;

            // Detener velocidad vertical si está en el suelo
            Mono.velocity = new Vector2(Mono.velocity.x, 0f);
        }
        // Detecta si el personaje pisa el obstáculo
        else if (xaux <= 6 && yaux <= 2.5)
        {
            EstaEnElSuelo = true;

            // Corregir posición para que no atraviese el suelo
            Vector3 pos = transform.position;
            pos.y = yac2 + 2.5f;
            Mono.transform.position = pos;

            // Detener velocidad vertical si está en el suelo
            Mono.velocity = new Vector2(Mono.velocity.x, 0f);
        }
        else
        {
            EstaEnElSuelo = false;
        }
        // Saltar
        if (Input.GetButtonDown("Jump") && EstaEnElSuelo)
        {
            Mono.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        Vector2 input = new Vector2(IzqDer, 0f);
        Mono.AddForce(input * force);

        if (Mathf.Abs(Mono.velocity.x) > velocidadMaxima)
        {
            Mono.velocity = new Vector2(Mathf.Sign(Mono.velocity.x) * velocidadMaxima, Mono.velocity.y);
        }
    }
}
