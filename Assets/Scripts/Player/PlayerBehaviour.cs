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

    public HealthBar healthBar;
    public DeathScene deathScene;

    float horizontalMove = 0f;
    bool isJumping = false;
    bool isSwordEquiped = false;

    
    // Melee attack variables
    public Transform attackPoint;
    private float attackRange = 0.75f;
    public LayerMask enemyLayer;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(100);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(Player.health);
        if(!isSwordEquiped) horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (isSwordEquiped) horizontalMove = Input.GetAxisRaw("Horizontal") * walkSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if(Input.GetButtonDown("Jump") && Player.isAlive)
        {
            isJumping = true;
            animator.SetBool("isJumping", isJumping);
            sounds.PlayJumpSound();
        }
        if (Input.GetButtonDown("Attack") && isSwordEquiped && Player.isAlive)
        {
            Attack();
        }
        if (Input.GetButtonDown("Magic") && isSwordEquiped && Player.isAlive)
        {
            animator.SetTrigger("Magic");
            sounds.PlayMagicSound();
            DoMagic();
        }
        if (Input.GetButtonDown("Sword") && Player.isAlive)
        {
            Debug.Log("health: " + Player.health);
            isSwordEquiped = !isSwordEquiped;
            animator.SetBool("SwordEquip", isSwordEquiped);
        }

        /*if (currentHealth <= 0 && isAlive)
        {
            animator.SetBool("isDead", true);
            isAlive = false;
        }*/

    }
    private void FixedUpdate()
    {
        if (Player.isAlive)
        {
            controller2D.Move(horizontalMove * Time.fixedDeltaTime, false, isJumping);
            isJumping = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }
    public void DoMagic()
    {
        Instantiate(FireballPrefab, FirePoint.position, FirePoint.rotation);
    }

    public void TakeDamage(int damage)
    {
        //currentHealth -= damage;
        //healthBar.SetHealth(currentHealth);

        Player.health -= damage;
        if (Player.health < 1)
        {
            animator.SetBool("isDead", true);
            Player.isAlive = false;
            deathScene.gameObject.SetActive(true);
        }
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
        sounds.PlayAttackSound();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        foreach (var enemy in hitEnemies)
        {
            EnemyAI ai = enemy.GetComponent<EnemyAI>();
            if (ai)
            {
                ai.Die();
            }
        }
    }
}


