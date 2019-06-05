using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamoninhaComportamentos : MonoBehaviour
{
    private Animator anim;
    private Transform trans;
    private Rigidbody2D rb2d;
    [SerializeField] private Collider2D hitbox1;
    [SerializeField] private Collider2D hitbox2;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        trans = GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MataRamon"))
        {
            anim.SetTrigger("Dano na Ramoninha");
            rb2d.AddForce(new Vector2(-30f, 0));
        } 
    }
}
