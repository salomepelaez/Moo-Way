using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCow : StateMachineBehaviour
{
    private Transform target;
    private float speed = 1f;
    private Rigidbody2D rb;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = FindObjectOfType<Player>().GetComponent<Transform>();
        rb = animator.GetComponent<Rigidbody2D>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, target.position, speed * Time.deltaTime);

       if(Input.GetKeyDown(KeyCode.X))
       {
           animator.SetBool("isFloating", false);
           animator.SetBool("isIddle", true);
           rb.gravityScale = 1;
       }
    }
}
