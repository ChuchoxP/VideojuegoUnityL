using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class NivelesBase : MonoBehaviour
{
    public Renderer fondo;
    public GameObject Columna;
    public List<GameObject> col;

    private float velocidad = 4;

    public GameObject moneda;
    public List<GameObject> mon;

    public GameObject enemigo1;
    public List<GameObject> ene1;

    public int contlt = 1;

    public GameObject L1;
    public GameObject L2;
    public GameObject L3;
    public GameObject L4;

    public TextMeshProUGUI LA1;
    public TextMeshProUGUI LA2;
    public TextMeshProUGUI LA3;
    public TextMeshProUGUI LA4;


    public List<GameObject> LL1;
    public List<GameObject> LL2;
    public List<GameObject> LL3;
    public List<GameObject> LL4;


    // Start is called before the first frame update
    void Start()
    {

        //Crear mapa
        for (int  i = 0;  i < 26;  i++)
        {
            col.Add(Instantiate(Columna,new Vector2(-12+i,-3),Quaternion.identity));
        }

        //crear monedas

        mon.Add(Instantiate(moneda, new Vector2(13, -2), Quaternion.identity));
        ene1.Add(Instantiate(enemigo1, new Vector2(18, -2), Quaternion.identity));

        LL1.Add(Instantiate(L1, new Vector2(90, 0), Quaternion.identity));
        LL2.Add(Instantiate(L2, new Vector2(90, 0), Quaternion.identity));
        LL3.Add(Instantiate(L3, new Vector2(90, 0), Quaternion.identity));
        LL4.Add(Instantiate(L4, new Vector2(90, 0), Quaternion.identity));


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

            if (mon[i].transform.position.x <= -13)
            {
                float randomObs = Random.Range(-2,2);
                mon[i].transform.position = new Vector3(13, randomObs, 0);
            }

            mon[i].transform.position = mon[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
        }

        for (int i = 0; i < ene1.Count; i++)
        {

            if (ene1[i].transform.position.x <= -13)
            {
                float randomObs = Random.Range(-2, 2);
                ene1[i].transform.position = new Vector3(13, randomObs, 0);
            }

            ene1[i].transform.position = ene1[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
        }

        //Mover Letras


        //float randomlts = Random.Range(1, 4);

        switch (contlt)
            {
                case 1:
                    {
                        for (int i = 0; i < LL1.Count; i++)
                        {

                            if (LL1[i].transform.position.x <= -13)
                            {
                                LL1[i].transform.position = new Vector3(13, 0, 0);
                            }

                            LL1[i].transform.position = LL1[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
                        }
                    };
                    break;

                case 2:
                    {
                        for (int i = 0; i < LL2.Count; i++)
                        {

                            if (LL2[i].transform.position.x <= -13)
                            {
                                LL2[i].transform.position = new Vector3(13, 0, 0);
                            }

                            LL2[i].transform.position = LL2[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
                        }
                    };
                    break;
                case 3:
                    {
                        for (int i = 0; i < LL3.Count; i++)
                        {

                            if (LL3[i].transform.position.x <= -13)
                            {
                                LL3[i].transform.position = new Vector3(13, 0, 0);
                            }

                            LL3[i].transform.position = LL3[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
                        }
                    };
                    break;

                case 4:
                    {
                        for (int i = 0; i < LL4.Count; i++)
                        {

                            if (LL4[i].transform.position.x <= -13)
                            {
                                LL4[i].transform.position = new Vector3(13, 0, 0);
                            }

                            LL4[i].transform.position = LL4[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
                        }
                    };
                    break;

            }
        


        



    }



}
