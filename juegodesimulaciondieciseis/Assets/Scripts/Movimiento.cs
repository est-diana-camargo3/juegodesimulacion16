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
    private bool Yac = true;
    private Rigidbody2D Mono;
    private float velocidadMaxima = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Mono = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        IzqDer = Input.GetAxisRaw("Horizontal");
        Vector2 origen = new Vector2(transform.position.x, transform.position.y - 1.2f);
        RaycastHit2D hit = Physics2D.Raycast(origen, Vector2.down, 0.5f);
        Yac = hit.collider != null && hit.collider.CompareTag("Ground");
        if (Input.GetButtonDown("Jump") && Yac)
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
