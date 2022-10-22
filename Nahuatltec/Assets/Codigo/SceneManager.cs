using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static NetworkManager;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private InputField m_userNameInput = null;
    [SerializeField] private InputField m_emailInput = null;
    [SerializeField] private InputField m_pswInput = null;
    [SerializeField] private InputField m_ppswInput = null;
    [SerializeField] public Text m_validarInput = null;

    [SerializeField] private GameObject m_registerUI = null;
    [SerializeField] private GameObject m_loginUI = null;

    [SerializeField] private InputField m_loginUserNameImput = null;
    [SerializeField] private InputField m_loginPasswordImput = null;
    

    public void ShowLogin()
    {
        clearInput();
        m_validarInput.text = null;
        m_registerUI.SetActive(false);
        m_loginUI.SetActive(true);
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
    }
    public void SubmitLogin()
    {
        if (m_loginUserNameImput.text == "" || m_loginPasswordImput.text == "")
        {
            m_validarInput.text = "Por favor llena todos los campos";
            return;
        }

        m_validarInput.text = "Procesando.....";

        m_networkManager.CheckUser(m_loginUserNameImput.text, m_loginPasswordImput.text, delegate (Response response)
        {
            m_validarInput.text = response.message;
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

            });
        }
        else
        {
            m_validarInput.text = "Contrasenas no son iguales";
        }

    }

}
