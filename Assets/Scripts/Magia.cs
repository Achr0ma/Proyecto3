 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magia : MonoBehaviour
{

    private Animator anim ;
    public bool atk1magia;

    void Start()
    { 
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        anim.SetBool("ATK1MAGIA", true);
        Destroy(this.gameObject, (float) 5);

    }

}
