using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NivelesBase : MonoBehaviour
{
    public Renderer fondo;
    public GameObject Columna;
    private float velocidad = 4;

    public GameObject moneda;

    public List<GameObject> col;
    public List<GameObject> mon;
    public List<GameObject> mon2;

    // Start is called before the first frame update
    void Start()

    {

        //Crear mapa
        for (int  i = 0;  i < 26;  i++)
        {
            col.Add(Instantiate(Columna,new Vector2(-12+i,-3),Quaternion.identity));
        }

        //crear monedas

        mon.Add(Instantiate(moneda, new Vector2(-16, -2), Quaternion.identity));
        mon2.Add(Instantiate(moneda, new Vector2(-16, 0), Quaternion.identity));

    }

    // Update is called once per frame
    void Update()
    {

        fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.2f,0) * Time.deltaTime;

        //mover mapa
        for (int i = 0; i < col.Count; i++)
        {

            if (col[i].transform.position.x <=-11)
            {
                col[i].transform.position = new Vector3(12,-3,0);
            }

            col[i].transform.position = col[i].transform.position + new Vector3 (-1,0,0) * Time.deltaTime * velocidad;
        }

        //mover moneda1
        for (int i = 0; i < mon.Count; i++)
        {

            if (mon[i].transform.position.x <= -14)
            {
                float randomObs = Random.Range(12,16);
                mon[i].transform.position = new Vector3(randomObs, -2, 0);
            }

            mon[i].transform.position = mon[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
        }

        //mover moneda2
        for (int i = 0; i < mon2.Count; i++)
        {

            if (mon2[i].transform.position.x <= -14)
            {
                float randomObs = Random.Range(22, 26);
                mon2[i].transform.position = new Vector3(randomObs, 0, 0);
            }

            mon2[i].transform.position = mon2[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
        }

    }

}
