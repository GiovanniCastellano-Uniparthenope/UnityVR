using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	//Unico riferimento esterno all componente AudioSource, 
	//per poter cambiare a runtime la clip riprodotta
    [SerializeField] private AudioSource audio_source;
	
	//Attributi privati, necessari al funzionamento dell'AudioManager
    private SettingsManager.LANGUAGE language;
    private AudioClip[] dinosaurs_audio_clips;
    private AudioClip[] room_info_clips;
    private AudioClip electric_sound_clip;
    private AudioClip tutorial_clip;
    private AudioClip fossils_clip;
    private AudioClip cinema_audio_clip;
    private AudioClip outer_clip;

	//Lo start carica tutte le clip audio dalla cartella Resources.
	//La cartella contiene un'altra cartella denominata Sounds,
	//nella quale sono conservati i file audio, e contiene due cartelle
	//Italian e English, in cui sono differenziati i file in base alla lingua
    private void Start()
    {
        language = GameObject.Find("SettingsManager").GetComponent<SettingsManager>().getLanguage();

        string path = "";

        if (language == SettingsManager.LANGUAGE.ITALIAN)
            path += "Italian/";
        else if (language == SettingsManager.LANGUAGE.ENGLISH)
            path += "English/";
        else
            Debug.Log("Error: No language detected");

        path += "Audio/";

        Object[] clips;

        clips = Resources.LoadAll(path);
        dinosaurs_audio_clips = new AudioClip[clips.Length];

        for (int i = 0; i < clips.Length; i++)
            dinosaurs_audio_clips[i] = (AudioClip)clips[i];

        electric_sound_clip = (AudioClip)Resources.Load("Sounds/Electricity");

        path = "Sounds/";

        if (language == SettingsManager.LANGUAGE.ITALIAN)
            path += "Italian/";
        else if (language == SettingsManager.LANGUAGE.ENGLISH)
            path += "English/";
        else
            Debug.Log("Error: No language detected");

        tutorial_clip = (AudioClip)Resources.Load(path + "Tutorial");
        fossils_clip = (AudioClip)Resources.Load(path + "Fossils");
        cinema_audio_clip = (AudioClip)Resources.Load(path + "Cinema");
        outer_clip = (AudioClip)Resources.Load(path + "Outer");
    }

	//Esegue la clip attualmente settata come clip attiva nell'AudioSource
    private void playClip(AudioClip clip)
    {
        if (audio_source.isPlaying)
            audio_source.Stop();
        audio_source.clip = clip;
        audio_source.Play();
    }

	//Esegue la clip che descrive il dinosauro dal nome passato come parametro
    public void playDinoClip(string name)
    {
        if (audio_source != null)
        {
            foreach (AudioClip clip in dinosaurs_audio_clips)
            {
                if (clip.name == name)
                {
                    playClip(clip);
                }
            }
        }
        else
            Debug.Log("Error: Audio Source missing");
    }

	//Esegue la clip del suono elettrico che accompagna l'animazione dei tavoli rotondi
    public void playElectricSound()
    {
        playClip(electric_sound_clip);
    }

	//In seguito, vi sono tutti i metodi che eseguono le clip dei vari pannelli audio
	//Se si aggiunge un nuovo pannello, deve essere aggiunto anche un nuovo metodo per quel pannello
    public void playTutorial()
    {
        playClip(tutorial_clip);
    }

    public void playFossils()
    {
        playClip(fossils_clip);
    }

    public void playCinema()
    {
        playClip(cinema_audio_clip);
    }

    public void playOuter()
    {
        playClip(outer_clip);
    }
}
