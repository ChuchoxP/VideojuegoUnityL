using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escenas : MonoBehaviour
{
    public void LoadScenenivel1()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void LoadScenenivel2()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void LoadScenenivel3()
    {
        SceneManager.LoadScene(5);
        Time.timeScale = 1;
    }

    public void LoadScenemenu()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadScenelogin()
    {
        SceneManager.LoadScene(0);
    }



}
