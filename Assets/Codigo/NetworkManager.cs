using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviour
{
    Sesiones ses;
    private void Awake()
    {
        ses = GameObject.FindObjectOfType<Sesiones>();
        
    }
    
    public void CreateUser(string username, string email, string pass, Action<Response> response)
    {
        StartCoroutine(CO_CreateUser(username, email, pass, response));
    }
    private IEnumerator CO_CreateUser(string username, string email, string pass, Action<Response> response)
    {

        WWWForm form = new WWWForm();
        form.AddField("usuario", username);
        form.AddField("correo", email);
        form.AddField("contraseña", pass);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/apiuser/apiuser.php", form);

        yield return www.SendWebRequest();
        //Debug.Log(www.downloadHandler.text);
        response(JsonUtility.FromJson<Response>(www.downloadHandler.text));

    }

    public void CheckUser(string username, string pass, Action<Response> response)
    {
        StartCoroutine(CO_CheckUser(username, pass, response));
        
    }

    private IEnumerator CO_CheckUser(string username, string pass, Action<Response> response)
    {
        WWWForm form = new WWWForm();
        form.AddField("usuario", username);
        form.AddField("contraseña", pass);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/apiuser/checkUser.php", form);

        yield return www.SendWebRequest();
        //Debug.Log(www.downloadHandler.text);
        response(JsonUtility.FromJson<Response>(www.downloadHandler.text));
        
    }

    [Serializable]
    public class Response
    {
        public bool done = false;
        public string message = "";
    }
}
