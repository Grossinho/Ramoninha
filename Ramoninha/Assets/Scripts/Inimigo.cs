using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    private float velocidade = 1f;
    private Transform trans;
    private Animator anim;
    private Rigidbody2D rb2d;
    private BoxCollider2D col;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(velocidade, 0);
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            velocidade *= -1;
            Vector3 escala = transform.localScale;
            escala.x *= -1;
            transform.localScale = escala;
            
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            velocidade = 0;
            anim.SetBool("Morto", true);
            col.transform.Rotate(0, 0, 90);
            
            
        }
    }
}
