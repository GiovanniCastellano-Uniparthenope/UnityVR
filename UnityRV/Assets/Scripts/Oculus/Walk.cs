using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject OVRCameraRig;
    [SerializeField] private float movement_speed;

    //Booleani che controllano se sono avvenute collisioni avanti o dietro al player
    private bool frontcollided;
    private bool backcollided;

    private float y_player;
    private float y_camera;
    private Vector3 coords_player;
    private Vector3 coords_camera;
    private Vector2 OculusGoControllerTouchPadInput;


    private void Start()
    {
        //Inizializza y alla y del player, in modo tale da non potersi muovere lungo questo asse successivamente
        y_player = this.gameObject.transform.position.y;
        y_camera = OVRCameraRig.transform.position.y;
        coords_player = new Vector3(0, y_player, 0);
        coords_camera = new Vector3(0, y_camera, 0);
        OculusGoControllerTouchPadInput = new Vector2(0, 0);
        frontcollided = false;
        backcollided = false;
        if (cam == null)
            Debug.Log("Error: No cam assigned to the player");
    }


    private void Update()
    {
        //Cammina sia che venga premuto W sulla tastiera, sia che venga usato il touchpad del Go controller
        OculusGoControllerTouchPadInput = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
        if (Input.GetKey(KeyCode.W) || OculusGoControllerTouchPadInput.y > 0)
        {
            //Se non vi sono collisioni davanti al player, allora può camminare avanti
            if(!frontcollided)
            {
                coords_player = this.gameObject.transform.position + (cam.transform.forward * movement_speed * Time.deltaTime);
                coords_player.y = y_player;
                this.gameObject.transform.position = coords_player;

                coords_camera = coords_player;
                coords_camera.y = y_camera;
                OVRCameraRig.transform.position = coords_camera;
            }
            OculusGoControllerTouchPadInput = new Vector2(0, 0);
        }
        else if (Input.GetKey(KeyCode.S) || OculusGoControllerTouchPadInput.y < 0)
        {
            //Se non vi sono collisioni dietro al player, allora può camminare indietro
            if(!backcollided)
            {
                coords_player = this.gameObject.transform.position - (cam.transform.forward * movement_speed * Time.deltaTime);
                coords_player.y = y_player;
                this.gameObject.transform.position = coords_player;

                coords_camera = coords_player;
                coords_camera.y = y_camera;
                OVRCameraRig.transform.position = coords_camera;
            }
            OculusGoControllerTouchPadInput = new Vector2(0, 0);
        }
    }

    //I metodi seguenti verranno chiamati dai trigger, 
    //laddove uno dei due checker dovesse entrare in collisione con essi
    public void frontCollisionHappened()
    {
        this.frontcollided = true;
    }

    public void frontCollisionSolved()
    {
        this.frontcollided = false;
    }

    public void backCollisionHappened()
    {
        this.backcollided = true;
    }

    public void backCollisionSolved()
    {
        this.backcollided = false;
    }
}
