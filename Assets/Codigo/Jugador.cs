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
    Enemigos enemies;
    private Rigidbody2D rigidbody2D;

    public static Jugador instance;
    public Animator animator;

    public SpriteRenderer Sprite;

    public bool spriteX=true;

    public GameObject dialogo;
    public GameObject confjuego;
    public GameObject titulo;

    public bool dialogofinal=false;

    public bool posapache = false;
    public bool posapache2 = false;

    bool poseniño = true;
    bool poseniño3 = true;



    int vel = 1;

    int vel2 = 1;




    public bool jump=false;

    public bool ok=false;
    public bool ok2 = true;


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
        Sprite = GetComponent<SpriteRenderer>();


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
        caminarlvl2();
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


        if(N.lvl==1)
        {
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
        }

        if(N.lvl==2)
        {
            switch (N.contplb)
            {
                case 1:

                    if (collision.CompareTag("T1"))
                    {
                        SNL.text = "T";

                        N.contlt++;

                        for (int c = 0; c < N.LL1.Count; c++)
                        {
                            N.LL1[c].transform.position = new Vector3(-13, 0, 0);
                        }


                    }
                    if (collision.CompareTag("A1"))
                    {
                        SNL.text = "TA";

                        N.contlt++;

                        for (int c = 0; c < N.LL2.Count; c++)
                        {
                            N.LL2[c].transform.position = new Vector3(-13, 0, 0);
                        }

                    }
                    if (collision.CompareTag("L1"))
                    {
                        SNL.text = "TAL";

                        N.contlt++;

                        for (int c = 0; c < N.LL3.Count; c++)
                        {
                            N.LL3[c].transform.position = new Vector3(-13, 0, 0);
                        }
                    }
                    if (collision.CompareTag("I1"))
                    {
                        SNL.text = "TALI";

                        N.contlt++;

                        x = 4;

                        for (int c = 0; c < N.LL4.Count; c++)
                        {
                            N.LL4[c].transform.position = new Vector3(-13, 0, 0);
                        }
                    }

                    break;

                case 2:

                    if (collision.CompareTag("T2"))
                    {
                        SNL.text = "T";

                        N.contlt++;

                        for (int c = 0; c < N.LL5.Count; c++)
                        {
                            N.LL5[c].transform.position = new Vector3(-13, 0, 0);
                        }


                    }
                    if (collision.CompareTag("E"))
                    {
                        SNL.text = "TE";

                        N.contlt++;

                        for (int c = 0; c < N.LL6.Count; c++)
                        {
                            N.LL6[c].transform.position = new Vector3(-13, 0, 0);
                        }

                    }
                    if (collision.CompareTag("K1"))
                    {
                        SNL.text = "TEK";

                        N.contlt++;

                        for (int c = 0; c < N.LL7.Count; c++)
                        {
                            N.LL7[c].transform.position = new Vector3(-13, 0, 0);
                        }
                    }
                    if (collision.CompareTag("I2"))
                    {
                        SNL.text = "TEKI";

                        N.contlt++;

                        for (int c = 0; c < N.LL8.Count; c++)
                        {
                            N.LL8[c].transform.position = new Vector3(-13, 0, 0);
                        }
                    }

                    if (collision.CompareTag("T3"))
                    {
                        SNL.text = "TEKIT";

                        N.contlt++;


                        for (int c = 0; c < N.LL9.Count; c++)
                        {
                            N.LL9[c].transform.position = new Vector3(-13, 0, 0);
                        }
                    }

                    if (collision.CompareTag("L2"))
                    {
                        SNL.text = "TEKITL";



                        N.contlt++;

                        x = 4;

                        for (int c = 0; c < N.LL10.Count; c++)
                        {
                            N.LL10[c].transform.position = new Vector3(-13, 0, 0);
                        }
                    }

                    break;

                case 3:

                    if (collision.CompareTag("K2"))
                    {
                        SNL.text = "K";

                        N.contlt++;


                        for (int c = 0; c < N.LL11.Count; c++)
                        {
                            N.LL11[c].transform.position = new Vector3(-13, 0, 0);
                        }


                    }
                    if (collision.CompareTag("O"))
                    {
                        SNL.text = "KO";

                        N.contlt++;

                        for (int c = 0; c < N.LL12.Count; c++)
                        {
                            N.LL12[c].transform.position = new Vector3(-13, 0, 0);
                        }

                    }
                    if (collision.CompareTag("L2"))
                    {
                        SNL.text = "KOL";

                        N.contlt++;

                        for (int c = 0; c < N.LL13.Count; c++)
                        {
                            N.LL13[c].transform.position = new Vector3(-13, 0, 0);
                        }
                    }
                    if (collision.CompareTag("I3"))
                    {
                        SNL.text = "KOLI";


                        N.contlt++;

                        x = 4;

                        for (int c = 0; c < N.LL14.Count; c++)
                        {
                            N.LL14[c].transform.position = new Vector3(-13, 0, 0);
                        }
                    }

                    break;
            }
        }

        if (N.lvl == 3)
        {
            switch (N.contplb)
            {
                case 1:

                    if (collision.CompareTag("K1"))
                    {
                        SNL.text = "K";

                        N.contlt++;

                        for (int c = 0; c < N.LL1.Count; c++)
                        {
                            N.LL1[c].transform.position = new Vector3(-13, 0, 0);
                        }


                    }
                    if (collision.CompareTag("E"))
                    {
                        SNL.text = "KE";

                        N.contlt++;

                        for (int c = 0; c < N.LL2.Count; c++)
                        {
                            N.LL2[c].transform.position = new Vector3(-13, 0, 0);
                        }

                    }
                    if (collision.CompareTag("N1"))
                    {
                        SNL.text = "KEN";

                        N.contlt++;

                        for (int c = 0; c < N.LL3.Count; c++)
                        {
                            N.LL3[c].transform.position = new Vector3(-13, 0, 0);
                        }
                    }
                    if (collision.CompareTag("A1"))
                    {
                        SNL.text = "KENA";

                        N.contlt++;

                        x = 4;

                        for (int c = 0; c < N.LL4.Count; c++)
                        {
                            N.LL4[c].transform.position = new Vector3(-13, 0, 0);
                        }
                    }

                    break;

                case 2:

                    if (collision.CompareTag("T1"))
                    {
                        SNL.text = "T";

                        N.contlt++;

                        for (int c = 0; c < N.LL5.Count; c++)
                        {
                            N.LL5[c].transform.position = new Vector3(-13, 0, 0);
                        }


                    }
                    if (collision.CompareTag("E2"))
                    {
                        SNL.text = "TE";

                        N.contlt++;

                        for (int c = 0; c < N.LL6.Count; c++)
                        {
                            N.LL6[c].transform.position = new Vector3(-13, 0, 0);
                        }

                    }
                    if (collision.CompareTag("M"))
                    {
                        SNL.text = "TEM";

                        N.contlt++;

                        for (int c = 0; c < N.LL7.Count; c++)
                        {
                            N.LL7[c].transform.position = new Vector3(-13, 0, 0);
                        }
                    }
                    if (collision.CompareTag("O"))
                    {
                        SNL.text = "TEMO";

                        N.contlt++;

                        for (int c = 0; c < N.LL8.Count; c++)
                        {
                            N.LL8[c].transform.position = new Vector3(-13, 0, 0);
                        }
                    }

                    if (collision.CompareTag("U"))
                    {
                        SNL.text = "TEMOU";

                        N.contlt++;


                        for (int c = 0; c < N.LL9.Count; c++)
                        {
                            N.LL9[c].transform.position = new Vector3(-13, 0, 0);
                        }
                    }

                    if (collision.CompareTag("A2"))
                    {
                        SNL.text = "TEMOUA";



                        N.contlt++;

                        x = 4;

                        for (int c = 0; c < N.LL10.Count; c++)
                        {
                            N.LL10[c].transform.position = new Vector3(-13, 0, 0);
                        }
                    }

                    break;

                case 3:

                    if (collision.CompareTag("N2"))
                    {
                        SNL.text = "N";

                        N.contlt++;


                        for (int c = 0; c < N.LL11.Count; c++)
                        {
                            N.LL11[c].transform.position = new Vector3(-13, 0, 0);
                        }


                    }
                    if (collision.CompareTag("A3"))
                    {
                        SNL.text = "NA";

                        N.contlt++;

                        for (int c = 0; c < N.LL12.Count; c++)
                        {
                            N.LL12[c].transform.position = new Vector3(-13, 0, 0);
                        }

                    }
                    if (collision.CompareTag("N3"))
                    {
                        SNL.text = "NAN";

                        N.contlt++;

                        for (int c = 0; c < N.LL13.Count; c++)
                        {
                            N.LL13[c].transform.position = new Vector3(-13, 0, 0);
                        }
                    }
                    if (collision.CompareTag("A4"))
                    {
                        SNL.text = "NANA";


                        N.contlt++;

                        x = 4;

                        for (int c = 0; c < N.LL14.Count; c++)
                        {
                            N.LL14[c].transform.position = new Vector3(-13, 0, 0);
                        }
                    }

                    break;
            }
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

        if(N.lvl==1)
        {
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
        }


        if (N.lvl == 2)
        {
            if (N.contplb == 1)
            {
                textonahuatl.text = "TALI";
            }

            if (N.contplb == 2)
            {
                textonahuatl.text = "TEKITL";
            }

            if (N.contplb == 3)
            {
                textonahuatl.text = "KOLI";
            }
        }


        if (N.lvl == 3)
        {
            if (N.contplb == 1)
            {
                textonahuatl.text = "KENA";
            }

            if (N.contplb == 2)
            {
                textonahuatl.text = "TEMOUI";
            }

            if (N.contplb == 3)
            {
                textonahuatl.text = "NANA";
            }
        }



        if (timercartel>0.2f)
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

    public void caminarlvl2()
    {

        if(N.lvl==2)
        {
            if (gameObject.transform.position.x < -4)
            {
                gameObject.transform.position = gameObject.transform.position + new Vector3(vel, 0, 0) * Time.deltaTime * 2;
            }
            else
            {
                Sprite.flipX = spriteX;
                animator.SetBool("quieto", poseniño3);
            }

            if (A.gameObject.transform.position.x < -6)
            {
                A.gameObject.transform.position = A.gameObject.transform.position + new Vector3(vel2, 0, 0) * Time.deltaTime * 2;

                A.animator.SetBool("caminapache", true);
            }
            else
            {
                A.animator.SetBool("caminapache", posapache2);
            }

            if (D.lineindex == 6)
            {
                timertexto += Time.deltaTime;

                TP.paneldpergamino.SetActive(true);

                if (timertexto > 1)
                {
                    TP.x = true;
                }

            }



            if (timerpergamino > 1)
            {

                TP.paneldpergamino.SetActive(false);
                D.escribir.Pause();
                sonido.sonDialogo.Pause();
                titulo.SetActive(false);


                if (A.gameObject.transform.position.x > -12)
                {
                    A.SpriteRenderer.flipX = true;

                    A.gameObject.transform.position = A.gameObject.transform.position + new Vector3(-2, 0, 0) * Time.deltaTime * 2;

                    A.animator.SetBool("caminapache", true);
                }
                else
                {
                    spriteX = false;

                    vel2 = 0;

                    D.comenzarJuego();

                    poseniño3 = false;

                    timerpergamino = 0;

                    ok = false;

                }
            }

        }


    }
    public void caminar()
    {
        if(N.lvl==1||N.lvl==3)
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
                timertexto += Time.deltaTime;

                TP.paneldpergamino.SetActive(true);

                if (timertexto > 1)
                {
                    TP.x = true;
                }

            }



            if (timerpergamino > 1)
            {

                TP.paneldpergamino.SetActive(false);
                D.escribir.Pause();
                sonido.sonDialogo.Pause();
                titulo.SetActive(false);


                if (A.gameObject.transform.position.x < 14)
                {
                    if (posapache == true)
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
        

    }


    public void salirfinal()
    {

        if (DF.lineindex == 4)
        {
               
           A.animator.SetBool("caminapache", true);
           D.paneldialogo.SetActive(false);
           poseniño = false;

            if(N.lvl == 1||N.lvl==3)
            {
                A.SpriteRenderer.flipX = false;
                A.gameObject.transform.position = A.gameObject.transform.position + new Vector3(2, 0, 0) * Time.deltaTime * 2;
                vel = 1;
            }


            if (N.lvl == 2)
            {
                A.SpriteRenderer.flipX = true;
                A.gameObject.transform.position = A.gameObject.transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * 2;
                vel = -1;
                poseniño3=false;
            }




        }

    }

    public void Ok()
    {

        ok = true;


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

            for (int u = 0; u < N.mon.Count; u++)
            {
                N.mon[u].SetActive(false);
            }

            if(N.lvl==1||N.lvl==3)
            {
                if (gameObject.transform.position.x > 2)
                {
                    animator.SetBool("quieto", poseniño);
                    vel = 0;

                    if (A.gameObject.transform.position.x > 5)
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

            if (N.lvl == 2)
            {
                if (gameObject.transform.position.x > -2)
                {

                    animator.SetBool("quieto", poseniño);
                    
                    vel = 0;


                    spriteX = true;


                    if (A.gameObject.transform.position.x < -4)
                    {
                        posapache2= true;

                        A.SpriteRenderer.flipX = false;

                        A.gameObject.transform.position = A.gameObject.transform.position + new Vector3(1, 0, 0) * Time.deltaTime * 2;
                    }
                    else
                    {
                        A.animator.SetBool("caminapache", false);
                        dialogofinal = true;
                    }


                }
            }




        }
    }

    public void pergaminofinal()
    {
        if (N.lvl == 1 || N.lvl == 3)
        {
            if (gameObject.transform.position.x > 11)
            {
                panelpergamino.SetActive(true);
                TP.paneldpergamino.SetActive(true);
                timerpergaminofinal += Time.deltaTime;


                if (timerpergaminofinal > 1)
                {
                    TP.x = true;
                    TP.Txtpanel.SetActive(true);

                    if (cualdiag == true)
                    {
                        TP.siguientedialogo();
                        cualdiag = false;
                    }


                }
            }
        }

        if(N.lvl==2)
        {
            if (gameObject.transform.position.x < -11)
            {
                panelpergamino.SetActive(true);
                TP.paneldpergamino.SetActive(true);
                timerpergaminofinal += Time.deltaTime;


                if (timerpergaminofinal > 2)
                {
                    TP.x = true;
                    TP.Txtpanel.SetActive(true);

                    if (cualdiag == true)
                    {
                        TP.siguientedialogo();
                        cualdiag = false;
                    }


                }
            }
        }

        


    }
}
