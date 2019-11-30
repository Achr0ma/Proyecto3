using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class AutoLobby : MonoBehaviourPunCallbacks
{
    public Button Conectar;
    public Button Unir;
    public Button BMago;
    public Button BEspadachin;


    public Text log;
    public GameObject lobby;
    public GameController gameController;

    public byte MAXjugadoresporroom = 2;
    public int jugadorescont = 0;

    public void conectar()
    {
        if(!PhotonNetwork.IsConnected)
        {
            if(PhotonNetwork.ConnectUsingSettings())
            {
                log.text += "\nConectado al servidor";
            }
            else
            {
                log.text += "\nFallo conexion al servidor";
            }
            

        }
    }

    public override void OnConnectedToMaster()
    {
        Conectar.interactable = false;
        Unir.interactable = true;
    }

    public void UnirSala()
    {
        if(!PhotonNetwork.JoinRandomRoom())
        {
            log.text += "\nFallo en union";
        }
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        log.text += "\no se pudo unir a la sala...creado una sala...";
        if(PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions(){MaxPlayers = MAXjugadoresporroom}))
        {
            log.text += "\nSala creada";
            gameController.inicializar_enemigo();
            //lobby.SetActive(false);
            
        }
        else{
            log.text += "\nFallo en creacion de sala";
        }

    }   

    public override void OnJoinedRoom()
    {
        jugadorescont += 1; 
        Unir.interactable = false;
        log.text += "\nTe has unidos a una sala";
        BEspadachin.interactable = true;
        BMago.interactable = true;
    } 

}
