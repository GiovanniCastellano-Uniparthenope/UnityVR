using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe astratta utile allo script ButtonCollider,
//in modo tale da renderlo capace di definire, in caso di collisione
//con un GameObject e non con un Button, quale azione eseguire
//Da questa classe si eredita un solo metodo, necessario alla
//chiamata virtuale del metodo concreto definito dalle classi figlie
public abstract class ObjectAction : MonoBehaviour
{
    public abstract void doAction();
}
