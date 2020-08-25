using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour
{
	//Azione eseguita al clic di uno dei pannelli audio
	//Trova il pannello selezionato e stabilisce quale clip audio caricare
	//in base al nome del Button premuto
	//All'aggiunta di un nuovo pannello, va aggiunto un nuovo blocco "else if"
    public void buttonAction()
    {
        AudioManager audio_manager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        if (this.gameObject.name == "Tutorial")
        {
            audio_manager.playTutorial();
        }
        else if(this.gameObject.name == "Fossils")
        {
            audio_manager.playFossils();
        }
        else if(this.gameObject.name == "Cinema")
        {
            audio_manager.playCinema();
        }
        else if(this.gameObject.name == "Outer1" || this.gameObject.name == "Outer2")
        {
            audio_manager.playOuter();
        }
    }
}
