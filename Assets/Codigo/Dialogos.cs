using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogos : MonoBehaviour
{

    [SerializeField, TextArea(4, 6)] public string[] lineadialogo;
    [SerializeField] public GameObject paneldialogo;
    [SerializeField] public TextMeshProUGUI Txtpanel;

    [SerializeField] private GameObject objjsonidoescribir;
    public AudioSource escribir;

    public GameObject btnOmitir;
    public GameObject paneljueego;
    public GameObject confjuego;
    public GameObject moneda;
    public GameObject btnsiguiente;
    public GameObject ni?o;
    public GameObject forastero;


    public float time=0.03f;

    public bool dialogaux;
    public bool aux = true;
    public bool numdialogo = true;

    public bool cualomitir =true;

    public int lineindex=0;

  

    Jugador J;
    Apache A;
    AjustesNivel1 N;
    public AudioUI sonido;
    textopergamino TP;

    private void Awake()
    {
        sonido = GameObject.FindObjectOfType<AudioUI>();
    }

    // Update is called once per frame
    private void Start()
    {
        sonido.sonFond.Play();
        J = FindObjectOfType<Jugador>();
        A = FindObjectOfType<Apache>();
        TP = FindObjectOfType<textopergamino>();
        N = FindObjectOfType<AjustesNivel1>();

        escribir = objjsonidoescribir.GetComponent<AudioSource>();


    }

    void Update()
    {
        
        if (!dialogaux)
        {
            if (N.lvl == 1) 
            {
                if (J.gameObject.transform.position.x > -6)
                {
                    iniciardialogo();
                    escribir.Play();
                    paneldialogo.SetActive(true);

                    J.animator.SetBool("estahablando", true);


                }
            }

            if (N.lvl == 3)
            {
                if (J.gameObject.transform.position.x > -6)
                {
                    iniciardialogo();
                    escribir.Play();
                    paneldialogo.SetActive(true);

                    A.animator.SetBool("hablapache", true);


                }
            }

            if (N.lvl == 2) 
            {
                if (J.gameObject.transform.position.x > -4)
                {
                    iniciardialogo();
                    escribir.Play();
                    paneldialogo.SetActive(true);

                    A.animator.SetBool("hablapache", true);


                }
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
            btnOmitir.SetActive(true);

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
        if(N.lvl==1)
        {
            if (numdialogo == true)
            {
                sonido.sonSelect.Play();
                btnOmitir.SetActive(false);
                btnsiguiente.SetActive(false);

                if (lineindex == 0 || lineindex == 2 || lineindex == 4)
                {
                    A.animator.SetBool("hablapache", true);

                    escribir.Play();
                }

                if (lineindex == 1 || lineindex == 3)
                {
                    J.animator.SetBool("estahablando", true);

                    escribir.Play();
                }

                lineindex++;

                if (lineindex < lineadialogo.Length)
                {
                    StartCoroutine(verlineas());
                }
            }
        }

        if (N.lvl == 2)
        {
            if (numdialogo == true)
            {
                sonido.sonSelect.Play();
                btnOmitir.SetActive(false);
                btnsiguiente.SetActive(false);

                if (lineindex == 0 || lineindex == 2 || lineindex == 4)
                {
                    
                    J.animator.SetBool("estahablando", true);
                    escribir.Play();
                }

                if (lineindex == 1 || lineindex == 3)
                {

                    A.animator.SetBool("hablapache", true);
                    escribir.Play();
                }

                lineindex++;

                if (lineindex < lineadialogo.Length)
                {
                    StartCoroutine(verlineas());
                }
            }
        }

        if (N.lvl == 3)
        {
            if (numdialogo == true)
            {
                sonido.sonSelect.Play();
                btnOmitir.SetActive(false);
                btnsiguiente.SetActive(false);

                if (lineindex == 0 || lineindex == 2 || lineindex == 4)
                {
                    J.animator.SetBool("estahablando", true);

                    escribir.Play();
                }

                if (lineindex == 1 || lineindex == 3)
                {
                    A.animator.SetBool("hablapache", true);

                    escribir.Play();
                }

                lineindex++;

                if (lineindex < lineadialogo.Length)
                {
                    StartCoroutine(verlineas());
                }
            }
        }

    }

    public void comenzarJuego()
    {
        dialogaux = true;
        paneljueego.SetActive(true);
        confjuego.SetActive(true);
        moneda.SetActive(true);
        lineindex = 0;
        aux = false;
        cualomitir = false;
    }

    public void omitir()
    {
        if(cualomitir==true)
        {
            escribir.Pause();
            sonido.sonSelect.Play();
            btnsiguiente.SetActive(false);

            lineindex = 6;

        }


    }
}
