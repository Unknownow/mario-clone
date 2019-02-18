using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10;
    public float jumpForce = 10;
    private Rigidbody2D rb2d;
    private bool isFacingRight = true;
    private bool isGrounded = true;

    private GameObject playerFeet;
    

    private void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        playerFeet = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapPoint(playerFeet.transform.position, LayerMask.GetMask("Ground"));
        playerMove();
    }


    //move instantly in x cordinate
    protected void playerMove()
    {
        int movePoint = 0;
        if (Input.GetKey(KeyCode.D))
        {
            movePoint = 1;
            if (!isFacingRight)
                flipFace();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movePoint = -1;
            if (isFacingRight)
                flipFace();
        }
        rb2d.velocity = new Vector2(movePoint * moveSpeed , rb2d.velocity.y);
    }

    //move with velocity decrease/increase by time in x cordinate
    protected void playerMoveWithDelayed()
    {
        float movePoint = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(movePoint * moveSpeed, rb2d.velocity.y);
    }

    protected void playerJump()
    {
        Debug.Log("Jump!");
        float jumpPoint = Input.GetAxis("Vertical");
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce * jumpPoint);
    }

    protected void playerFall()
    {

    }


    //flipping face of sprite
    private void flipFace()
    {
        transform.Rotate(Vector2.up, 180);
        isFacingRight = !isFacingRight;
    }
}
