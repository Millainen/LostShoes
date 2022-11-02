using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    #region variables

    Rigidbody2D rb;
    float speed = 10f;
    float jumpForce = 8f;
    float go;

    bool walkingLeft;

    public GameObject enemies;
    EnemyAI enemyAI;

    int playerMaxHealth = 3;
    public static int playerCurrentHealth; //TÄMÄ ON PUBLIC STATIC, MIKSI???

    public GameObject bullet;

    GroundCheck grCheck;

    public HealthBar healthBar;

    Animator anim;

    private enum State { idle, running, jumping, falling, hurt }
    private State state = State.idle;

    #endregion

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        playerCurrentHealth = playerMaxHealth;
        rb = GetComponent<Rigidbody2D>();
        enemyAI = enemies.GetComponentInChildren<EnemyAI>();
        grCheck = GetComponentInChildren<GroundCheck>();

        healthBar.SetMaxHealth(playerMaxHealth);
    }

    void Update()
    {
        if (!talkToTheThief.talkMode && !AcquireShoes.acquiringShoes && state != State.hurt)
        {
            Movement();
            UpdateWeapon();
        }
        PlayerHealth();
        AnimationSettings();
        VelocityState();

        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log(state);
        }
    }

    void Movement()
    {
        //sprinting
        if (grCheck.onGround) //this is here so the player won't sprint while jumping
        {
            if (Input.GetKey(KeyCode.LeftShift))
                speed = 23f;
            else
                speed = 10f;
        }

        //gets the speed and direction of player movement based on input
        go = speed * Input.GetAxis("Horizontal") * Time.deltaTime;

        //moves the player
        transform.Translate(go, 0, 0);
        
        //jumping jumping
        if (grCheck.onGround)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }
    }

    void Jump()
    {
        if (StartMenuScript.speedrunMode)
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        else
            rb.velocity = Vector2.up * jumpForce;
        PointSound.jumped = true;
        state = State.jumping;
    }

    //manages player's health
    void PlayerHealth()
    {
       healthBar.SetHealth(playerCurrentHealth); 

       if (playerCurrentHealth <= 0)
            SceneManager.LoadScene("GameOver");
    }

    //manages how many bullets player can shoot
    void UpdateWeapon()
    {
        if (WeaponManager.bulletsInScene < 30)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Instantiate(bullet, transform.position + Vector3.right * 0.3f, transform.rotation);
                PointSound.firedBullet = true;
                WeaponManager.bulletsInScene++;
            }
        }
    }

    void AnimationSettings()
    {
        //animator settings
        if (talkToTheThief.talkMode == true || AcquireShoes.acquiringShoes == true)
            anim.Play("empty");
        else if (AcquireShoes.acquiringShoes == true)
            anim.Play("idleLeft");
        else
        {
            if (go != 0) //TODO: set the animator by animator states, to prove you can
            {
                if (go > 0)
                {
                    anim.Play("walk");
                    walkingLeft = false;
                }
                else
                {
                    anim.Play("walkright"); //TODO: change this to walking left
                    walkingLeft = true;
                }
            }
            else
            {
                if (!walkingLeft)
                    anim.Play("empty");
                else
                    anim.Play("idleLeft");
            }
        }
        
    }

    private void VelocityState()
    {
        if (state == State.jumping)
        {
            if(rb.velocity.y < .1f)
            {
                state = State.falling;
            }
        }
        else if(state == State.falling)
        {
            if (grCheck.onGround)
            {
                state = State.idle;
            }
        }
        else if (state == State.hurt)
        {
            if (rb.velocity.x < .1f)
                state = State.idle;
        }
        else if(go != 0) { state = State.running; }

        else { state = State.idle; }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            if(state == State.falling)
            {
                PointCalculator.points++;
                PointSound.collectedPoint = true;
                Destroy(other.gameObject);
                Jump();
            }
            else
            {
                state = State.hurt;
                playerCurrentHealth -= 1;

                if (other.gameObject.transform.position.x > transform.position.x) //Enemy is on my left
                {
                    enemyAI.MoveLeftToThePlayer();
                }
                else //Enemy is on my right
                {
                    enemyAI.MoveRightToThePlayer();
                }
            }
        }
    }
}
