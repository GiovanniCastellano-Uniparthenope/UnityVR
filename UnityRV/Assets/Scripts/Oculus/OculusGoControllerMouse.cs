using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe utilizzata esclusivamente per debug,
//muove il controller dell'oculus tramite mouse
public class OculusGoControllerMouse : MonoBehaviour
{
    [SerializeField] private GameObject OculusGoController;
    [SerializeField] private float cameraspeed;

    private float yaw;
    private float pitch;
    private Vector3 Xaxis;


    private void Start()
    {
        yaw = 0.0f;
        pitch = 0.0f;
        Xaxis = OculusGoController.transform.eulerAngles;
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            pitch -= cameraspeed;
        if (Input.GetKey(KeyCode.DownArrow))
            pitch += cameraspeed;

        Xaxis.x = pitch;
        Xaxis.y = OculusGoController.transform.eulerAngles.y;
        Xaxis.z = OculusGoController.transform.eulerAngles.z;

        OculusGoController.transform.eulerAngles = Xaxis;
    }
}
