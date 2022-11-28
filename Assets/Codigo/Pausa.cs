using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public static Pausa instance;
    [SerializeField] public GameObject btnpausa;
    [SerializeField] public GameObject menupausa;
    [SerializeField] private GameObject btnbrincar;
    [SerializeField] private GameObject btnajustes;

    [SerializeField] private GameObject objjsonidopausa;
    private AudioSource Sonidopausa;
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
        sonido.sonFond.Pause();

    }

    public void continuar()
    {
        sonido.sonSelect.Play();
        sonido.sonFond.Play();
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
    public void comprarMoneda()
    {
        IAPManager.instance.BuyConsumable();
    }
    public void reinciar()
    {
        sonido.sonSelect.Play();
        Time.timeScale=1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void salir()
    {
        sonido.sonSwitch.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(4);
    }
}
