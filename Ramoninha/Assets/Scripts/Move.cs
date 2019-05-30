using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public bool viradoDireita = true;
    public float forcaMovimento = 365f;
    public float forcaPulo = 500f;
    public Transform verificaSolo;
    public LayerMask eSolo;

    private float raioSolo = 0.2f;
    private float h;
    private bool noSolo = false;
    private Animator anim;
    private Rigidbody2D rb2d;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        noSolo = Physics2D.OverlapCircle(verificaSolo.position, raioSolo, eSolo);
        anim.SetBool("Pulo", !noSolo);
        anim.SetFloat("SpeedVert", rb2d.velocity.y);

    }


    void Update()
    {
        h = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2(h * forcaMovimento, rb2d.velocity.y);

        anim.SetFloat("Velocidade", Mathf.Abs(rb2d.velocity.x));

        if (h > 0 && !viradoDireita) Flip();
        else if (h < 0 && viradoDireita) Flip();

        if (noSolo && Input.GetButtonDown("Jump"))
        {
            anim.SetBool("Pulo", false);
            rb2d.AddForce(new Vector2(0, forcaPulo));
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            rb2d.AddForce(new Vector2(0, forcaPulo * 1.5f));
            anim.SetTrigger("Hit");
        }
    }

    private void Flip()
    {
        viradoDireita = !viradoDireita;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}
