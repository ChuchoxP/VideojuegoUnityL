using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjustesMenu : MonoBehaviour
{

    [SerializeField] public GameObject btnajustes;
    [SerializeField] private GameObject menuinicio;
    [SerializeField] public GameObject menuajustes;

    AudioUI sonido;
    // Start is called before the first frame update
    private void Awake()
    {
        sonido = GameObject.FindObjectOfType<AudioUI>();
    }
    private void Start()
    {
        sonido.sonFond.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
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
}
