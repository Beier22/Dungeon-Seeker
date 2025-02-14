﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public CharacterController2D controller2D;
    public float runSpeed = 40f;
    public float walkSpeed = 20f;
    
    public Animator animator;
    public GameObject FireballPrefab;
    public Transform FirePoint;
    public PlayerSounds sounds;

    float horizontalMove = 0f;
    bool isJumping = false;
    bool isSwordEquiped = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isSwordEquiped) horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (isSwordEquiped) horizontalMove = Input.GetAxisRaw("Horizontal") * walkSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if(Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            animator.SetBool("isJumping", isJumping);
            sounds.PlayJumpSound();
        }
        if (Input.GetButtonDown("Attack") && isSwordEquiped)
        {
            animator.SetTrigger("Attack");
            sounds.PlayAttackSound();
        }
        if (Input.GetButtonDown("Magic") && isSwordEquiped)
        {
            animator.SetTrigger("Magic");
            sounds.PlayMagicSound();
            DoMagic();
        }
        if (Input.GetButtonDown("Sword"))
        {
            isSwordEquiped = !isSwordEquiped;
            animator.SetBool("SwordEquip", isSwordEquiped);
        }

    }
    private void FixedUpdate()
    {
        controller2D.Move(horizontalMove * Time.fixedDeltaTime, false, isJumping);
        isJumping = false;
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }
    public void DoMagic()
    {
        Instantiate(FireballPrefab, FirePoint.position, FirePoint.rotation);
    }
}
