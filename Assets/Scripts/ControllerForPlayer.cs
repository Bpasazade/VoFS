using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllerForPlayer : MonoBehaviour
{
    public static ControllerForPlayer instance;
    //config params
    public Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public bool isTouchingGround;
    public bool oneMoreJump;
    public SpriteRenderer spriteRenderer;
    public bool isEnemyHere;
    public float responseCounter, responseTime = 0.5f, responsePower = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator animator;
    public GameObject currentEnemy;
    public string currentTag;

    void Awake() {
        DontDestroyOnLoad (transform.gameObject);
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (responseCounter <= 0) {

            

            rb.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), rb.velocity.y);
            isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

            if(isTouchingGround)
            {
                oneMoreJump = true;
            }

            if(Input.GetButtonDown("Jump"))
            {
                if(isTouchingGround)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                } 
                else if(oneMoreJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    oneMoreJump = false;
                }
            }

            if(Input.GetButtonDown("Fire1"))
            {
                GetComponent<Animator>().Play("Knight_Attack",  -1, 0f);
                animator.SetTrigger("attack");
                if (isEnemyHere)
                {
                    AudioController.instance.PlaySound(1);
                    Debug.Log("Enemy hit");
                    if (currentTag == "Skeleton_1")
                        currentEnemy.GetComponent<S_1_HC>().TakeDamage();
                    if (currentTag == "Skeleton_2")
                        currentEnemy.GetComponent<S_2_HC>().TakeDamage();
                    if (currentTag == "Skeleton_3")
                        currentEnemy.GetComponent<S_3_HC>().TakeDamage();
                    if (currentTag == "Skeleton_4")
                        currentEnemy.GetComponent<S_4_HC>().TakeDamage();
                    if (currentTag == "Necromancer")
                        currentEnemy.GetComponent<Necromancer_HealthController>().TakeDamage();
                } else {
                    AudioController.instance.PlaySound(5);
                }
            }

            if(rb.velocity.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if(rb.velocity.x < 0)
            {
                
                spriteRenderer.flipX = true;
            }

        }
        else
        {
            responseCounter = 0;
            if (spriteRenderer.flipX) {
                rb.velocity = new Vector2(-responsePower, rb.velocity.y);
            } else {
                rb.velocity = new Vector2(responsePower, rb.velocity.y);
            }
        }
        

        animator.SetFloat("player_speed", Mathf.Abs(rb.velocity.x));
        animator.SetBool("touchingGround", isTouchingGround);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Necromancer"))
        {
            isEnemyHere = true;
            currentTag = "Necromancer";
            currentEnemy = GameObject.FindGameObjectsWithTag("Necromancer")[0];
            Debug.Log(currentEnemy.name);
        }
        if (collision.CompareTag("Skeleton_1"))
        {
            isEnemyHere = true;
            currentTag = "Skeleton_1";
            currentEnemy = GameObject.FindGameObjectsWithTag("Skeleton_1")[0];
            Debug.Log(currentEnemy.name);
        }
        if (collision.CompareTag("Skeleton_2"))
        {
            isEnemyHere = true;
            currentTag = "Skeleton_2";
            currentEnemy = GameObject.FindGameObjectsWithTag("Skeleton_2")[0];
            Debug.Log(currentEnemy.name);
        }
        if (collision.CompareTag("Skeleton_3"))
        {
            isEnemyHere = true;
            currentTag = "Skeleton_3";
            currentEnemy = GameObject.FindGameObjectsWithTag("Skeleton_3")[0];
            Debug.Log(currentEnemy.name);
        }
        if (collision.CompareTag("Skeleton_4"))
        {
            isEnemyHere = true;
            currentTag = "Skeleton_4";
            currentEnemy = GameObject.FindGameObjectsWithTag("Skeleton_4")[0];
            Debug.Log(currentEnemy.name);
        }
        if (collision.CompareTag("Potion_small"))
        {
            AudioController.instance.PlaySound(4);
            CharacterHealthController.instance.Heal(1);
            currentTag = "Potion_small";
            Debug.Log("Healed 1 HP");
            collision.gameObject.SetActive(false);
        }
        if (collision.CompareTag("Potion_large"))
        {
            AudioController.instance.PlaySound(4);
            CharacterHealthController.instance.Heal(2);
            Debug.Log("Healed 3 HP");
            collision.gameObject.SetActive(false);
        }
        if (collision.CompareTag("Channel"))
        {
            SceneManager.LoadScene(sceneName:"Scene_2");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Necromancer") || collision.CompareTag("Skeleton_1") || collision.CompareTag("Skeleton_2") || collision.CompareTag("Skeleton_3") || collision.CompareTag("Skeleton_4"))
        {
            isEnemyHere = false;
            currentTag = "";
            currentEnemy = null;
        }
    }
}
