using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FossilAnimator : MonoBehaviour
{
    private Animator animator;
    private bool is_animating;
 
	//Carica l'animator del fossile su cui si trova lo script 
    private void Start()
    {
        animator = this.GetComponent<Animator>();
        if (animator == null)
            Debug.Log(this.gameObject.name + " has no animator attached");

        is_animating = false;
    }
	
	//Esegue l'animazione del fossile a cui questo script è applicato
	//Decide se avviare l'animazione di sollevamento o messa a terra
	//in base all'attributo booleano is_animating
    public void animate()
    {
            if (!is_animating)
                animator.Play("start_levitating");
            else
                animator.Play("stop_levitating");

            is_animating = !is_animating;
    }
}
