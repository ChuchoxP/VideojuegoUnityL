using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ajustesnivel : MonoBehaviour
{

    [SerializeField] private GameObject menuajustes;
    [SerializeField] private GameObject menupausa;
    AudioUI sonido;
    // Start is called before the first frame update
    private void Awake()
    {
        sonido = GameObject.FindObjectOfType<AudioUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ajustes()
    {
        sonido.sonSelect.Play();
        menuajustes.SetActive(true);
        menupausa.SetActive(false);
    }

    public void cerrarajustes()
    {
        sonido.sonSelect.Play();
        menupausa.SetActive(true);
        menuajustes.SetActive(false);
    }
}
