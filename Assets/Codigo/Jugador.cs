using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class Jugador : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    private Animator animator;

    public bool jump=false;

    NivelesBase N;

    public GameObject v1;
    public GameObject v2;
    public GameObject v3;

    public GameObject sv1;
    public GameObject sv2;
    public GameObject sv3;

    public TextMeshProUGUI SL1;
    public TextMeshProUGUI SL2;
    public TextMeshProUGUI SL3;
    public TextMeshProUGUI SL4;

    [SerializeField] private GameObject objjsonidomoneda;
    private AudioSource Sonidomoneda;


    [SerializeField] private GameObject objjsonidosalto;
    private AudioSource Sonidosalto;

    public TextMeshProUGUI totmonedas;
    public int tot = 0;

    [SerializeField] private GameObject btnyoutube;
    [SerializeField] private GameObject btnpaypal;
    [SerializeField] private GameObject btnsalir;
    [SerializeField] private GameObject menupago;

    private int v=3;

    int x =0;

    public int plbrdm;

    public GameObject uno;
    public string dos;
    public string tres;
    public string cuatro;

    // Start is called before the first frame update
    void Start()
    {


        //plbrdm = Random.Range(1, 4);
        plbrdm = 1;

        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        Sonidomoneda=objjsonidomoneda.GetComponent<AudioSource>();
        Sonidosalto = objjsonidosalto.GetComponent<AudioSource>();
        N = FindObjectOfType<NivelesBase>();



    }

    private void Update()
    {

        switch (plbrdm)
        {
            case 1:
                {
                    SL1.text = "T";
                    SL2.text = "A";
                    SL3.text = "V";
                    SL4.text = "O";
                };
                break;

            case 2:
                {
                    SL1.text = "P";
                    SL2.text = "A";
                    SL3.text = "C";
                    SL4.text = "O";
                };
                break;
            case 3:
                {
                    SL1.text = "T";
                    SL2.text = "A";
                    SL3.text = "T";
                    SL4.text = "A";
                };
                break;
        }

        uno = SL1;
        dos = SL2.text;
        tres = SL3.text;
        cuatro = SL4.text;





        if (v==2)
        {
            Destroy(v3.gameObject);
            sv3.SetActive(true);
        }
        else if (v==1)
        {
            Destroy(v2.gameObject);
            sv2.SetActive(true);
        }
        else if(v==0)
        {
            Destroy(v1.gameObject);
            sv1.SetActive(true);

            gameover();

            N.LA1.text = "";
            N.LA2.text = "";
            N.LA3.text = "";
            N.LA4.text = "";


        }



        totmonedas.text = tot.ToString();

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
            rigidbody2D.AddForce(new Vector2(0, 300));
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


        if (collision.CompareTag("T1"))
        {
            SL1.text = "";
            N.LA1.text = uno;

            N.contlt++;

            for (int c = 0; c < N.LL1.Count; c++)
            {
               N.LL1[c].transform.position = new Vector3(-13, 0, 0);
            }


        }
        if (collision.CompareTag("A1"))
        {
            SL2.text = "";
            N.LA2.text = dos;

            N.contlt++;

            for (int c = 0; c < N.LL2.Count; c++)
            {
                N.LL2[c].transform.position = new Vector3(-13, 0, 0);
            }

        }
        if (collision.CompareTag("T2"))
        {
            SL3.text = "";
            N.LA3.text = tres;

            N.contlt++;

            for (int c = 0; c < N.LL3.Count; c++)
            {
                N.LL3[c].transform.position = new Vector3(-13, 0, 0);
            }
        }
        if (collision.CompareTag("A2"))
        {
            SL4.text = "";
            N.LA4.text = cuatro;

            N.contlt++;

            plbrdm++;

            x = 4;

            for (int c = 0; c < N.LL4.Count; c++)
            {
                N.LL4[c].transform.position = new Vector3(-13, 0, 0);
            }
        }

        if (collision.CompareTag("obstaculo"))
        {
           // v--;
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




}
