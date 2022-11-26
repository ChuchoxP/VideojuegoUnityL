using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BrilloSettings : MonoBehaviour
{
    public static BrilloSettings brilloSettings;
    AudioSettings audioSettings;
    public Slider slider;
    public float sliderValue;
    public Image panelBrillo;
    public float valorBlack;
    public float valorWhite;
    // Start is called before the first frame update
    void Start()
    {
        
        slider.value = PlayerPrefs.GetFloat("Brillo", 0.5f);
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, sliderValue / 3);

        slider.value = audioSettings.GetMusicVolume();
    }

    // Update is called once per frame

    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("Brillo", sliderValue);
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, sliderValue / 3);
    }
}
