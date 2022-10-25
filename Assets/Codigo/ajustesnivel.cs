using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ajustesnivel : MonoBehaviour
{

    [SerializeField] private GameObject menuajustes;
    [SerializeField] private GameObject menupausa;
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
        menuajustes.SetActive(true);
        menupausa.SetActive(false);
    }

    public void cerrarajustes()
    {
        menupausa.SetActive(true);
        menuajustes.SetActive(false);
    }
}
