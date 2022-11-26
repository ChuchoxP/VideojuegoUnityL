using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apache : MonoBehaviour
{


    public Animator animator;

    public SpriteRenderer SpriteRenderer;


    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();

        SpriteRenderer = GetComponent<SpriteRenderer>();
   

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
