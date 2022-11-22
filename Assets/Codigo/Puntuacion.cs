using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Puntuacion : MonoBehaviour
{

    public float puntos=0;

    float a;

    public TextMeshProUGUI puntuacion;
    AudioUI sonido;
    private void Awake()
    {
        sonido = GameObject.FindObjectOfType<AudioUI>();
    }


    // Update is called once per frame
    void Update()
    {
        a+=Time.deltaTime;

        if (a > 1)
        {
            puntos += Time.deltaTime;

            puntuacion.text = puntos.ToString("f0");
        }
        //if (puntuacion.text == "0")
        //{
        //    sonido.sonFond.Play();
            
        //}


    }
}
