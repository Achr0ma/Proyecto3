using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private bool atk1 = false;
    private bool atk2 = false;
    private int MiTurno = 1;
    public int VidaJugador = 100;
    public EnemyController Enemigo;



    //private Vector3 PosicionOriginal;

    private int atkprocess = -1;

    void Start()
    {
        anim = GetComponent<Animator>();
        //PosicionOriginal = transform.position;
    }

    void FixedUpdate()
    {
 
        //En estos ifs se controlan los ataques del jugador 
        if(MiTurno == GameController.gameController.Turno)
        {
             if(atk1 == true || atk2 == true)
            {
                atk1 = false;
                atk2 = false;
                anim.SetBool("ATK1", atk1);
                anim.SetBool("ATK2", atk2);
            }
            if(Input.GetKeyDown(KeyCode.Space) && atkprocess == -1)
            {
                atk1 = true;
                anim.SetBool("ATK1", atk1);  
                Enemigo.ReducirVida(10);     
            }
            if(Input.GetKeyDown(KeyCode.Q) && atkprocess == -1)
            {
                atk2 = true;
                anim.SetBool("ATK2", atk2);
                Enemigo.ReducirVida(20);        
            }
        }

        

    }

    //Mueve al jugador cuando la animacion inicia y termina
    //Se puede mejorar  usando la posicion original y la posicion del enemigo en el "transform"
    public void AnimacionJugador(int x)
    { 
        atkprocess = x;
        transform.Translate(Vector3.left * 10f * x);

        if(x == -1)
        {
            GameController.gameController.Turno++;

        }
    }
    
}
