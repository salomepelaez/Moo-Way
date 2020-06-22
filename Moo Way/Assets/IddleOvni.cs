using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IddleOvni : StateMachineBehaviour
{
    Manager manager;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        manager = Manager.Instance;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(manager.floating == true)
       {
            animator.SetBool("isAbducing", true);    
       }
    }
}
