using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioUI : MonoBehaviour
{
    [SerializeField] private GameObject objsonFond;
    public AudioSource sonFond;

    [SerializeField] private GameObject objsonSelect;
    public AudioSource sonSelect;
    [SerializeField] private GameObject objsonClick;
    public AudioSource sonClick;
    [SerializeField] private GameObject objsonSwitch;
    public AudioSource sonSwitch;

    [SerializeField] private GameObject objsonDialogo;
    public AudioSource sonDialogo;
    // Start is called before the first frame update

    void Start()
    {
        sonFond = objsonFond.GetComponent<AudioSource>();

        sonSelect = objsonSelect.GetComponent<AudioSource>();
        sonClick = objsonClick.GetComponent<AudioSource>();
        sonSwitch = objsonSwitch.GetComponent<AudioSource>();
        sonDialogo = objsonDialogo.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
