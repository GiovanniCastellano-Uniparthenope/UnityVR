using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    //Slider del menù, che viene aggiornato durante il caricamento
    [SerializeField] private Slider loadingslider;
    //Instanza singleton dell'oggetto
    private static SettingsManager instance;

    //Definizione delle enum utilizzate anche altrove
    public enum LANGUAGE    { ITALIAN, ENGLISH };
    public enum HAND        { RIGHT, LEFT };

    //Lingua dell'applicazione scelta
    private LANGUAGE language;
    //Mano scelta
    private HAND hand;
    
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            //L'oggetto deve persistere anche nella scena successiva, per cui non deve essere distrutto
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        //Inizializzazione ad italiano / destrorso
        this.language   = LANGUAGE.ITALIAN;
        this.hand       = HAND.RIGHT;
    }

    //Carica la scena del museo in modo asincrono, 
    //così da poter aggiornare lo slider e da non dare sensazioni di blocco dell'applicazione
    public void loadMuseum()
    {
        Scene currscene = SceneManager.GetActiveScene();
        if (currscene.buildIndex == 1)
            return;

        AsyncOperation load = SceneManager.LoadSceneAsync(1);
        StartCoroutine(LoadMuseumAsync(load));
    }

    //Coroutine che carica il museo in modo asincrono
    private IEnumerator LoadMuseumAsync(AsyncOperation load)
    {
        LoadingSlider sliderscript = loadingslider.GetComponent<LoadingSlider>();
        while (!load.isDone)
        {
            sliderscript.SetSliderValue(load.progress * 100);
            yield return null;
        }
    }

    //I metodi che seguono sono chiamati da altri script,
    //sono set e get della lingua e della mano
    public void setLanguage(LANGUAGE language)
    {
        this.language = language;
    }

    public void setHand(HAND hand)
    {
        this.hand = hand;
    }

    public LANGUAGE getLanguage()
    {
        return this.language;
    }

    public HAND getHand()
    {
        return this.hand;
    }
}
