using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_moving : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    
    public float speed = 80f;
    private float attackRange = 200f;
    
    Boss boss;
    private static readonly int Attack = Animator.StringToHash("attack");

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();
        
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 nPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(nPos);

        if (Vector2.Distance(player.position,rb.position) <= attackRange)
        {
            animator.SetTrigger("attack");
            //Attack
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("attack");
    }

}
