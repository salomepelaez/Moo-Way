using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCow : StateMachineBehaviour
{
    private Transform target;
    private float speed = 1f;
    private Rigidbody2D rb;

    Manager manager;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = FindObjectOfType<Player>().GetComponent<Transform>();
        rb = animator.GetComponent<Rigidbody2D>();
        manager = Manager.Instance;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, target.position, speed * Time.deltaTime);

       if(manager.floating == false)
       {
           animator.SetBool("isFloating", false);
           animator.SetBool("isIddle", true);
           rb.gravityScale = 1;
       }
    }
}
