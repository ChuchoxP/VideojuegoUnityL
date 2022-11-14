using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paypal : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject webBrowser;

    public void EnlacePaypal()
    {
        //Application.OpenURL(enlace);
        //Time.timeScale = 1f;
        //webBrowser.SetActive(true);
        //webBrowser.GetComponent<SimpleWebBrowser.WebBrowser2D>().Navigate("https://www.facebook.com");
    }

    public void AbrirNavPahp()
    {
        Application.OpenURL("https://apigameus.000webhostapp.com/apiuser/");

    }
        

}

