 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInicio : MonoBehaviour
{

    public Renderer fondo;
    public GameObject Columna;

    public List<GameObject> col;


    // Start is called before the first frame update
    void Start()
    {

        Time.timeScale = 1f;
        for (int i = 0; i < 26; i++)
        {
            col.Add(Instantiate(Columna, new Vector2(-12 + i, -3), Quaternion.identity));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
