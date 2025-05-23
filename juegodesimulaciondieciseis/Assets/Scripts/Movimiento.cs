using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private float jumpForce;
    private float IzqDer;
    private bool Yac;
    private Rigidbody2D Mono;
    private bool muerto;

    void Start()
    {
        Mono = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!muerto)
        {
            IzqDer = Input.GetAxisRaw("Horizontal");
            if (Input.GetButtonDown("Jump") && Yac)
            {
                Mono.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    private void FixedUpdate()
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