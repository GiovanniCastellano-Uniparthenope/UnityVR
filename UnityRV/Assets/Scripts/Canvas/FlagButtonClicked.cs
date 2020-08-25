using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagButtonClicked : CanvasButton
{
    [SerializeField] private SettingsManager settingsmanager;
    [SerializeField] private Button thisButton;
    [SerializeField] private HandButtonTextManager HandButton;
    [SerializeField] private EnterButton Enterbutton;
    [SerializeField] private ExitButton ExitButton;

    [SerializeField] private Sprite ITFlag;
    [SerializeField] private Sprite USFlag;


    private SettingsManager.LANGUAGE language;
    
    private void Start()
    {
        this.language = settingsmanager.getLanguage();

        if (language == SettingsManager.LANGUAGE.ITALIAN)
            thisButton.image.sprite = ITFlag;
        else
            thisButton.image.sprite = USFlag;
    }

    //Metodo che cambia la lingua dell'applicazione, impostandola nel settingsmanager
    //inoltre cambia la lingua anche nel menù stesso, chiamando il metodo per settare la lingua di ogni button
    override
    public void Click()
    {
        if(language == SettingsManager.LANGUAGE.ITALIAN)
        {
            thisButton.image.sprite = USFlag;
            language = SettingsManager.LANGUAGE.ENGLISH;
        }
        else
        {
            thisButton.image.sprite = ITFlag;
            language = SettingsManager.LANGUAGE.ITALIAN;
        }

        settingsmanager.setLanguage(language);
        HandButton.setTextLanguage(language);
        Enterbutton.SetLanguage(language);
        ExitButton.SetLanguage(language);
    }
}
