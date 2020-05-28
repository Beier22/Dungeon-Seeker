using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyFacing : MonoBehaviour
{

    public AIPath aiPath;
    public GameObject player;
    public Transform attackPoint;
    public GameObject fireball;
    
    private PlayerBehaviour pb;

    private int i = 1;
    private Animator animator;
    private Boolean isAlive = true;
    private Rigidbody2D rigBody;
    private BoxCollider2D boxCol;

    private void Start()
    {
        pb = player.GetComponent<PlayerBehaviour>();
        animator = gameObject.GetComponent<Animator>();
        rigBody = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
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

        if (aiPath.remainingDistance < 0.5)
        {
            Attack();
        }
        else
        {
            aiPath.speed = 3;
            animator.ResetTrigger("Attack");
        }

        if (aiPath.speed > 0.1)
        {
            animator.SetBool("isMoving", true);
        }
        else if (aiPath.speed < 0.1)
        {
            animator.SetBool("isMoving", false);
        }
    }

    void Attack()
    {
        aiPath.speed = 0;
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
        aiPath.speed = 0;
        animator.SetTrigger("Die");
        isAlive = false;
        Destroy(rigBody);
        Destroy(boxCol);
    }
}