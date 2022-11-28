using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textopergamino : MonoBehaviour
{

    [SerializeField, TextArea(4, 3)] public string[] lineadialogo;
    [SerializeField] public int lineindex=0;
    [SerializeField] public GameObject paneldpergamino;
    [SerializeField] public TextMeshProUGUI Txttexto; 
    [SerializeField] public GameObject Txtpanel;

    float time = 0.03f;


    bool dialogaux;

    public GameObject btnOk;

    public bool x=false;

    Jugador J;

    // Start is called before the first frame update
    void Start()
    {
        J=FindObjectOfType<Jugador>();
    }

    // Update is called once per frame
    void Update()
    {
        if(x==true)
        {
            if (!dialogaux)
            {
                iniciardialogo();
                
            }

        }
        
        if (Txttexto.text == lineadialogo[lineindex])
        {
            btnOk.SetActive(true);
        }

    }

    public void iniciardialogo()
    {
        StartCoroutine(verlineas());
        dialogaux = true;
    }

    private IEnumerator verlineas()
    {
        Txttexto.text = string.Empty;

        foreach (char ch in lineadialogo[lineindex])
        {
            Txttexto.text += ch;
            yield return new WaitForSeconds(time);
        }
    }

    public void siguientedialogo()
    {

           

            if (lineindex < lineadialogo.Length)
            {
                StartCoroutine(verlineas());
            }
            
        

    }
}
