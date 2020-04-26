using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCow : StateMachineBehaviour
{
    private Transform target;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = FindObjectOfType<Player>().GetComponent<Transform>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       if(Input.GetKeyDown(KeyCode.X))
       {
           animator.SetBool("isFloating", false);
           animator.SetBool("isIddle", true);
       }
    }
}
