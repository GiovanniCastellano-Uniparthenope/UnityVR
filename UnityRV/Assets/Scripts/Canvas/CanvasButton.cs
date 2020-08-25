using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interfaccia che si assicura della presenza del metodo Click() nei button del canvas del menù iniziale
public abstract class CanvasButton : MonoBehaviour
{
    public abstract void Click();
}
