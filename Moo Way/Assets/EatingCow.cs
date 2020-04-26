using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingCow : StateMachineBehaviour
{
    private Transform target;
    private float distance;
    private Rigidbody2D rb;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = FindObjectOfType<Player>().GetComponent<Transform>();
        rb = animator.GetComponent<Rigidbody2D>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        distance = Vector2.Distance(animator.transform.position, target.position);

       if(distance <= 3 && Input.GetKeyDown(KeyCode.Space))
       {
            animator.SetBool("isFloating", true);    
            rb.gravityScale = 0;        
       }
    }
}
