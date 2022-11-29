using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AjustesMenu : MonoBehaviour
{

    [SerializeField] public GameObject btnajustes;
    [SerializeField] private GameObject menuinicio;
    [SerializeField] public GameObject menuajustes;
    //[SerializeField] private GameObject btnReiniciar;

    //[SerializeField] private GameObject btnnivel2bloqueado;
    //[SerializeField] private GameObject btnnivel3bloqueado;
    //[SerializeField] private GameObject btnnivel2;
    //[SerializeField] private GameObject btnnivel3;

    [SerializeField] private TextMeshProUGUI txtvalidacion;

    Ajustespergamino AP;

    int nivel;


    AudioUI sonido;
    // Start is called before the first frame update
    private void Awake()
    {
        sonido = GameObject.FindObjectOfType<AudioUI>();
    }
    private void Start()
    {
        AP = FindObjectOfType<Ajustespergamino>();
        sonido.sonFond.Play();

        nivel = PlayerPrefs.GetInt("nivel", 0);

    }
    // Update is called once per frame
    void Update()
    {
        //niveles();

        Debug.Log(nivel);
    }

    public void ajustes()
    {
        sonido.sonSelect.Play();
        btnajustes.SetActive(false);
        menuajustes.SetActive(true);
        menuinicio.SetActive(false);
    }

    public void cerrarajustes()
    {
        sonido.sonSelect.Play();
        btnajustes.SetActive(true);
        menuajustes.SetActive(false);
        menuinicio.SetActive(true);
    }

    //public void niveles()
    //{
    //    if(PlayerPrefs.GetInt("nivel",0)==2)
    //    {
    //        btnnivel2bloqueado.SetActive(false);
    //        btnnivel2.SetActive(true);
    //        btnReiniciar.SetActive(true);
    //    }

    //    if(PlayerPrefs.GetInt("nivel", 0) == 3)
    //    {
    //        btnnivel3bloqueado.SetActive(false);
    //        btnnivel3.SetActive(true);
    //    }
    //}

    //public void reiniciar()
    //{
    //    PlayerPrefs.SetInt("nivel", 1);
    //    PlayerPrefs.Save();
    //    btnnivel2bloqueado.SetActive(true);
    //    btnnivel2.SetActive(false);
    //    btnnivel3bloqueado.SetActive(true);
    //    btnnivel3.SetActive(false);
    //    btnReiniciar.SetActive(false);

    //}

    //public void validar2()
    //{
    //    txtvalidacion.text = "Se requiere terminar nivel 1";
    //}

    //public void validar3()
    //{
    //    txtvalidacion.text = "Se requiere terminar nivel 2";
    //}

}
