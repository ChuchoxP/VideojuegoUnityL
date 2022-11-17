using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogos : MonoBehaviour
{

    [SerializeField, TextArea(4, 6)] public string[] lineadialogo;
    [SerializeField] private GameObject paneldialogo;
    [SerializeField] private TextMeshProUGUI Txtpanel;

    [SerializeField] private GameObject objjsonidoescribir;
    private AudioSource escribir;

    public GameObject btnOmitir;
    public GameObject paneljueego;
    public GameObject confjuego;
    public GameObject moneda;
    public GameObject btnsiguiente;
    public GameObject niño;
    public GameObject forastero;


    float time=0.03f;

    public bool dialogaux;

    public int lineindex=0;

    Jugador J;
    Apache A;


    // Update is called once per frame
    private void Start()
    {
        J = FindObjectOfType<Jugador>();
        A = FindObjectOfType<Apache>();

        escribir = objjsonidoescribir.GetComponent<AudioSource>();


    }

    void Update()
    {
        if (!dialogaux)
        {
            if(J.gameObject.transform.position.x > -6)
            {
                iniciardialogo();
                escribir.Play();
                paneldialogo.SetActive(true);

                J.animator.SetBool("estahablando", true);


            }

            
            paneljueego.SetActive(false);
            confjuego.SetActive(false);
            btnOmitir.SetActive(false);
            moneda.SetActive(false);

        }
        else if (Txtpanel.text == lineadialogo[lineindex])
        {
            btnsiguiente.SetActive(true);
            A.animator.SetBool("hablapache", false);
            J.animator.SetBool("estahablando", false);
            escribir.Pause();

        }
    }

    public void iniciardialogo()
    {
        dialogaux = true;
        StartCoroutine(verlineas());
        

    }

    private IEnumerator verlineas()
    {
        Txtpanel.text = string.Empty;

        foreach(char ch in lineadialogo[lineindex])
        {
            Txtpanel.text+=ch;
            yield return new WaitForSeconds(time);
        }
    }

    public void siguientedialogo()
    {
        btnOmitir.SetActive(true);
        btnsiguiente.SetActive(false);


        escribir.Play();

        if (lineindex == 0||lineindex==2||lineindex==4)
        {
            A.animator.SetBool("hablapache", true);
        }

        if (lineindex == 1 || lineindex == 3 )
        {
            J.animator.SetBool("estahablando", true);
        }


        lineindex++;



        if (lineindex < lineadialogo.Length)
        {
            StartCoroutine(verlineas());
        }
    }

    public void comenzarJuego()
    {
        J.animator.SetBool("quieto", false);
        escribir.Pause();
        forastero.SetActive(false);
        dialogaux = true;
        paneldialogo.SetActive(false);
        paneljueego.SetActive(true);
        confjuego.SetActive(true);
        moneda.SetActive(true);
        lineindex = 0;
    }

    public void omitir()
    {
        lineindex = 6;

        A.GetComponent<BoxCollider2D>().enabled = false;

        if (J.gameObject.transform.position.x>-4)
        {
            escribir.Pause();
            forastero.SetActive(false);
            dialogaux = true;
            paneldialogo.SetActive(false);
            paneljueego.SetActive(true);
            confjuego.SetActive(true);
            moneda.SetActive(true);
            lineindex = 0;
        }

        if (lineindex == 6)
        {
            J.gameObject.transform.position = J.gameObject.transform.position + new Vector3(1, 0, 0) * Time.deltaTime * 2;
            J.animator.SetBool("quieto", false);
        }

    }
}
