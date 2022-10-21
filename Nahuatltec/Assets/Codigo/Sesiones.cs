using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sesiones : MonoBehaviour
{
    [SerializeField] private GameObject btnjugar;
    [SerializeField] private GameObject btnajustes;
    [SerializeField] private GameObject menulogeo;
    [SerializeField] private GameObject btniniciarsesion;
    [SerializeField] private GameObject btnfaccebook;
    [SerializeField] private GameObject menuregistro;
    [SerializeField] public GameObject menuajustes;
    [SerializeField] private GameObject texto;


    public TMP_InputField txtuser;
    public TMP_InputField txtpsw;


    public void logear()
    {
        texto.SetActive(false);
        btnjugar.SetActive(false);
        menulogeo.SetActive(true);
        btniniciarsesion.SetActive(false);
        btnfaccebook.SetActive(false);
    }

    public void logeoexitoso()
    {
        if (txtuser.text=="Equipo" && txtpsw.text=="1234")
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            Debug.Log("Usuario y/o contraseña no valida");
        }

    }

    public void cerrarlogeo()
    {
        btnjugar.SetActive(true);
        menulogeo.SetActive(false);
        btniniciarsesion.SetActive(true);
        btnfaccebook.SetActive(true);
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
        btnjugar.SetActive(false);
        btnajustes.SetActive(false);
        btniniciarsesion.SetActive(false);
        btnfaccebook.SetActive(false);
        menuajustes.SetActive(true);
        menulogeo.SetActive(false);
        menuregistro.SetActive(false);
        texto.SetActive(false);
    }

    public void cerrarajustes()
    {
        btnjugar.SetActive(true);
        btnajustes.SetActive(true);
        btniniciarsesion.SetActive(true);
        btnfaccebook.SetActive(true);
        menuajustes.SetActive(false);
        texto.SetActive(true);
    }







}
