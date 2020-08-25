using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusGoControllerHand : MonoBehaviour
{
    [SerializeField] private GameObject OculusGoController;

    private Vector3 Position;

    //Unico metodo che parte all'inizio che la scena è stata caricata, per definire la posizione del controller
    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        SettingsManager manager = GameObject.Find("SettingsManager").GetComponent<SettingsManager>();
        if (manager == null || player == null)
            Debug.Log("Error: SettingsManager or Player not found");
        else
        {
            Position = OculusGoController.transform.localPosition;

            if (manager.getHand() == SettingsManager.HAND.LEFT)
            {
                Position.x = -23.25995f;
            }
            else
            {
                Position.x = 23.25995f;
            }

            OculusGoController.transform.localPosition = Position;
        }
    }
}
