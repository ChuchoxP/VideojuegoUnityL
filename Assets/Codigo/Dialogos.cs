using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogos : MonoBehaviour
{

    [SerializeField, TextArea(4, 6)] private string[] lineadialogo;
    [SerializeField] private GameObject paneldialogo;
    [SerializeField] private TextMeshProUGUI Txtpanel;

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


    // Update is called once per frame
    private void Start()
    {
        J = FindObjectOfType<Jugador>();
    }

    void Update()
    {
        if (!dialogaux)
        {
            iniciardialogo();

            paneldialogo.SetActive(true);
            paneljueego.SetActive(false);
            confjuego.SetActive(false);
            btnOmitir.SetActive(false);
            moneda.SetActive(false);
        }
        else if (Txtpanel.text == lineadialogo[lineindex])
        {
            btnsiguiente.SetActive(true);
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

        lineindex++;

        if (lineindex < lineadialogo.Length)
        {
            StartCoroutine(verlineas());
        }
        else
        {
            comenzarJuego();
        }
    }

    public void comenzarJuego()
    {
        forastero.SetActive(false);
        J.animator.SetBool("Corriendo", true);
        dialogaux = true;
        paneldialogo.SetActive(false);
        paneljueego.SetActive(true);
        confjuego.SetActive(true);
        moneda.SetActive(true);
        lineindex = 0;
    }
}
