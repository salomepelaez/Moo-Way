using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBehaviour : StateMachineBehaviour
{
    float distance;
    private Transform target;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = FindObjectOfType<Player>().GetComponent<Transform>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        distance = Vector2.Distance(animator.transform.position, target.position);

        if(distance >= 5)
        {
            animator.SetBool("isFollowing", false); 
            IddleBehaviour.timer = false;
        }
    }
}
