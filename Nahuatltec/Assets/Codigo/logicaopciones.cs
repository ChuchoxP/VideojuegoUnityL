using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logicaopciones : MonoBehaviour
{


    public Sesiones panelopciones;


    // Start is called before the first frame update
    void Start()
    {
        panelopciones = GameObject.FindGameObjectWithTag("Opciones").GetComponent<Sesiones>();
    }

    // Update is called once per frame
    void Update()
    {


        
    }

    public void ajustess()
    {
        panelopciones.menuajustes.SetActive(true);
    }
}
