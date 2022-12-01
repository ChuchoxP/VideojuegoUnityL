using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ajustespergamino : MonoBehaviour
{

    Animator animator;
    Jugador J;
    textopergamino TP;
    AjustesMenu AM;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        J=FindObjectOfType<Jugador>();
        TP = FindObjectOfType<textopergamino>();
        AM = FindObjectOfType<AjustesMenu>();

    }

    // Update is called once per frame
    void Update()
    {

        if (J.ok == true)
        {

            animator.SetBool("Estacerrado", true);

        }

        if (TP.lineindex == 3)
        {
            animator.SetBool("Estacerrado", true);
            TP.Txtpanel.SetActive(false);

            if(J.timerpergaminofinal>1)
            {
                SceneManager.LoadScene(4);

            }

        }

    }





}
