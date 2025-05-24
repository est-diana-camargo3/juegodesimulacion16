using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.Windows;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private float jumpForce;
    private float IzqDer;
    private bool Yac;
    private Rigidbody2D Mono;

    // Start is called before the first frame update
    void Start()
    {
        Mono = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        IzqDer = Input.GetAxisRaw("Horizontal"); //Devuelve 1 o -1 en funci�n de si se aprietan las teclas Izq, Der, A o D
        if (Input.GetButtonDown("Jump") && Yac) // "Jump" se asocia a barra espaciadora o flecha arriba por defecto
        {
            Mono.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate() //Calcula fisicas
    {
        Vector2 input = new Vector2(IzqDer, 0f);
        Mono.AddForce(input * force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Yac = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Yac = false;
        }
    }
}
