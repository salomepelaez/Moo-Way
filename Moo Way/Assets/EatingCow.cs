using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingCow : StateMachineBehaviour
{
    Manager manager;
    private Transform target;
    private float distance;
    private Rigidbody2D rb;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        manager = Manager.Instance;
        target = FindObjectOfType<Player>().GetComponent<Transform>();
        rb = animator.GetComponent<Rigidbody2D>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        distance = Vector2.Distance(animator.transform.position, target.position);

       if(distance <= 3 && manager.built == true && manager.floating == true)
       {
            animator.SetBool("isFloating", true);    
            rb.gravityScale = 0;        
       }
    }
}
