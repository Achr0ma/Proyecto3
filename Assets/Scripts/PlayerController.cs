using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private bool atk1 = false;
    private bool atk2 = false;
    public int ataque = 0;
    private int MiTurno = 1;
    //public int exp = 100;
    public EnemyController Enemigo;
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
            if(ataque == 1 && atkprocess == -1 && GameController.gameController.ExpJugador >= 100)
            {
                atk1 = true;
                anim.SetBool("ATK1", atk1);  
                Enemigo.ReducirVida(25);
                Reducir_Aumentar_Exp(-100);     
            }
            if(ataque ==2 && atkprocess == -1 && GameController.gameController.ExpJugador >= 200)
            {
                atk1 = true;
                anim.SetBool("ATK1", atk1);  
                Enemigo.ReducirVida(25);
                Reducir_Aumentar_Exp(-200);       
            }
            if(ataque ==3 && atkprocess == -1 && GameController.gameController.ExpJugador >= 200)
            {
                atk1 = true;
                anim.SetBool("ATK1", atk1);  
                Enemigo.ReducirVida(25);
                Reducir_Aumentar_Exp(-200);         
            }
            if(ataque ==4 && atkprocess == -1 && GameController.gameController.ExpJugador >= 400)
            {
                atk1 = true;
                anim.SetBool("ATK1", atk1);  
                Enemigo.ReducirVida(25);
                Reducir_Aumentar_Exp(-400);         
            }
            if(ataque ==5 && atkprocess == -1 && GameController.gameController.ExpJugador >= 500)
            {
                atk1 = true;
                anim.SetBool("ATK1", atk1);  
                Enemigo.ReducirVida(25);
                Reducir_Aumentar_Exp(-500);          
            }
            if(ataque ==6 && atkprocess == -1 && GameController.gameController.ExpJugador >= 1000)
            {
                atk2 = true;
                anim.SetBool("ATK2", atk2);
                Enemigo.ReducirVida(25);
                Reducir_Aumentar_Exp(-1000);        
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

    public void Reducir_Aumentar_Exp(int dano)
    {
        GameController.gameController.ExpJugador = GameController.gameController.ExpJugador + dano;
    }
    
}
