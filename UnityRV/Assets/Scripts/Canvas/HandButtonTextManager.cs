using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandButtonTextManager : CanvasButton
{
	[SerializeField] private SettingsManager settingsmanager;
    [SerializeField] private Text text;
	
    struct Hand
    {
        string italian;
        string english;

        public Hand(string italian, string english)
        {
            this.italian = italian;
            this.english = english;
        }

        public string getItalian()
        {
            return this.italian;
        }

        public string getEnglish()
        {
            return this.english;
        }
    }

    private SettingsManager.LANGUAGE language;
    private SettingsManager.HAND hand;

    private Hand righthand, lefthand;

    private void Start()
    {
        language = settingsmanager.getLanguage();
        hand = settingsmanager.getHand();

        //Set delle stringhe da utilizzare per ogni mano, in italiano ed in inglese
        righthand = new Hand("Destrorso", "Right handed");
        lefthand = new Hand("Mancino", "Left handed");
    }

    //Ogni qualvolta si preme il button della mano, essa sarà cambiata anche nel menù stesso
    //e questo metodo si occupa proprio di ciò
    public void UpdateText()
    {
        if(language == SettingsManager.LANGUAGE.ITALIAN)
        {
            if (hand == SettingsManager.HAND.RIGHT)
                text.text = righthand.getItalian();
            else
                text.text = lefthand.getItalian();
        }
        else
        {
            if (hand == SettingsManager.HAND.RIGHT)
                text.text = righthand.getEnglish();
            else
                text.text = lefthand.getEnglish();
        }
    }

    //Metodo chiamato dal button della lingua, per impostare la lingua laddove essa cambi
    public void setTextLanguage(SettingsManager.LANGUAGE language)
    {
        this.language = language;
        UpdateText();
    }

    //Metodo che cambia la mano del controller e la imposta anche nel settingsmanager
    override
    public void Click()
    {
        if (hand == SettingsManager.HAND.RIGHT)
            hand = SettingsManager.HAND.LEFT;
        else
            hand = SettingsManager.HAND.RIGHT;

        settingsmanager.setHand(this.hand);

        UpdateText();
    }
}
