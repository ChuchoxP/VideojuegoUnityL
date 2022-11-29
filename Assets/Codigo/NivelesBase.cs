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

    public GameObject murcielago;
    public List<GameObject> murci;

    public int contlt = 1;

    public int contplb = 1;

    public GameObject L1;
    public GameObject L2;
    public GameObject L3;
    public GameObject L4;

    public GameObject L5;
    public GameObject L6;
    public GameObject L7;
    public GameObject L8;
    public GameObject L9;
    public GameObject L10;

    public GameObject L11;
    public GameObject L12;
    public GameObject L13;
    public GameObject L14;


    public List<GameObject> LL1;
    public List<GameObject> LL2;
    public List<GameObject> LL3;
    public List<GameObject> LL4;

    public List<GameObject> LL5;
    public List<GameObject> LL6;
    public List<GameObject> LL7;
    public List<GameObject> LL8;
    public List<GameObject> LL9;
    public List<GameObject> LL10;

    public List<GameObject> LL11;
    public List<GameObject> LL12;
    public List<GameObject> LL13;
    public List<GameObject> LL14;

    Jugador J;

    AudioUI sonido;
    private void Awake()
    {
        sonido = GameObject.FindObjectOfType<AudioUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        J = FindObjectOfType<Jugador>();


        //Crear mapa
        for (int  i = 0;  i < 29;  i++)
        {
            col.Add(Instantiate(Columna,new Vector2(-14+i,-3),Quaternion.identity));
        }

        //crear monedas

        mon.Add(Instantiate(moneda, new Vector2(13, -2), Quaternion.identity));
        murci.Add(Instantiate(murcielago, new Vector2(18, -2), Quaternion.identity));

        LL1.Add(Instantiate(L1, new Vector2(15, 0), Quaternion.identity));
        LL2.Add(Instantiate(L2, new Vector2(15, 0), Quaternion.identity));
        LL3.Add(Instantiate(L3, new Vector2(15, 0), Quaternion.identity));
        LL4.Add(Instantiate(L4, new Vector2(15, 0), Quaternion.identity));

        LL5.Add(Instantiate(L5, new Vector2(15, 0), Quaternion.identity));
        LL6.Add(Instantiate(L6, new Vector2(15, 0), Quaternion.identity));
        LL7.Add(Instantiate(L7, new Vector2(15, 0), Quaternion.identity));
        LL8.Add(Instantiate(L8, new Vector2(15, 0), Quaternion.identity));
        LL9.Add(Instantiate(L9, new Vector2(15, 0), Quaternion.identity));
        LL10.Add(Instantiate(L10, new Vector2(15, 0), Quaternion.identity));

        LL11.Add(Instantiate(L11, new Vector2(15, 0), Quaternion.identity));
        LL12.Add(Instantiate(L12, new Vector2(15, 0), Quaternion.identity));
        LL13.Add(Instantiate(L13, new Vector2(15, 0), Quaternion.identity));
        LL14.Add(Instantiate(L14, new Vector2(15, 0), Quaternion.identity));



    }

    // Update is called once per frame
    void Update()
    {

        fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.2f,0) * Time.deltaTime;

        //mover mapa
        for (int i = 0; i < col.Count; i++)
        {

            if (col[i].transform.position.x <=-12)
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

        for (int i = 0; i < murci.Count; i++)
        {

            if (murci[i].transform.position.x <= -13)
            {
                float randomObs = Random.Range(-2, 2);
                murci[i].transform.position = new Vector3(13, randomObs, 0);
            }

            murci[i].transform.position = murci[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * 6;
        }

        //Mover Letras


        moverletras();

    }

    public void moverletras()
    {
        switch (contplb)
        {
            case 1:
                {
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
                };
                break;

            case 2:
                {
                    switch (contlt)
                    {
                        case 6:
                            {
                                for (int i = 0; i < LL5.Count; i++)
                                {

                                    if (LL5[i].transform.position.x <= -13)
                                    {
                                        LL5[i].transform.position = new Vector3(13, 0, 0);
                                    }

                                    LL5[i].transform.position = LL5[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
                                }
                            };
                            break;

                        case 7:
                            {
                                for (int i = 0; i < LL6.Count; i++)
                                {

                                    if (LL6[i].transform.position.x <= -13)
                                    {
                                        LL6[i].transform.position = new Vector3(13, 0, 0);
                                    }

                                    LL6[i].transform.position = LL6[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
                                }
                            };
                            break;
                        case 8:
                            {
                                for (int i = 0; i < LL7.Count; i++)
                                {

                                    if (LL7[i].transform.position.x <= -13)
                                    {
                                        LL7[i].transform.position = new Vector3(13, 0, 0);
                                    }

                                    LL7[i].transform.position = LL7[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
                                }
                            };
                            break;

                        case 9:
                            {
                                for (int i = 0; i < LL8.Count; i++)
                                {

                                    if (LL8[i].transform.position.x <= -13)
                                    {
                                        LL8[i].transform.position = new Vector3(13, 0, 0);
                                    }

                                    LL8[i].transform.position = LL8[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
                                }
                            };
                            break;
                        case 10:
                            {
                                for (int i = 0; i < LL9.Count; i++)
                                {

                                    if (LL9[i].transform.position.x <= -13)
                                    {
                                        LL9[i].transform.position = new Vector3(13, 0, 0);
                                    }

                                    LL9[i].transform.position = LL9[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
                                }
                            };
                            break;
                        case 11:
                            {
                                for (int i = 0; i < LL10.Count; i++)
                                {

                                    if (LL10[i].transform.position.x <= -13)
                                    {
                                        LL10[i].transform.position = new Vector3(13, 0, 0);
                                    }

                                    LL10[i].transform.position = LL10[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
                                }
                            };
                            break;

                    }
                };
                break;

            case 3:
                {
                    switch (contlt)
                    {
                        case 13:
                            {
                                for (int i = 0; i < LL11.Count; i++)
                                {

                                    if (LL11[i].transform.position.x <= -13)
                                    {
                                        LL11[i].transform.position = new Vector3(13, 0, 0);
                                    }

                                    LL11[i].transform.position = LL11[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
                                }
                            };
                            break;

                        case 14:
                            {
                                for (int i = 0; i < LL12.Count; i++)
                                {

                                    if (LL12[i].transform.position.x <= -13)
                                    {
                                        LL12[i].transform.position = new Vector3(13, 0, 0);
                                    }

                                    LL12[i].transform.position = LL12[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
                                }
                            };
                            break;
                        case 15:
                            {
                                for (int i = 0; i < LL13.Count; i++)
                                {

                                    if (LL13[i].transform.position.x <= -13)
                                    {
                                        LL13[i].transform.position = new Vector3(13, 0, 0);
                                    }

                                    LL13[i].transform.position = LL13[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
                                }
                            };
                            break;

                        case 16:
                            {
                                for (int i = 0; i < LL14.Count; i++)
                                {

                                    if (LL14[i].transform.position.x <= -13)
                                    {
                                        LL14[i].transform.position = new Vector3(13, 0, 0);
                                    }

                                    LL14[i].transform.position = LL14[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
                                }
                            };
                            break;

                    }
                };
                break;
        }



        

    }



}
