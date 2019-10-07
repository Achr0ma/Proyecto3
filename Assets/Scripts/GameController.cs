using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public List<GameObject> Prefabs;
    public static GameController gameController;
    public int VidaEnemigo = 100;
    public int ExpJugador = 100;
    public GameObject Enemigo; 
    public EnemyController EnemigoControl;
    public GameObject Jugador;
    public PlayerController JugadorControl;
    public GameObject Pregunta;
    public Text textopregunta;

    public int Turno = 1;
    public int LimiteTurno = 2;
    public Text exp;
    public Text vida;

    public string [] preguntas = new string []{"Pasos Metodologia agil: Planificacion, inicio, desarrollo, pruebas cierre ", "python es un lenguaje de programacion"};

    public bool[] respuestas;
    private int random;

    void Start()
    {
        gameController = this.GetComponent<GameController>();
        Jugador = Instantiate(Prefabs[0]) as GameObject;
        JugadorControl = Jugador.GetComponent<PlayerController>();
        Enemigo = Instantiate(Prefabs[1]) as GameObject;
        EnemigoControl = Enemigo.GetComponent<EnemyController>();
        random = Random.Range(0, 2);
    }
    void FixedUpdate()
    {
        //Maxinmo de turnos
        if(Turno > 2)
        {
            Turno = 1;
        }
        if(Turno == 2)
        {
            Pregunta.SetActive(true);
            //Debug.Log("pregunta =" +random);
            textopregunta.text = preguntas [random];

        }
        else
        {
            Pregunta.SetActive(false);
        }
        //Muerte enemigo
        if(VidaEnemigo <= 0)
        {
            Destroy(Enemigo, (float) 1);
        } 
        exp.text = ("EXP: "+ ExpJugador.ToString());
        vida.text = ("VIDA: "+VidaEnemigo.ToString());
    }

    public void mas_menos_Exp(int x)
    {
        JugadorControl.Reducir_Aumentar_Exp(x);
    }

    public void Ataque(int x)
    {
        JugadorControl.ataque = x;
        Invoke("ReiniciarAtaque", 2f);
    }
    public void ReiniciarAtaque()
    {
        JugadorControl.ataque = 0;
    }

    public void pregunta(bool x)
    {
        //Debug.Log("X="+ x);
        //Debug.Log("respuesta random =" + random);
        //Debug.Log("respuesta ="+ respuestas[random]);
        if(x != respuestas[random])
        {
            JugadorControl.Reducir_Aumentar_Exp(-10);
            EnemigoControl.Respuesta = 1;
        }
        else
        {
            JugadorControl.Reducir_Aumentar_Exp(+10);
            EnemigoControl.Respuesta = -1;
        }
        random = Random.Range(0, 2);
    }


}
