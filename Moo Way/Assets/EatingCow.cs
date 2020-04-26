using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingCow : StateMachineBehaviour
{
    private Transform target;
    private float speed = 0.6f;
    private float distance;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = FindObjectOfType<Player>().GetComponent<Transform>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        distance = Vector2.Distance(animator.transform.position, target.position);

       if(distance <= 5 && Input.GetKeyDown(KeyCode.Space))
       {
            animator.SetBool("isFloating", true);
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, target.transform.position, speed * Time.deltaTime);
       }
    }
}
