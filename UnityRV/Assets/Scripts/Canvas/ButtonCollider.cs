using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCollider : MonoBehaviour
{
    //Il canvas con cui il raggio deve interagire
    [SerializeField] private GameObject terminal;
    [SerializeField] private GameObject terminal2;
    [SerializeField] private GameObject terminal3;

    //I button del canvas
    private Button[] buttons;
    private GameObject[] fossils;
    //Il button attualmente puntato dal raggio
    private Button activebutton;
    //Il GameObject attualmente puntato dal raggio
    private GameObject activeobject;
    //Un button nascosto da selezionare quando tutti gli altri non sono selezionati
    //Serve per far deselezionare l'ultimo button selezionato
    private Button defaultbutton;

    void Start()
    {
        //Cerca tutti i button presenti nella scena
        buttons = FindObjectsOfType<Button>();
        fossils = GameObject.FindGameObjectsWithTag("Fossil");

        for (int i = 0; i < buttons.Length; i++)
            if (buttons[i].name == "DefaultButton")
            {
                //Imposta il button nascosto al primo button con nome "DefaultButton" trovato
                defaultbutton = buttons[i];
                break;
            }
    }

    private void Update()
    {
        AudioButton component;
        
        if (Input.GetKeyUp(KeyCode.Mouse0) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            //Attiva l'azione del GameObject attualmente puntato, sia con il mouse sia tramite Oculus Go controller
            if(activeobject != null)
            {
                activeobject.GetComponent<ObjectAction>().doAction();
            }
            //Attiva l'azione del button attualmente puntato, sia con il mouse sia tramite Oculus Go controller
            if (activebutton != null && activebutton != defaultbutton)
            {
                if (activebutton.TryGetComponent<AudioButton>(out component))
                {
                    component.buttonAction();
                }
                else
                {
                    if (terminal != null)
                        terminal.GetComponent<GUIManager>().ButtonAction(activebutton);
                    if (terminal2 != null)
                        terminal2.GetComponent<GUIManager>().ButtonAction(activebutton);
                    if(terminal3 != null)
                        terminal3.GetComponent<GUIManager>().ButtonAction(activebutton);
                }
            }
        } 
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Trova tra tutti i button quello attualmente selezionato e lo scrive in activebutton
        for(int i = 0; i < buttons.Length; i++)
        {
            if(buttons[i].name==collision.collider.name)
            {
                activebutton = buttons[i];
                //Attiva il colore di selezionato al button attivo
                activebutton.Select();
                break;
            }
        }
        for(int i = 0; i < fossils.Length; i++)
        {
            if(fossils[i].name == collision.collider.name)
            {
                activeobject = fossils[i];
                break;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //Deseleziona il button  e il GameObject attivi e seleziona il button nascosto, 
        //in questo modo, il button precedentemente selezionato tornerà al colore di idle
        activeobject = null;
        activebutton = defaultbutton;
        activebutton.Select();
    }
}
