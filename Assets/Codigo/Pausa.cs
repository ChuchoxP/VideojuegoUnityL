using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public static Pausa instance;
    [SerializeField] private GameObject btnpausa;
    [SerializeField] private GameObject menupausa;
    [SerializeField] private GameObject btnbrincar;
    [SerializeField] private GameObject btnajustes;

    [SerializeField] private GameObject objjsonidopausa;
    private AudioSource Sonidopausa;

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
    void Start()
    {
        Sonidopausa = objjsonidopausa.GetComponent<AudioSource>();
            
    }




    public void pausa()
    {
        Time.timeScale = 0f;
        btnpausa.SetActive(false);
        menupausa.SetActive(true);
        btnbrincar.SetActive(false);
        btnajustes.SetActive(true);
        Sonidopausa.Play();

    }

    public void continuar()
    {
        Time.timeScale =1f;
        btnpausa.SetActive(true);
        menupausa.SetActive(false);
        btnbrincar.SetActive(true);
        btnajustes.SetActive(false);
    }

    public void continuarEx()
    {
        Time.timeScale = 1f;
        btnpausa.SetActive(true);
        menupausa.SetActive(false);
        btnbrincar.SetActive(true);
        btnajustes.SetActive(false);
        Jugador.instance.gameoverEx();
    }

    public void reinciar()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void salir()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(3);
    }
}
