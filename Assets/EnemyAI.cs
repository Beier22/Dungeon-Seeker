using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{public AIPath aiPath;
    public GameObject player;
    public Transform attackPoint;
    
    private PlayerBehaviour pb;

    private int i = 1;
    private Boolean isAlive = true;
    private Rigidbody2D rigBody;
    private BoxCollider2D boxCol;
    public Animator animator;
    // Start is called before the first frame update
    private void Start()
    {
        pb = player.GetComponent<PlayerBehaviour>();
        rigBody = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
        aiPath.canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
        {
            aiPath.canMove = false;
            return;
        }

        // Sets the direction the unit will be facing
        if(aiPath.desiredVelocity.x >= 0.01f) transform.localScale = new Vector3(1f, 1f, 1f);
        else if (aiPath.desiredVelocity.x <= -0.01f) transform.localScale = new Vector3(-1f, 1f, 1f);

        float dist = Vector3.Distance(player.transform.position, this.transform.position);

        if (dist <= 30f)
        {
            aiPath.canMove = true;
        }
        else
        {
            return;
        }
        
        if (dist <= 2f)
        {
            Attack();
        }
        else
        {
            animator.ResetTrigger("Attack");
        }

        if (!aiPath.reachedDestination)
        {
            animator.SetBool("isMoving", true);
        }
        else 
        {
            animator.SetBool("isMoving", false);
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        float dist = Vector3.Distance(player.transform.position, attackPoint.position);
        if (dist <= 1 && animator.GetAnimatorTransitionInfo(0).IsName("SkeletonSword_Attack -> SkeletonSword_Idle"))
        {
            pb.TakeDamage(1);
            // Debug.Log("Damage: " + i++);
        }
    }

    public void Die()
    {
        animator.SetBool("Die", true);
        isAlive = false;
        Destroy(rigBody);
        Destroy(boxCol);
    }
}
