using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator anim ;
    private bool atk1 = false;
    private int MiTurno = 2;
    private int atkprocess = -1;
    public GameObject magia;
    


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
                anim.SetBool("ATK1ENEMIGO", atk1);
                
                
                
            } 
            if(Input.GetKeyDown(KeyCode.Space) && atkprocess == -1)
            {
                atk1 = true;
                anim.SetBool("ATK1ENEMIGO", atk1);
                Instantiate(magia);
                       
            }

        }
        
    }

    public void AnimacionEnemigo(int x)
    { 
        atkprocess = x;
        //Debug.Log(x);
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
