using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalStageScript : MonoBehaviour
{   public GameObject tears;
    public Water water;
    public Transform groundCheckPosition;
    public Animator backGround;
    public Transform playerPosition;
    public Transform rangeStarter;
    public Transform flowerPosition;
    public GameObject clownHp;
    public float radius;
    public float range;
    float currentTime = 0.5f;
    public Image fill;
    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
    public float HP = 20;
    BossFightController bossFightController;

    SpriteRenderer sr;
    Animator anim;
    Rigidbody2D rb;
    float speed = 2f;
    bool isFacingRight = false;
    bool isGrounded;
    public bool canMove = true;


    public bool clownIsDead;

    
    void Start()
    {
        bossFightController = GameObject.Find("LevelController").GetComponent<BossFightController>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr=GetComponent<SpriteRenderer>();
        rb.mass = 1;
        rb.gravityScale = 1;
        Physics2D.IgnoreLayerCollision(7, 6,false);
        Physics2D.IgnoreLayerCollision(7,3,false);
        StartCoroutine(StageStart());

    }

    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("ClownAttackAnimation"))
        {
            speed = 0f;
        }
        else
        {
            speed = 2f;
        }
            RaycastHit2D inRange = Physics2D.Raycast(rangeStarter.transform.position, -transform.right*2f,range,whatIsPlayer);
        if(inRange)
        { if(currentTime<=0)
            {
                anim.SetTrigger("Attack");
                currentTime = 0.5f;
            }
            else
            {
                currentTime -= Time.deltaTime;
            }
        }

        fill.fillAmount = HP * 0.05f ;
        AnimationCheck();
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, radius,whatIsGround);
        if(playerPosition.position.x>transform.position.x&&!isFacingRight)
        {
            Flip();
        }
        else if(playerPosition.position.x<transform.position.x&&isFacingRight)
        {
            Flip();
        }
        if(HP<=0)
        {
            Dead();
        }

   }
    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, speed*Time.deltaTime);
    }
    IEnumerator StageStart()
    {   clownHp.SetActive(true);
        tears.SetActive(true);
        backGround.SetTrigger("Change");
        yield return new WaitForSeconds(5);

    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    void AnimationCheck()
    {
        anim.SetBool("IsWalking",isGrounded);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(bossFightController.currentState==BossFightController.lvlState.FinalStage)
        {
         if(collision.gameObject.CompareTag("Weapon"))
         {
                StartCoroutine(ClownDamage());
                HP--;
          }
        }
    }

    void Dead()
    {
        clownIsDead = true;
        anim.SetTrigger("Dead");
    }
    void OnDead()
    {
        this.enabled = false;

    }
    void OnDead2()
    {
        Destroy(gameObject);
    }
    IEnumerator ClownDamage()
    {
        sr.color = new Color(1, 0, 0.5f, 0.75f);
        yield return new WaitForSeconds(0.35f);
        sr.color = new Color(1, 0, 0.5f, 0.5f);
        yield return new WaitForSeconds(0.35f);
        sr.color = Color.white;
    }
    void OnAttack()
    {   
        Water projectile = Instantiate(water, flowerPosition.position, transform.rotation);
    }
    
    
}
