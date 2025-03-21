using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.Windows;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private float jumpForce;
    private float IzqDer;
    private bool Yac;
    private Rigidbody Mono;

    // Start is called before the first frame update
    void Start()
    {
        Mono = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        IzqDer = Input.GetAxisRaw("Horizontal"); //Devuelve 1 o -1 en función de si se aprietan las teclas Izq, Der, A o D
        if (Input.GetButtonDown("Jump") && Yac) // "Jump" se asocia a barra espaciadora o flecha arriba por defecto
        {
            Mono.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate() //Calcula fisicas
    {
        Vector2 input = new Vector2(IzqDer, 0f);
        Mono.AddForce(input * force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Yac = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Yac = false;
        }
    }
}
