using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminalGUIManager : GUIManager
{
    //Button presenti nel terminale
    [SerializeField] private Button FirstButton;
    [SerializeField] private Button SecondButton;
    [SerializeField] private Button ThirdButton;
    [SerializeField] private Button FourthButton;
    [SerializeField] private Button LeftButton;
    [SerializeField] private Button RightButton;

    //Campi utili alla coroutine che cambia il dinosauro:
    //il primo sono i testi e le immagini della televisione
    //il secondo è il suono elettrico che parte con l'animazione
    [SerializeField] private TVSwapper TVscript;
    [SerializeField] private AudioManager audio_manager;

    //I testi di tutti i button e della label che indica la pagina selezionata
    [SerializeField] private Text Text1;
    [SerializeField] private Text Text2;
    [SerializeField] private Text Text3;
    [SerializeField] private Text Text4;
    [SerializeField] private Text Page;
    [SerializeField] private Material TableMaterial;
    [SerializeField] private Material DinoMaterial;

    private GameObject[] dinosaurs;
    private int curpage;
    private int maxpage;
    private int active;
    private bool acting;


    private void Start()
    {
        acting = false;
        active = 0;
        curpage = 0;
        //Trova tutti gli oggetti con tag "Dinosaur"
        dinosaurs = GameObject.FindGameObjectsWithTag("Herbivorous");
        for (int i = 1; i < dinosaurs.Length; i++)
            dinosaurs[i].SetActive(false);
        //Calcola quante pagine sono necessarie a contenere tutti i dinosauri
        //dato il terminale che ha 4 button per pagina
        maxpage = (dinosaurs.Length-1) / 4;
        updatePageText();
        UpdateButtonTexts();
        TVscript.swapDinoInfo(dinosaurs[0].name);
    }

    //Imposta il testo della label indicante la pagina attuale e il numero di pagine presenti
    private void updatePageText()
    {
        Page.text = (curpage + 1).ToString() + "/" + (maxpage + 1).ToString();
    }

    public override void ButtonAction(Button other)
    {
        //Se non vi sono animazioni in corso...
        if (!acting)
        {
            //...seleziona l'indice del button premuto, 
            //oppure cambia pagina, se si è premuto un button laterale
            int index = -1;
            if (other.name == FirstButton.name)
                index = 0;
            else if (other.name == SecondButton.name)
                index = 1;
            else if (other.name == ThirdButton.name)
                index = 2;
            else if (other.name == FourthButton.name)
                index = 3;
            else if (other.name == LeftButton.name)
            {
                if (curpage > 0)
                {
                    curpage--;
                    updatePageText();
                    UpdateButtonTexts();
                }
                return;
            }
            else if (other.name == RightButton.name)
            {
                if ((3 + curpage * 4) < dinosaurs.Length - 1)
                {
                    curpage++;
                    updatePageText();
                    UpdateButtonTexts();
                }
                return;
            }

            if (index < 0 || index > 3)
            {
                return;
            }

            //Chiama quindi la funzione che carica il dinosauro passato come parametro
            this.LoadDino(index + curpage * 4);
        }
    }

    //Modifica i testi dei button al cambio di pagina
    private void UpdateButtonTexts()
    {
        int index = curpage * 4;

        Text1.text = dinosaurs[index].name;

        index = 1 + curpage * 4;
        if (index < dinosaurs.Length)
            Text2.text = dinosaurs[index].name;
        else
            Text2.text = "";

        index = 2 + curpage * 4;
        if (index < dinosaurs.Length)
            Text3.text = dinosaurs[index].name;
        else
            Text3.text = "";

        index = 3 + curpage * 4;
        if (index < dinosaurs.Length)
            Text4.text = dinosaurs[index].name;
        else
            Text4.text = "";
    }

    //Metodo che carica il dinosauro scelto, facendo partire il suono e l'animazione del tavolo
    private void LoadDino(int requested)
    {
        if(requested < dinosaurs.Length)
        {
            StartCoroutine(BrightOn(1.0f, 0f, 2.5f, requested));
            audio_manager.playElectricSound();
        }
    }

    //Esegue l'animazione del tavolo, facendolo illuminare;
    //quindi cambia il dinosauro mostrato e le informazioni sulla televisione
    IEnumerator BrightOn(float tableValue, float dinoValue, float aTime, int requested)
    {
        acting = true;
        float t=0.0f;
        if (TableMaterial == null || DinoMaterial == null)
        {
            Debug.Log("Error: table or dinosaur material not found");
            yield return null;
        }
        else
        {
            float r = TableMaterial.color.r;
            float g = TableMaterial.color.g;
            float b = TableMaterial.color.b;
            float a = DinoMaterial.color.a;
            
            for(t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
            {
                Color dinoColor = new Color(DinoMaterial.color.r, DinoMaterial.color.g, DinoMaterial.color.b, Mathf.Lerp(a, dinoValue, t));
                DinoMaterial.color = dinoColor;
                Color tableColor = new Color(Mathf.Lerp(r, tableValue, t), Mathf.Lerp(g, tableValue, t), Mathf.Lerp(b, tableValue, t), 1);
                TableMaterial.color = tableColor;
                yield return null;
            }
        }
        if (t >= 1 && tableValue == 1.0f)
        {
            dinosaurs[active].SetActive(false);
            dinosaurs[requested].SetActive(true);
            TVscript.swapDinoInfo(dinosaurs[requested].name);
            active = requested;
            StartCoroutine(BrightOn(0.07f, 1f, 2.0f, requested));
        }
        else if(t>=1 && tableValue < 1.0f)
        {
            acting = false;
            audio_manager.playDinoClip(dinosaurs[active].name);
        }
    }
}
