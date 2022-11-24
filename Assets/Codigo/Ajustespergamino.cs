using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ajustespergamino : MonoBehaviour
{

    Animator animator;
    Jugador J;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        J=FindObjectOfType<Jugador>();
 
    }

    // Update is called once per frame
    void Update()
    {

        if (J.ok == true)
        {

            animator.SetBool("Estacerrado", true);

        }

    }

}
