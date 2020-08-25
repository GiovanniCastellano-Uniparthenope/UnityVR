using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CameraRotateOculus : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    [SerializeField] private Transform player;
    private Vector3 vector;

    //Ad ogni frame, la camera viene girata col movimento della testa,
    //ed il corpo del player ruota attorno all'asse y seguendo la camera
    private void Update()
    {
        vector = player.eulerAngles;
        vector.y = camera.transform.eulerAngles.y;
        player.eulerAngles = vector;
    }
}
