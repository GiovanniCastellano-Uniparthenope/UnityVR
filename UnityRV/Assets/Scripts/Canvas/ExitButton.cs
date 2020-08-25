using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : CanvasButton
{
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
        language = new Languages("Esci", "Exit");
    }

    public void SetLanguage(SettingsManager.LANGUAGE language)
    {
        if (language == SettingsManager.LANGUAGE.ITALIAN)
            text.text = this.language.getItalian();
        else
            text.text = this.language.getEnglish();
    }

    //Metodo che chiude l'applicazione quando cliccato
    override
    public void Click()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
