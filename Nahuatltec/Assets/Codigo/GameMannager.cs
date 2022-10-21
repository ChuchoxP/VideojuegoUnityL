using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMannager : MonoBehaviour
{

    public int PuntosTotales { get { return puntosTotales; } }
    private int puntosTotales;

    public void sumarpuntos(int puntosAsumar)
    {
        puntosTotales += puntosAsumar;
        Debug.Log(puntosTotales);
    }
}
