using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbducingOvni : StateMachineBehaviour
{
    Manager manager;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        manager = Manager.Instance;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {        
        if(manager.floating == false)
       {
           animator.SetBool("isAbducing", false);    
       }
    }
}
