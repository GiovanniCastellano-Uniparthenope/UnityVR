using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
	//Campi serializzati che richiedono il necessario per far funzionare il pannello video
    [SerializeField] private VideoPlayer video_player;
    [SerializeField] private CinemaTerminal terminal;
    [SerializeField] private RawImage render_panel;
    [SerializeField] private Sprite white_image;
    [SerializeField] private RenderTexture render;
    private VideoClip[] clips;
    private int currclip;
    private bool automatic;

	//Il metodo start carica tutte le clip video dalla cartella Resources/Videos/Clips
	//inoltre, setta la clip iniziale alla prima caricata
    private void Start()
    {
        render_panel.texture = white_image.texture;
        Object[] objs = Resources.LoadAll("Videos/Clips/");
        clips = new VideoClip[objs.Length];

        for (int i = 0; i < objs.Length; i++)
        {
            clips[i] = (VideoClip)objs[i];
        }

        video_player.clip = clips[0];
        video_player.SetDirectAudioVolume(0, 0.25f);
        
        terminal.setData(clips[currclip].name, clips[currclip].length);

        currclip = 0;
        automatic = false;
    }

	//Il metodo esegue due azioni fondamentali:
	//1) Controlla se la clip è carica o meno, e imposta l'immagine in base ad essa
	//2) Al completamento della visualizzazione di una clip, passa automaticamente alla
	//	 seguente se il video è in stato "Playing"
    private void Update()
    {
        if (video_player.isPrepared)
            render_panel.texture = render;
        else
            render_panel.texture = white_image.texture;

        if (automatic)
        {
            if (!video_player.isPlaying)
                if (video_player.isPrepared)
                {
                    nextClip();
                    playClip();
                }
        }
    }

	//Avvia la clip attualmente caricata nel video player
    public void playClip()
    {
        if (!video_player.isPlaying)
        {
            video_player.Play();
            automatic = true;
        }
        else
        {
            automatic = false;
            video_player.Pause();
        }
    }

	//Fa ricominciare la clip da capo
    public void restartClip()
    {
        automatic = false;
        if (video_player.isPlaying)
            video_player.Stop();
        else
        {
            video_player.Play();
            video_player.Stop();
        }

        video_player.Play();
    }

	//Carica la prossima clip, ma non la avvia
    public void nextClip()
    {
        automatic = false;
        if (video_player.isPlaying)
            video_player.Stop();

        if (currclip >= clips.Length - 1)
            currclip = 0;
        else
            currclip++;

        video_player.clip = clips[currclip];
        video_player.SetDirectAudioVolume(0, 0.25f);

        terminal.setData(clips[currclip].name, clips[currclip].length);
    }

	//Carica la precedente clip, ma non la avvia
    public void prevClip()
    {
        automatic = false;
        if (video_player.isPlaying)
            video_player.Stop();

        if (currclip <= 0)
            currclip = clips.Length - 1;
        else
            currclip--;

        video_player.clip = clips[currclip];
        video_player.SetDirectAudioVolume(0, 0.25f);

        terminal.setData(clips[currclip].name, clips[currclip].length);
    }

	//Se l'utente cammina fuori dalla sala, un trigger attiva questo metodo,
	//che mette in pausa il video
    public void exited()
    {
        if (video_player.isPlaying)
            video_player.Pause();
        automatic = false;
    }
}
