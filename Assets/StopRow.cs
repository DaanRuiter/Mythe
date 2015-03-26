using UnityEngine;
using System.Collections;

public class StopRow : StateMachineBehaviour {

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Row", false); 
	}
}
