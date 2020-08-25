using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusGoControllerInputs : MonoBehaviour
{
    [SerializeField] private Transform controller;
    //Il semplice comando prende in input la rotazione del controller Oculus Go
    private void Update()
    {
        controller.localRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);
    }
}
