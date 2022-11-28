using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoFinal : MonoBehaviour
{
    [SerializeField, TextArea(4, 4)] public string[] lineadialogo;
    public bool dialogaux;
    public int lineindex = 0;



    Apache A;
    Dialogos D;
    Jugador J;

    // Start is called before the first frame update
    void Start()
    {
        A=FindObjectOfType<Apache>();
        D=FindObjectOfType<Dialogos>();
        J=FindObjectOfType<Jugador>();

    }

    // Update is called once per frame
    void Update()
    {

            if (!dialogaux)
            {
                if (J.dialogofinal == true)
                {
                    
                    iniciardialogo();
                    D.escribir.Play();
                    D.paneldialogo.SetActive(true);

                    A.animator.SetBool("hablapache", true);
                    D.btnOmitir.SetActive(false);
                    D.btnsiguiente.SetActive(false);


                }
            }
            else if (D.Txtpanel.text == lineadialogo[lineindex])
            {
                D.btnsiguiente.SetActive(true);
                A.animator.SetBool("hablapache", false);
                J.animator.SetBool("estahablando", false);
                D.escribir.Pause();
                D.btnOmitir.SetActive(true);

            }
    }

    

    public void iniciardialogo()
    {
        dialogaux = true;
        StartCoroutine(verlineas());


    }

    private IEnumerator verlineas()
    {
        D.Txtpanel.text = string.Empty;

        foreach (char ch in lineadialogo[lineindex])
        {
            D.Txtpanel.text += ch;
            yield return new WaitForSeconds(D.time);
        }
    }

    public void siguientedialogo()
    {

        if(D.numdialogo==false)
        {
            D.sonido.sonSelect.Play();
            D.btnOmitir.SetActive(false);
            D.btnsiguiente.SetActive(false);


            D.escribir.Play();


            if (lineindex == 0 || lineindex == 2)
            {
                J.animator.SetBool("estahablando", true);
            }

            if (lineindex == 1)
            {
                A.animator.SetBool("hablapache", true);
            }


            lineindex++;


            if (lineindex < lineadialogo.Length)
            {
                StartCoroutine(verlineas());
            }
        }

        
    }

    public void omitir()
    {

        if(D.cualomitir==false)
        {
            J.salirfinal();

            lineindex = 4;
        }

    }
}
