﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IddleOvni : StateMachineBehaviour
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Input.GetKeyDown(KeyCode.Y))
       {
            animator.SetBool("isAbducing", true);    
       }
    }
}