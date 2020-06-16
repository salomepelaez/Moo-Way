using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IddleBehaviour : StateMachineBehaviour
{
    Manager manager;
    Transform target;
    float distance;

    public static bool timer = false;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        manager = Manager.Instance;
        target = FindObjectOfType<Player>().GetComponent<Transform>();       
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       distance = Vector2.Distance(animator.transform.position, target.position);

        if(distance <= 5  && manager.inGame == true)
        {
            animator.SetBool("isFollowing", true); 
            timer = true;
        }
    }
}
