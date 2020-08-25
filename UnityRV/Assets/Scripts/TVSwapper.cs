using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TVSwapper : MonoBehaviour
{
    //Le immagini e i testi da cambiare
    [SerializeField] Image image1;
    [SerializeField] Image image2;
    [SerializeField] Text title;
    [SerializeField] Text body;
    //L'immagine di default laddove la ricerca, successivamente, dovesse fallire
    [SerializeField] Sprite noimagefound;

    private SettingsManager.LANGUAGE language;

    //Metodo che cambia le informazioni sulla televisione, in base al dinosauro passato come parametro
    public void swapDinoInfo(string name)
    {
        /*
         Il metodo cerca nella cartella Resources immagini e testi relativi ai dinosauri:
         - I testi sono contenuti in due cartelle separate in base alla lingua, Italian e English,
           e i loro titoli saranno equivalenti al nome del dinosauro (Case sensitive). Laddove un
           testo non dovesse essere trovato, verrà scritto "NO DATA" al suo posto
         - Le immagini si trovano direttamente nella cartella resources, ed hanno come titolo il nome
           del dinosauro, con suffisso 1 o 2, in base a se deve essere caricata sullo slot di sopra o di sotto.
           Nel caso un'immagine non venga trovata, al suo posto verrà caricata l'immagine di default noimagefound,
           che serve a riempire lo slot che sarebbe altrimenti totalmente bianco, e segnala che non è stata trovata
           alcuna immagine.
        
        La mancanza di testi o di immagini può avvenire specialmente in vista di aggiunta di nuovi dinosauri, in cui magari
        si aggiunge il modello 3D, ma ci si dimentica di aggiungere il testo per entrambe le lingue e le due immagini.

        Per tutti i dinosauri presenti (gli 8 inizialmente previsti) sono presenti sia testi in ambo le lingue che due immagini
        per cui non verranno mai mostrati i testi e le immagini di errore.
         */
        language = GameObject.Find("SettingsManager").GetComponent<SettingsManager>().getLanguage();
        title.text = name;

        Texture2D texture;
        string path="";

        //Aggiunge al path la lingua scelta, dato che i testi sono divisi in una cartella per lingua
        if      (language == SettingsManager.LANGUAGE.ITALIAN)
            path += "Italian/";
        else if (language == SettingsManager.LANGUAGE.ENGLISH)
            path += "English/";
        else
            Debug.Log("Error: No language detected");

        path += name;

        //Carica il testo col nome del dinosauro da Resources e dalla cartella della lingua selezionata
        TextAsset text = (TextAsset)Resources.Load(path);

        //Se il testo non è stato trovato perchè manca, verrà scritto "NO DATA"
        if (text == null)
            body.text = "NO DATA";
        else
            body.text = text.text;

        //Stessa procedura per le immagini
        //se una di esse non viene trovata, verrà utilizzata l'immagine noimagefound come sprite, invece dello sprite bianco
        path = name + "1";
        texture = (Texture2D)Resources.Load(path);
        if (texture == null)
            image1.sprite = noimagefound;
        else
            image1.sprite = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), Vector2.zero);

        path = name + "2";
        texture = (Texture2D)Resources.Load(path);
        if (texture == null)
            image2.sprite = noimagefound;
        else
            image2.sprite = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), Vector2.zero);
    }
}
