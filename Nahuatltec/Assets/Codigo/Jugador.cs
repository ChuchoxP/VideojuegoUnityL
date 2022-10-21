using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    private Animator animator;

    public bool jump=false;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Suelo")
        {
            animator.SetBool("Estasaltando", false);
            jump=true;
        }
    }

    public void saltar()
    {
        if(jump)
        {
            animator.SetBool("Estasaltando", true);
            rigidbody2D.AddForce(new Vector2(0, 250));
            jump=false;
        }


    }




}
