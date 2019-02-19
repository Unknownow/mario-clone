using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 10f;
    private Rigidbody2D rb2d;
    private bool isFacingRight = true;
    public bool isGrounded = true;

    public float jumpGravityScale = 2f;
    public float fallGravityScale = 2f;

    private GameObject playerFeet;
    

    private void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        playerFeet = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(playerFeet.transform.position, 2f, LayerMask.GetMask("Ground"));
        playerMoveVelocityIncrease();
        jumpControl();
        if (isGrounded)
        {
            playerJump();
        }
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
        rb2d.position += Vector2.right * move * Time.deltaTime * moveSpeed;
    }

    protected void playerJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb2d.velocity = Vector2.up * jumpForce;
        }
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
}
