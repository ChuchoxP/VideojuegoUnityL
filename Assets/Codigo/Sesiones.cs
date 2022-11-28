using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sesiones : MonoBehaviour
{
    [SerializeField] public GameObject btnjugar;
    [SerializeField] private GameObject btnajustes;
    [SerializeField] private GameObject btninfo;
    [SerializeField] public GameObject menulogeo;
    [SerializeField] public GameObject btniniciarsesion;
    [SerializeField] private GameObject menuregistro;
    [SerializeField] public GameObject menuajustes;
    [SerializeField] public GameObject menuinfo;
    [SerializeField] public GameObject texto;
    [SerializeField] public TMP_Text m_validarInput = null;
    [SerializeField] private GameObject objjsonidomenu;
    public AudioSource Sonidomenu;

    public TMP_InputField txtuser;
    public TMP_InputField txtpsw;

    AudioUI sonido;
    private void Awake()
    {
        sonido = GameObject.FindObjectOfType<AudioUI>();
    }

    private void Start()
    {
        Sonidomenu = objjsonidomenu.GetComponent<AudioSource>();
        Sonidomenu.Play();
        
    }


    public void logear()
    {
        sonido.sonSelect.Play();
        texto.SetActive(false);
        btnjugar.SetActive(false);
        menulogeo.SetActive(true);
        btniniciarsesion.SetActive(false);
    }
    public void anuncios()
    {
        SceneManager.LoadScene(4);
    }

    public void logeoexitoso()
    {
        if (txtuser.text=="Equipo" && txtpsw.text=="1234")
        {
            SceneManager.LoadScene(3);
            Sonidomenu.Pause();

        }
        else
        {
            Debug.Log("Usuario y/o contraseña no valida");
        }

    }

    public void cerrarlogeo()
    {
        m_validarInput.text = null;
        btnjugar.SetActive(true);
        menulogeo.SetActive(false);
        btniniciarsesion.SetActive(true);
        texto.SetActive(true);
    }

    public void cerrarregistro()
    {
        menulogeo.SetActive(true);
        menuregistro.SetActive(false);

    }

    public void registro()
    {
        menulogeo.SetActive(false);
        menuregistro.SetActive(true);
    }

    public void registroexitoso()
    {
        menulogeo.SetActive(true);
        menuregistro.SetActive(false);
    }


    public void ajustes()
    {
        sonido.sonSelect.Play();
        btnjugar.SetActive(false);
        btninfo.SetActive(false);
        btnajustes.SetActive(false);
        btniniciarsesion.SetActive(false);
        menuajustes.SetActive(true);
        menulogeo.SetActive(false);
        menuregistro.SetActive(false);
        texto.SetActive(false);
    }
    public void info()
    {
        sonido.sonSelect.Play();
        btnjugar.SetActive(false);
        btnajustes.SetActive(false);
        btninfo.SetActive(false);
        btniniciarsesion.SetActive(false);
        menulogeo.SetActive(false);
        menuregistro.SetActive(false);
        texto.SetActive(false);
        menuinfo.SetActive(true);
    }
    public void cerrarInfo()
    {
        sonido.sonSwitch.Play();
        btnjugar.SetActive(true);
        btninfo.SetActive(true);
        btnajustes.SetActive(true);
        btniniciarsesion.SetActive(true);
        texto.SetActive(true);
        menuinfo.SetActive(false);

    }

    public void cerrarajustes()
    {
        sonido.sonSelect.Play();
        btnjugar.SetActive(true);
        btninfo.SetActive(true);
        btnajustes.SetActive(true);
        btniniciarsesion.SetActive(true);
        menuajustes.SetActive(false);
        texto.SetActive(true);
    }

    public void irTerminosandPriv()
    {
        sonido.sonSelect.Play();
        Application.OpenURL("https://prynahuatltec.000webhostapp.com/notices");
    }





}
