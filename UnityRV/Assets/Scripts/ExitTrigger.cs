using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    //Trigger applicato sul canvas che presenta la porta Exit,
    //laddove si abbia il triggerEnter, l'applicazione viene chiusa
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "FrontChecker")
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }
}
