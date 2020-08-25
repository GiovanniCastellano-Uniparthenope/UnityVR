using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterButton : CanvasButton
{
    [SerializeField] private GameObject manager;
	[SerializeField] Text text;

    struct Languages
    {
        string italian;
        string english;

        public Languages(string italian, string english)
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
	
    private Languages language;

    private void Start()
    {
        language = new Languages("Entra nel museo", "Enter museum");
    }

    public void SetLanguage(SettingsManager.LANGUAGE language)
    {
        if (language == SettingsManager.LANGUAGE.ITALIAN)
            text.text = this.language.getItalian();
        else
            text.text = this.language.getEnglish();
    }

    //Metodo che entra nel museo, caricando la prossima scena
    override
    public void Click()
    {
        manager.GetComponent<SettingsManager>().loadMuseum();
    }
}
