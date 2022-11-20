using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escenas : MonoBehaviour
{
    AudioUI sonido;
    private void Awake()
    {
        sonido = GameObject.FindObjectOfType<AudioUI>();
        
    }
   
    public void LoadScenenivel1()
    {
        sonido.sonSelect.Play();
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void LoadScenenivel2()
    {
        sonido.sonSelect.Play();
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void LoadScenenivel3()
    {
        sonido.sonSelect.Play();
        SceneManager.LoadScene(5);
        Time.timeScale = 1;
    }

    public void LoadScenemenu()
    {
        sonido.sonSwitch.Play();
        SceneManager.LoadScene(3);
    }

    public void LoadScenelogin()
    {
        sonido.sonSwitch.Play();
        SceneManager.LoadScene(0);
    }



}
