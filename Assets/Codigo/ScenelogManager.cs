﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static NetworkManager;

public class ScenelogManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField m_userNameInput = null;
    [SerializeField] private TMP_InputField m_emailInput = null;
    [SerializeField] private TMP_InputField m_pswInput = null;
    [SerializeField] private TMP_InputField m_ppswInput = null;
    [SerializeField] public TMP_Text m_validarInput = null;

    [SerializeField] private GameObject m_registerUI = null;
    [SerializeField] private GameObject m_loginUI = null;

    [SerializeField] private TMP_InputField m_loginUserNameImput = null;
    [SerializeField] private TMP_InputField m_loginPasswordImput = null;

    Sesiones ses;
    public void ShowLogin()
    {
        clearInput();
        m_validarInput.text = null;
        m_registerUI.SetActive(false);
        m_loginUI.SetActive(true);
    }
    public void ShowIni()
    {
        clearInput();
        m_validarInput.text = null;
        m_registerUI.SetActive(false);
        m_loginUI.SetActive(false);
        ses.btnjugar.SetActive(true);
        ses.menulogeo.SetActive(false);
        ses.btniniciarsesion.SetActive(true);
        ses.btnfaccebook.SetActive(true);
        ses.texto.SetActive(true);
    }
    public void clearInput()
    {
        m_loginPasswordImput.text = null;
        m_loginUserNameImput.text = null;
        m_userNameInput.text = null;
        m_emailInput.text = null;
        m_pswInput.text = null;
        m_ppswInput.text = null;
        
    }
    public void ShowRegister()
    {
        m_validarInput.text = null;
        m_registerUI.SetActive(true);
        m_loginUI.SetActive(false);
    }
    
    

    private NetworkManager m_networkManager = null;

    private void Awake()
    {
        m_networkManager = GameObject.FindObjectOfType<NetworkManager>();
        ses = GameObject.FindObjectOfType<Sesiones>();
    }
    public void SubmitLogin()
    {
        if (m_loginUserNameImput.text == "" || m_loginPasswordImput.text == "")
        {
            m_validarInput.text = "Por favor llena todos los campos";
            return;
        }
        m_validarInput.text = "Cargando.....";
        m_networkManager.CheckUser(m_loginUserNameImput.text, m_loginPasswordImput.text, delegate (Response response)
        {

            m_validarInput.text = response.message;
            if (response.done==true)
            {
                SceneManager.LoadScene(3);
                ses.Sonidomenu.Pause();
            }
            

        });
       
    }
    public void SubmitRegister()
    {
        if (m_userNameInput.text == "" || m_emailInput.text == "" || m_pswInput.text == "" || m_ppswInput.text == "")
        {
            m_validarInput.text = "Por favor llena todos los campos";
            return;
        }
        if (m_pswInput.text == m_ppswInput.text)
        {
            m_networkManager.CreateUser(m_userNameInput.text, m_emailInput.text, m_pswInput.text, delegate (Response response)
            {
                m_validarInput.text = response.message;
                m_validarInput.text = "Se registro correctamente";
                clearInput();
                if (response.done == true)
                {
                    SceneManager.LoadScene(3);
                    ses.Sonidomenu.Pause();
                }

            });
        }
        else
        {
            m_validarInput.text = "Las contraseñas no son iguales";
        }

    }

}
