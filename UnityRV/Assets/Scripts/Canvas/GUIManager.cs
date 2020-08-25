using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Classe astratta che definisce un solo metodo,
//utile alle classi figlie per permettere la
//chiamata virtuale del metodo
public abstract class GUIManager : MonoBehaviour
{
    public abstract void ButtonAction(Button button);
}
