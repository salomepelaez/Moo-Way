using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : StateMachineBehaviour
{
    private Patrol patrolSpots;
    private float speed = 1f;
    private int randomSpot;
    Transform target;
    float distance;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       patrolSpots = GameObject.FindGameObjectWithTag("Point").GetComponent<Patrol>();
       randomSpot = Random.Range(0, patrolSpots.moveSpots.Length);
       target = FindObjectOfType<Player>().GetComponent<Transform>();
    }

   
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        distance = Vector2.Distance(animator.transform.position, target.position);

        if(Vector2.Distance(animator.transform.position, patrolSpots.moveSpots[randomSpot].position) < 0.2f)
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, patrolSpots.moveSpots[randomSpot].position, speed * Time.deltaTime);
        }

        else
        {
            randomSpot = Random.Range(0, patrolSpots.moveSpots.Length);
        }

        if(distance >= 5)
        {
            animator.SetBool("isFollowing", false); 
        }

        else
        {
            animator.SetBool("isPatrolling", true); 
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}
}
