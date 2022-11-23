using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textopergamino : MonoBehaviour
{

    [SerializeField, TextArea(4, 12)] public string[] lineadialogo;
    [SerializeField] public GameObject paneldpergamino;
    [SerializeField] private TextMeshProUGUI Txtpanel;

    float time = 0.03f;


    bool dialogaux;

    public GameObject btnOk;

    public bool x=false;

    // Start is called before the first frame update
    void Start()
    {
        
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
        
        if (Txtpanel.text == lineadialogo[0])
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
        Txtpanel.text = string.Empty;

        foreach (char ch in lineadialogo[0])
        {
            Txtpanel.text += ch;
            yield return new WaitForSeconds(time);
        }
    }
}
