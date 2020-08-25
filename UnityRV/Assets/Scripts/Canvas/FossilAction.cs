using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FossilAction : ObjectAction
{
    [SerializeField] private FossilAnimator animator;

	//Metodo chiamato laddove venga "cliccato" l'oggetto puntato dal laser
	//In questo caso, si esegue l'animazione del fossile puntato
    public override void doAction()
    {
        animator.animate();
    }
}
