using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_moving : StateMachineBehaviour
{
    public float speed = 50f;

    private GameObject enemy;
    private Transform player;
    private Rigidbody2D rb;

    private float maxDist;
    private float minDist;
    private static readonly int Attack = Animator.StringToHash("attack");

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        rb = enemy.GetComponent<Rigidbody2D>();
        
        maxDist = enemy.transform.position.x + 100f;
        minDist = enemy.transform.position.x - 100f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(player.position,enemy.transform.position) <= 100f && (enemy.transform.position.x < maxDist || enemy.transform.position.x > minDist))
        {
            Vector2 target = new Vector2(player.position.x, rb.position.y);
            Vector2 nPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(nPos);

            if (Vector2.Distance(player.position,enemy.transform.position) <= 20f)
            {
                animator.SetTrigger("attack");
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger("attack");
    }
    
}
