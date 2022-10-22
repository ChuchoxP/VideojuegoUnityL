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

    public void LoadScenemenu()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadScenelogin()
    {
        SceneManager.LoadScene(0);
    }



}
