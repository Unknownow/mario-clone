using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody2D rb2d;   //rigidbody of player
    private bool isFacingRight = true; //true if player is facing right
    public bool isGrounded = true; //true if player is on the ground
    public bool isRunning = false;
    public bool isAlive = true;
    private GameObject playerFeet; //player's feet
    private PlayerStatus status;
    private float invicibleCountdown;
    public float jumpGravityScale = 2f;
    public float fallGravityScale = 2f;
    public float moveSpeed = 10f;
    public float jumpForce = 10f;

    private bool changeBigger = false;
    private bool changeSmaller = false;
    private Vector3 currentScale;
    

    private void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        playerFeet = transform.GetChild(0).gameObject;
        status = gameObject.GetComponent<PlayerStatus>();
        changeBigger = false;
        changeSmaller = false;
        isRunning = false;
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
            return;
        if (changeBigger)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, currentScale * 1.3f, 5 * Time.deltaTime);
            if(currentScale * 1.3f == transform.localScale)
            {
                changeBigger = false;
            }
        }
        else if (changeSmaller)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, currentScale / 1.3f, 5 * Time.deltaTime);
            if (currentScale / 1.3f == transform.localScale)
            {
                changeSmaller = false;
            }
        }

        if (status.isInvicible)
        {
            invicibleCountdown -= Time.deltaTime;
            if (invicibleCountdown <= 0)
            {
                status.isInvicible = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        else if (status.isFabulous)
        {
            invicibleCountdown -= Time.deltaTime;
            if (invicibleCountdown <= 0)
            {
                status.isFabulous = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        isGrounded = Physics2D.OverlapCircle(playerFeet.transform.position, 1f, LayerMask.GetMask("Ground"));
        playerMoveVelocityIncrease();
        playerJump();

    }


    //move instantly in x cordinate
    protected void playerMove()
    {
        int movePoint = 0;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            movePoint = 1;
            if (!isFacingRight)
                flipFace();
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            movePoint = -1;
            if (isFacingRight)
                flipFace();
        }
        rb2d.velocity = new Vector2(movePoint * moveSpeed , rb2d.velocity.y);
    }

    //move with velocity decrease/increase by time in x cordinate
    protected void playerMoveVelocityIncrease()
    {
        float move = Input.GetAxis("Horizontal");
        if (isFacingRight && move < 0) flipFace();
        else if (!isFacingRight && move > 0) flipFace();
        if (move != 0)
        {
            isRunning = true;
        }
        else
            isRunning = false;
        rb2d.position += Vector2.right * move * Time.deltaTime * moveSpeed;
    }

    protected void playerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = !isGrounded;
            rb2d.velocity = Vector2.up * jumpForce;
        }
        jumpControl();
    }

    protected void jumpControl()
    {
        if (rb2d.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb2d.velocity += Vector2.up * jumpGravityScale * Physics2D.gravity.y * Time.deltaTime;
        }
        else if (rb2d.velocity.y < 0)
        {
            rb2d.velocity += Vector2.up * fallGravityScale * Physics2D.gravity.y * Time.deltaTime;
        }
    }


    //flipping face of sprite
    private void flipFace()
    {
        transform.Rotate(Vector2.up, 180);
        isFacingRight = !isFacingRight;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (status.isInvicible)
            return;
        if (collision.transform.CompareTag("Enemy") || collision.transform.CompareTag("Enemy2"))
        {
            if (status.isFabulous)
            {
                collision.gameObject.GetComponent<Collider2D>().isTrigger = true;
                collision.gameObject.GetComponent<EnemyMovement>().enabled = false;
                collision.transform.Rotate(0, 0, 180);
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 2) * 5, ForceMode2D.Impulse);
                if (collision.gameObject.GetComponent<EnemyMovement>().isKoopa)
                {
                    collision.gameObject.GetComponent<KoopaTroopaStatus>().anim.SetBool("isBowling", true);
                }
                return;
            }
            if (status.isBigger)
            {
                status.isBigger = false;
                status.isInvicible = true;
                invicibleCountdown = 2f;
                changeSmaller = true;
                currentScale = transform.localScale;
                return;
            }
            isAlive = false;
        }
    }

    public void changeToBigger()
    {
        changeBigger = true;
        currentScale = transform.localScale;
    }

    public void makeFabulous()
    {
        status.isFabulous = true;
        invicibleCountdown = 6f;
    }
}
