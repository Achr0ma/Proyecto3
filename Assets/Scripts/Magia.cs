 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magia : Photon.Pun.MonoBehaviourPun
{

    private Animator anim ;
    public bool atk1magia;
    public float animtime = 2;

    void Start()
    { 
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        anim.SetBool("ATK1MAGIA", true);
        Destroy(this.gameObject, animtime);

    }

}
