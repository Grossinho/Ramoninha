using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float velocidade;
    private Rigidbody2D rb2d;
    private Transform trans;
    [SerializeField] private Collider2D vivo;
    [SerializeField] private Collider2D morto;
    [SerializeField] private Collider2D cabeca;
    [SerializeField] private Collider2D corpo;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(velocidade, 0);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            velocidade *= -1;
            Vector3 escala = trans.localScale;
            escala.x *= -1;
            trans.localScale = escala;

        }
        if (collision.gameObject.CompareTag("Player") && collision.transform.position.y > trans.position.y + 0.3f)
        {
            velocidade = 0;
            cabeca.enabled = false;
            corpo.enabled = false;
            vivo.enabled = false;
            morto.enabled = true;
            GetComponent<Animator>().SetTrigger("Morto");
            StartCoroutine("Morre");
        }
    }

    IEnumerator Morre()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);


    }
}
