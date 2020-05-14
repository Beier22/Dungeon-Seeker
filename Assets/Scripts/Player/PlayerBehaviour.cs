using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public CharacterController2D controller2D;
    public float runSpeed = 40f;
    public float walkSpeed = 20f;
    
    public Animator animator;

    float horizontalMove = 0f;
    bool jump = false;
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
            jump = true;
            animator.SetBool("isJumping", jump);
        }
        if (Input.GetButtonDown("Attack"))
        {
            animator.SetTrigger("Attack");
        }
        if (Input.GetButtonDown("Magic"))
        {
            animator.SetTrigger("Magic");
        }
        if (Input.GetButtonDown("Sword"))
        {
            isSwordEquiped = !isSwordEquiped;
            animator.SetBool("SwordEquip", isSwordEquiped);
        }

    }
    private void FixedUpdate()
    {
        controller2D.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

}
