using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logicaentreecenas : MonoBehaviour
{

    private void Awake()
    {

        var nodestruirentreeescenas = FindObjectsOfType<logicaentreecenas>();
        if(nodestruirentreeescenas.Length>1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

    }


}
