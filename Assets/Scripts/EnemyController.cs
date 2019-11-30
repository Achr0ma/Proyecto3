using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Photon.Pun.MonoBehaviourPun
{
    private Animator anim ;
    //public PlayerController Jugador;
    //public GameObject Pregunta;
    private bool atk1 = false;
    //private bool inactivo = false;
    private int MiTurno = 2;
    private int atkprocess = -1;
    public GameObject magia;
    public int Respuesta = 0;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(MiTurno == GameController.gameController.Turno)
        {

            

            if(atk1 == true)
            {
                atk1 = false;
                //inactivo = false;
                anim.SetBool("ATK1ENEMIGO", atk1);
            } 
            if(atkprocess == -1 && Respuesta == 1)
            {
                atk1 = true;
                anim.SetBool("ATK1ENEMIGO", atk1);
                Instantiate(magia);
                Respuesta =0;
            }
             if(atkprocess == -1 && Respuesta == -1)
            {
                //inactivo = true;
                //anim.SetBool("INACTIVO", inactivo);
                AnimacionEnemigo(-1);
                Respuesta =0;
            }

        }
        
    }

    public void AnimacionEnemigo(int x)
    { 
        atkprocess = x;
        if(x == -1)
        {
            GameController.gameController.Turno++;
        }
    }
    public void ReducirVida(int dano)
    {
        GameController.gameController.VidaEnemigo = GameController.gameController.VidaEnemigo - dano;
    }

    



    
}
