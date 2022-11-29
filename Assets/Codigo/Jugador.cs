using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class Jugador : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    public static Jugador instance;
    public Animator animator;

    public GameObject dialogo;
    public GameObject confjuego;
    public GameObject titulo;

    public bool dialogofinal=false;

    public bool posapache = false;

    bool poseniño = true;


    int vel = 1;




    public bool jump=false;

    public bool ok=false;

    public bool Comenzar=true;

    public bool cualdiag=false;

    AjustesNivel1 N;

    Dialogos D;
    Apache A;
    textopergamino TP;
    Ajustespergamino AP;
    DialogoFinal DF;

    public GameObject v1;
    public GameObject v2;
    public GameObject v3;

    public GameObject sv1;
    public GameObject sv2;
    public GameObject sv3;
    public GameObject cartel;
    public GameObject pergamino;

    public GameObject panelpergamino;

    public TextMeshProUGUI SNL;
    public TextMeshProUGUI textonahuatl;


    [SerializeField] private GameObject objjsonidomoneda;
    private AudioSource Sonidomoneda;


    [SerializeField] private GameObject objjsonidosalto;
    private AudioSource Sonidosalto;

    [SerializeField] private GameObject objjsonidodaño;
    private AudioSource Sonidodaño;

    [SerializeField] private GameObject objjsonidorevivir;
    private AudioSource Sonidorevivir;

    public TextMeshProUGUI totmonedas;
    public int tot = 0;

    [SerializeField] private GameObject btnyoutube;
    [SerializeField] private GameObject btnpaypal;
    [SerializeField] private GameObject btnsalir;
    [SerializeField] private GameObject menupago;

    private int v=3;

    public int x =0;

    private int fuerzasalto = 500;


    public float timer;
    public float timercartel;
    public float timerpergamino;
    public float timerpergaminofinal;
    public float timertexto;




    public string letra;

    AudioUI sonido;

    private void Awake()
    {
        sonido = GameObject.FindObjectOfType<AudioUI>();
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {


        //plbrdm = Random.Range(1, 4);


        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();


        Sonidomoneda=objjsonidomoneda.GetComponent<AudioSource>();
        Sonidosalto = objjsonidosalto.GetComponent<AudioSource>();
        Sonidodaño = objjsonidodaño.GetComponent<AudioSource>();
        Sonidorevivir = objjsonidorevivir.GetComponent<AudioSource>();

        N = FindObjectOfType<AjustesNivel1>();
        D = FindObjectOfType<Dialogos>();
        A = FindObjectOfType<Apache>();
        TP = FindObjectOfType<textopergamino>();
        AP = FindObjectOfType<Ajustespergamino>();
        DF = FindObjectOfType<DialogoFinal>();



    }

    private void Update()
    {
        
        vidas();
        caminar();
        Final();
        salirfinal();
        pergaminofinal();

        totmonedas.text = tot.ToString();

        timer += Time.deltaTime;

        if (x==4)
        {
            cartels();
        }

        if(ok==true)
        {
            timerpergamino += Time.deltaTime;
        }


        if (timer > 1)
        {
            animator.SetBool("Dañado", false);
        }

    }

    public void vidas()
    {
        if (v == 2)
        {
            v3.SetActive(false);
            sv3.SetActive(true);
        }
        else if (v == 1)
        {
            v2.SetActive(false);
            sv2.SetActive(true);
        }
        else if (v == 0)
        {
            v1.SetActive(false);
            sv1.SetActive(true);

            gameover();

            SNL.text = "";

        }
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
            rigidbody2D.AddForce(new Vector2(0, fuerzasalto));
            Sonidosalto.Play();
            jump =false;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        for (int c = 0; c < N.mon.Count; c++)
        {
            if (collision.CompareTag("moneda"))
            {
                float randomcObs = Random.Range(-2,2);
                N.mon[c].transform.position = new Vector3(13, randomcObs, 0);
                tot++;
                Sonidomoneda.Play();
            }

            N.mon[c].transform.position = N.mon[c].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * 2;
        }





        switch (N.contplb)
        {
            case 1:

                if (collision.CompareTag("X"))
                {
                    SNL.text = "X";

                    N.contlt++;

                    for (int c = 0; c < N.LL1.Count; c++)
                    {
                        N.LL1[c].transform.position = new Vector3(-13, 0, 0);
                    }


                }
                if (collision.CompareTag("I1"))
                {
                    SNL.text = "XI";

                    N.contlt++;

                    for (int c = 0; c < N.LL2.Count; c++)
                    {
                        N.LL2[c].transform.position = new Vector3(-13, 0, 0);
                    }

                }
                if (collision.CompareTag("A1"))
                {
                    SNL.text = "XIA";

                    N.contlt++;

                    for (int c = 0; c < N.LL3.Count; c++)
                    {
                        N.LL3[c].transform.position = new Vector3(-13, 0, 0);
                    }
                }
                if (collision.CompareTag("J"))
                {
                    SNL.text = "XIAJ";

                    N.contlt++;

                    x = 4;

                    for (int c = 0; c < N.LL4.Count; c++)
                    {
                        N.LL4[c].transform.position = new Vector3(-13, 0, 0);
                    }
                }

                break;

            case 2:

                if (collision.CompareTag("P"))
                {
                    SNL.text = "P";

                    N.contlt++;

                    for (int c = 0; c < N.LL5.Count; c++)
                    {
                        N.LL5[c].transform.position = new Vector3(-13, 0, 0);
                    }


                }
                if (collision.CompareTag("A1"))
                {
                    SNL.text = "PA";

                    N.contlt++;

                    for (int c = 0; c < N.LL6.Count; c++)
                    {
                        N.LL6[c].transform.position = new Vector3(-13, 0, 0);
                    }

                }
                if (collision.CompareTag("N1"))
                {
                    SNL.text = "PAN";

                    N.contlt++;

                    for (int c = 0; c < N.LL7.Count; c++)
                    {
                        N.LL7[c].transform.position = new Vector3(-13, 0, 0);
                    }
                }
                if (collision.CompareTag("T1"))
                {
                    SNL.text = "PANT";

                    N.contlt++;

                    for (int c = 0; c < N.LL8.Count; c++)
                    {
                        N.LL8[c].transform.position = new Vector3(-13, 0, 0);
                    }
                }

                if (collision.CompareTag("I1"))
                {
                    SNL.text = "PANTI";

                    N.contlt++;


                    for (int c = 0; c < N.LL9.Count; c++)
                    {
                        N.LL9[c].transform.position = new Vector3(-13, 0, 0);
                    }
                }

                if (collision.CompareTag("S"))
                {
                    SNL.text = "PANTIS";



                    N.contlt++;

                    x = 4;

                    for (int c = 0; c < N.LL10.Count; c++)
                    {
                        N.LL10[c].transform.position = new Vector3(-13, 0, 0);
                    }
                }

                break;

            case 3:

                if (collision.CompareTag("O"))
                {
                    SNL.text = "O";

                    N.contlt++;


                    for (int c = 0; c < N.LL11.Count; c++)
                    {
                        N.LL11[c].transform.position = new Vector3(-13, 0, 0);
                    }


                }
                if (collision.CompareTag("J"))
                {
                    SNL.text = "OJ";

                    N.contlt++;

                    for (int c = 0; c < N.LL12.Count; c++)
                    {
                        N.LL12[c].transform.position = new Vector3(-13, 0, 0);
                    }

                }
                if (collision.CompareTag("U"))
                {
                    SNL.text = "OJU";

                    N.contlt++;

                    for (int c = 0; c < N.LL13.Count; c++)
                    {
                        N.LL13[c].transform.position = new Vector3(-13, 0, 0);
                    }
                }
                if (collision.CompareTag("I1"))
                {
                    SNL.text = "OJUI";


                    N.contlt++;

                    x = 4;

                    for (int c = 0; c < N.LL14.Count; c++)
                    {
                        N.LL14[c].transform.position = new Vector3(-13, 0, 0);
                    }
                }

                break;
        }

        if (collision.CompareTag("obstaculo"))
        {

            v--;

            timer = 0;

            animator.SetBool("Dañado", true);

            Sonidodaño.Play();
            

        }

    }

    public void gameover()
    {
        sonido.sonFond.Pause();
        Time.timeScale = 0f;
        btnyoutube.SetActive(true);
        btnpaypal.SetActive(true);
        btnsalir.SetActive(true);
        menupago.SetActive(true);
        Pausa.instance.menupausa.SetActive(false);
        Pausa.instance.btnpausa.SetActive(false);

    }
    public void gameoverEx()
    {
        v = 1;
        Time.timeScale = 1f;
        sv1.SetActive(false);
        v1.SetActive(true);
        btnyoutube.SetActive(false);
        btnpaypal.SetActive(false);
        btnsalir.SetActive(false);
        menupago.SetActive(false);
        Sonidorevivir.Play();
        sonido.sonFond.Play();



    }


    public void cartels()
    {

        Time.timeScale = 0.1f;

        timercartel +=Time.deltaTime;

        pergamino.SetActive(true);

        cartel.SetActive(true);


        if (N.contplb == 1)
        {
            textonahuatl.text = "XIAJ";
        }

        if (N.contplb == 2)
        {
            textonahuatl.text = "PANTIS";
        }

        if (N.contplb == 3)
        {
            textonahuatl.text = "OJUI";
        }
        

        if(timercartel>0.2f)
        {
            Time.timeScale = 1f;

            cartel.SetActive(false);

            pergamino.SetActive(false);

            textonahuatl.text = "";

            SNL.text = "";

            timercartel = 0;

            x=0;

            N.contplb++;

            N.contlt++;



        }
    }

    public void caminar()
    {
        if (gameObject.transform.position.x < -6)
        {
            gameObject.transform.position = gameObject.transform.position + new Vector3(1, 0, 0) * Time.deltaTime * 2;
        }
        else
        {
            animator.SetBool("quieto", true);
        }

        if (D.lineindex == 6)
        {
            timertexto+=Time.deltaTime;

            TP.paneldpergamino.SetActive(true);

            if (timertexto > 1)
            {
                TP.x = true;
            }

        }



        if (timerpergamino>1)
        {

            TP.paneldpergamino.SetActive(false);
            D.escribir.Pause();
            sonido.sonDialogo.Pause();
            titulo.SetActive(false);


            if (A.gameObject.transform.position.x<11)
            {
                if(posapache==true)
                {
                    A.SpriteRenderer.flipX = false;
                    posapache = false;
                }


                A.gameObject.transform.position = A.gameObject.transform.position + new Vector3(1, 0, 0) * Time.deltaTime * 2;

                A.animator.SetBool("caminapache", true);
            }
            else
            {

                gameObject.transform.position = gameObject.transform.position + new Vector3(1, 0, 0) * Time.deltaTime * 2;

                animator.SetBool("quieto", false);
             

              
            }


        }


  
        if (gameObject.transform.position.x > -4)
        {

                    D.comenzarJuego();

                    timerpergamino = 0;

                    ok = false;

                    animator.SetBool("quieto", false);
            

        }








    }


    public void salirfinal()
    {
        if (DF.lineindex == 4)
        {
            A.SpriteRenderer.flipX = false;

            D.paneldialogo.SetActive(false);

            A.gameObject.transform.position = A.gameObject.transform.position + new Vector3(2, 0, 0) * Time.deltaTime * 2;

            A.animator.SetBool("caminapache", true);

            vel = 1;

            poseniño = false;

        }
    }    

    public void Ok()
    {
        ok= true;
        TP.Txtpanel.SetActive(false);
        TP.btnOk.SetActive(false);
        panelpergamino.SetActive(false);
        D.paneldialogo.SetActive(false);

        timerpergaminofinal = 0;

        TP.lineindex++;

        cualdiag = true;



    }

    public void Final()
    {
        if (N.contplb == 4)
        {
            D.numdialogo = false;

            gameObject.transform.position = gameObject.transform.position + new Vector3(vel, 0, 0) * Time.deltaTime * 2;

            D.paneljueego.SetActive(false);
            confjuego.SetActive(false);
            D.moneda.SetActive(false);

            for (int l = 0; l < N.murci.Count; l++)
            {
                N.murci[l].SetActive(false);
            }

            for (int l = 0; l < N.slim.Count; l++)
            {
                N.slim[l].SetActive(false);
            }

            for (int u = 0; u < N.mon.Count; u++)
            {
                N.mon[u].SetActive(false);
            }

            if (gameObject.transform.position.x > 2)
            {

                    animator.SetBool("quieto", poseniño);

                vel = 0;

                if (A.gameObject.transform.position.x>5)
                {
                    if (posapache == false)
                    {
                        A.SpriteRenderer.flipX = true;
                        posapache = true;
                    }

                    A.gameObject.transform.position = A.gameObject.transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * 2;

                    
                }
                else
                {
                    A.animator.SetBool("caminapache", false);
                    dialogofinal = true;



                }


            }

        }
    }

    public void pergaminofinal()
    {
        if(gameObject.transform.position.x >11)
        {
            panelpergamino.SetActive(true);
            TP.paneldpergamino.SetActive(true);
            timerpergaminofinal += Time.deltaTime;


            if(timerpergaminofinal > 1)
            {
                TP.x = true;
                TP.Txtpanel.SetActive(true);

                if(cualdiag==true)
                {
                    TP.siguientedialogo();
                    cualdiag = false;
                }
                

            }
        }

        


    }
}
