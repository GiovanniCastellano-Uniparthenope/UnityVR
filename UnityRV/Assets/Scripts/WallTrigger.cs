using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    private GameObject player;
    
    private void Start()
    {
        //Trova l'unico oggetto chiamato PlayerGroup della scena
        player = GameObject.Find("PlayerGroup");
    }

    //Il metodo blocca l'avanzata in avanti o indietro
    //in base a quale checker è entrato nel trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "FrontChecker")
            player.GetComponent<Walk>().frontCollisionHappened();
        else if (other.name == "BackChecker")
            player.GetComponent<Walk>().backCollisionHappened();
    }

    //Il metodo blocca l'avanzata in avanti o indietro
    //in base a quale checker continua a restare nel trigger
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "FrontChecker")
            player.GetComponent<Walk>().frontCollisionHappened();
        else if (other.name == "BackChecker")
            player.GetComponent<Walk>().backCollisionHappened();
    }

    //Il metodo sblocca l'avanzata in avanti o indietro
    //in base a quale checker è uscito dal trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "FrontChecker")
            player.GetComponent<Walk>().frontCollisionSolved();
        else if (other.name == "BackChecker")
            player.GetComponent<Walk>().backCollisionSolved();
    }
}
