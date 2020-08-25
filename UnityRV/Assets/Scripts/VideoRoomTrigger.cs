using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoRoomTrigger : MonoBehaviour
{
    [SerializeField] private VideoManager video_manager;
	
	//Laddove l'utente esca dalla sala video, il trigger si attiva
	//e mette in pausa il video del cinema, chiamando il metodo opportuno
	//dello script VideoManager passato come campo serializzato
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "FrontChecker")
            video_manager.exited();
    }
}
