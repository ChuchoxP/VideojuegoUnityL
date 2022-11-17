using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjustesMenu : MonoBehaviour
{

    [SerializeField] public GameObject btnajustes;
    [SerializeField] private GameObject menuinicio;
    [SerializeField] public GameObject menuajustes;

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
        btnajustes.SetActive(false);
        menuajustes.SetActive(true);
        menuinicio.SetActive(false);
    }

    public void cerrarajustes()
    {
        btnajustes.SetActive(true);
        menuajustes.SetActive(false);
        menuinicio.SetActive(true);
    }
}
