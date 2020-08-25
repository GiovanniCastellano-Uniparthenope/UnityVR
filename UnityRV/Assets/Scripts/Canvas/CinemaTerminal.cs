using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CinemaTerminal : GUIManager
{
	//Campi serializzati che richiedono il passaggio degli elementi sul canvas
	//applicato sul terminale del cinema
    [SerializeField] private VideoManager video_manager;
    [SerializeField] private Text clip_name;
    [SerializeField] private Text clip_time;
    [SerializeField] private Button play;
    [SerializeField] private Button restart;
    [SerializeField] private Button next;
    [SerializeField] private Button prev;

	//Metodo che aggiorna le informazioni della clip attualmente caricata
    public void setData(string name, double time)
    {
        clip_name.text = name;

        int min = (int)(time / 60);
        int sec = (int)(time % 60);
        string minutes, seconds;
        if (min < 10)
            minutes = "0" + min.ToString();
        else
            minutes = min.ToString();

        if (sec < 10)
            seconds = "0" + sec.ToString();
        else
            seconds = sec.ToString();

        clip_time.text = minutes + ":" + seconds;
    }

	//Metodo che esegue l'azione corrispettiva al Button premuto
    public override void ButtonAction(Button button)
    {
        if (button.name == play.name)
            video_manager.playClip();
        else if (button.name == restart.name)
            video_manager.restartClip();
        else if (button.name == next.name)
            video_manager.nextClip();
        else if (button.name == prev.name)
            video_manager.prevClip();
    }
}
