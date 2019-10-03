using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<GameObject> Prefabs;
    public static GameController gameController;

    public int VidaEnemigo = 100;

    public GameObject Enemigo; 

    public int Turno = 1;
    public int LimiteTurno = 2;


    void Start()
    {
        gameController = this.GetComponent<GameController>();
        Instantiate(Prefabs[0]);
        Enemigo = Instantiate(Prefabs[1]) as GameObject;

        
        
        
    }

    void FixedUpdate()
    {
        //Debug.Log(Turno);
        if(Turno > 2)
        {
            Turno = 1;
        }

        if(VidaEnemigo <= 0)
        {
            Destroy(Enemigo, (float) 3);
        }   
    }
 
}
