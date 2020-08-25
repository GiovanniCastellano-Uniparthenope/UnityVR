using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasGUIManager : GUIManager
{
    //I button presenti nel canvas del menù iniziale
    [SerializeField] private Button FirstButton;
    [SerializeField] private Button SecondButton;
    [SerializeField] private Button ThirdButton;
    [SerializeField] private Button ExitButton;

    //Metodo che, in base al button passato come parametro
    //chiama il metodo di quel button: tutti i button hanno un metodo che si chiama Click()
    public override void ButtonAction(Button button)
    {
        if      (button.name == FirstButton.name)
            FirstButton.GetComponent<EnterButton>().Click();
        else if (button.name == SecondButton.name)
            SecondButton.GetComponent<HandButtonTextManager>().Click();
        else if (button.name == ThirdButton.name)
            ThirdButton.GetComponent<FlagButtonClicked>().Click();
        else if (button.name == ExitButton.name)
            ExitButton.GetComponent<ExitButton>().Click();
        else
            Debug.Log("Error: Button unrecognized");
    }
}
