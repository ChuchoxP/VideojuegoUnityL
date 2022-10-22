using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodIgoajustes : MonoBehaviour
{

    public Slider slider;
    public float slidervalue;
    public Image panelvalue;


    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("brillo",0.5f);

        panelvalue.color = new Color(panelvalue.color.r, panelvalue.color.g, panelvalue.color.b, slider.value);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Guardarslider(float valor)
    {
        slidervalue = valor;
        PlayerPrefs.SetFloat("brillo", slidervalue);
        panelvalue.color = new Color(panelvalue.color.r, panelvalue.color.g, panelvalue.color.b, slider.value);
    }

}
