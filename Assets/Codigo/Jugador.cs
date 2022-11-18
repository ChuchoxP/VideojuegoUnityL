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

    public bool jump=false;

    NivelesBase N;
    Dialogos D;
    Apache A;

    public GameObject v1;
    public GameObject v2;
    public GameObject v3;

    public GameObject sv1;
    public GameObject sv2;
    public GameObject sv3;
    public GameObject cartel;

    public TextMeshProUGUI SNL;
    public TextMeshProUGUI textonahuatl;
    public TextMeshProUGUI textoespanol;


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



    public string letra;
    
    private void Awake()
    {
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

        N = FindObjectOfType<NivelesBase>();
        D = FindObjectOfType<Dialogos>();
        A = FindObjectOfType<Apache>();



    }

    private void Update()
    {
        caminar();

        vidas();


        totmonedas.text = tot.ToString();


        if(x==4)
        {
            cartels();
        }

        timer += Time.deltaTime;

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
                if (collision.CompareTag("T2"))
                {
                    SNL.text = "TAT";

                    N.contlt++;

                    for (int c = 0; c < N.LL3.Count; c++)
                    {
                        N.LL3[c].transform.position = new Vector3(-13, 0, 0);
                    }
                }
                if (collision.CompareTag("A2"))
                {
                    SNL.text = "TATA";

                    N.contlt++;

                    x = 4;

                    for (int c = 0; c < N.LL4.Count; c++)
                    {
                        N.LL4[c].transform.position = new Vector3(-13, 0, 0);
                    }
                }

                break;

            case 2:

                if (collision.CompareTag("N1"))
                {
                    SNL.text = "N";

                    N.contlt++;

                    for (int c = 0; c < N.LL5.Count; c++)
                    {
                        N.LL5[c].transform.position = new Vector3(-13, 0, 0);
                    }


                }
                if (collision.CompareTag("A1"))
                {
                    SNL.text = "NA";

                    N.contlt++;

                    for (int c = 0; c < N.LL6.Count; c++)
                    {
                        N.LL6[c].transform.position = new Vector3(-13, 0, 0);
                    }

                }
                if (collision.CompareTag("N2"))
                {
                    SNL.text = "NAN";

                    N.contlt++;

                    for (int c = 0; c < N.LL7.Count; c++)
                    {
                        N.LL7[c].transform.position = new Vector3(-13, 0, 0);
                    }
                }
                if (collision.CompareTag("A2"))
                {
                    SNL.text = "NANA";



                    N.contlt++;

                    x = 4;

                    for (int c = 0; c < N.LL8.Count; c++)
                    {
                        N.LL8[c].transform.position = new Vector3(-13, 0, 0);
                    }
                }

                break;

            case 3:

                if (collision.CompareTag("C1"))
                {
                    SNL.text = "C";

                    N.contlt++;


                    for (int c = 0; c < N.LL9.Count; c++)
                    {
                        N.LL9[c].transform.position = new Vector3(-13, 0, 0);
                    }


                }
                if (collision.CompareTag("A1"))
                {
                    SNL.text = "CA";

                    N.contlt++;

                    for (int c = 0; c < N.LL10.Count; c++)
                    {
                        N.LL10[c].transform.position = new Vector3(-13, 0, 0);
                    }

                }
                if (collision.CompareTag("L1"))
                {
                    SNL.text = "CAL";

                    N.contlt++;

                    for (int c = 0; c < N.LL11.Count; c++)
                    {
                        N.LL11[c].transform.position = new Vector3(-13, 0, 0);
                    }
                }
                if (collision.CompareTag("I1"))
                {
                    SNL.text = "CALI";


                    N.contlt++;

                    x = 4;

                    for (int c = 0; c < N.LL12.Count; c++)
                    {
                        N.LL12[c].transform.position = new Vector3(-13, 0, 0);
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
        Time.timeScale = 0f;
        btnyoutube.SetActive(true);
        btnpaypal.SetActive(true);
        btnsalir.SetActive(true);
        menupago.SetActive(true);

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



    }


    public void cartels()
    {

        timercartel+=Time.deltaTime;

        cartel.SetActive(true);


        if (N.contplb == 1)
        {
            textonahuatl.text = "TATA";

            textoespanol.text = "PAPÁ";



        }

        if (N.contplb == 2)
        {
            textonahuatl.text = "NANA";

            textoespanol.text = "MAMÁ";

        }

        if (N.contplb == 3)
        {
            textonahuatl.text = "CALI";

            textoespanol.text = "CASA";
        }
        

        if(timercartel>3)
        {

            cartel.SetActive(false);

            textonahuatl.text = "";
            textoespanol.text = "";

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
            gameObject.transform.position = gameObject.transform.position + new Vector3(1, 0, 0) * Time.deltaTime * 2;
            animator.SetBool("quieto", false);
            D.escribir.Pause();
            A.GetComponent<BoxCollider2D>().enabled = false;

        }

        if(gameObject.transform.position.x > -4)
        {
            D.comenzarJuego();
        }

    }





}
