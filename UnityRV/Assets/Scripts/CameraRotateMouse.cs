using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe utilizzata esclusivamente per debug,
//muove la telecamera tramite mouse
public class CameraRotateMouse : MonoBehaviour
{
    [SerializeField] private GameObject OVRCameraRig;
    [SerializeField] private float cameraspeed;

    private float yaw;
    private float pitch;
    private Vector3 Xaxis;
    private Vector3 Yaxis;

    void Start()
    {
        yaw = this.gameObject.transform.eulerAngles.y;
        pitch = this.gameObject.transform.eulerAngles.x;
        Xaxis = this.gameObject.transform.eulerAngles;
        Yaxis = this.gameObject.transform.eulerAngles;
        SetCursorLock(true);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftAlt))
        {
            SetCursorLock(false);
        }
        else
        {
            SetCursorLock(true);
            yaw += cameraspeed * Input.GetAxis("Mouse X");
            pitch -= cameraspeed * Input.GetAxis("Mouse Y");
            Xaxis.x = pitch;
            Xaxis.y = yaw;

            Yaxis.y = yaw;

            this.gameObject.transform.eulerAngles = Yaxis;
            OVRCameraRig.transform.eulerAngles = Xaxis;
        }
    }

    private void SetCursorLock(bool value)
    {
        if(value)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;
        Cursor.visible = !value;
    }
}
