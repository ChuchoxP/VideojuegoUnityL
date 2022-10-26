using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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

    private int v=4;


    // Start is called before the first frame update
    void Start()
    {


        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        Sonidomoneda=objjsonidomoneda.GetComponent<AudioSource>();
        Sonidosalto = objjsonidosalto.GetComponent<AudioSource>();
        N = FindObjectOfType<NivelesBase>();



    }

    private void Update()
    {
        if(v==3)
        {
            Destroy(v3.gameObject);
            sv3.SetActive(true);
        }
        else if (v==2)
        {
            Destroy(v2.gameObject);
            sv2.SetActive(true);
        }
        else if(v==1)
        {
            Destroy(v1.gameObject);
            sv1.SetActive(true);
            

        }
        else if (v==0)
        {
            gameover();
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
            Destroy(N.SL1.gameObject);
            N.LA1.SetActive(true);

            N.contlt++;

            for (int c = 0; c < N.LL1.Count; c++)
            {
               N.LL1[c].transform.position = new Vector3(-13, 0, 0);
            }


        }
        if (collision.CompareTag("A1"))
        {
            Destroy(N.SL2.gameObject);
            N.LA2.SetActive(true);

            N.contlt++;

            for (int c = 0; c < N.LL2.Count; c++)
            {
                N.LL2[c].transform.position = new Vector3(-13, 0, 0);
            }

        }
        if (collision.CompareTag("T2"))
        {
            Destroy(N.SL3.gameObject);
            N.LA3.SetActive(true);

            N.contlt++;

            for (int c = 0; c < N.LL3.Count; c++)
            {
                N.LL3[c].transform.position = new Vector3(-13, 0, 0);
            }
        }
        if (collision.CompareTag("A2"))
        {
            Destroy(N.SL4.gameObject);
            N.LA4.SetActive(true);

            N.contlt++;

            for (int c = 0; c < N.LL4.Count; c++)
            {
                N.LL4[c].transform.position = new Vector3(-13, 0, 0);
            }
        }
        if (collision.CompareTag("obstaculo"))
        {
            v--;
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
