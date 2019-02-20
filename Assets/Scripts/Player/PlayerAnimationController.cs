using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Rigidbody2D rb2d;
    Animator playerAnimator;
    private void Start()
    {
        rb2d = transform.GetComponent<Rigidbody2D>();
        playerAnimator = transform.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        playerAnimator.SetFloat("YVel", rb2d.velocity.y);
        playerAnimator.SetBool("isGrounded", transform.GetComponent<PlayerMovement>().isGrounded);
        playerAnimator.SetBool("died",!transform.GetComponent<PlayerMovement>().isAlive);
        if (transform.GetComponent<PlayerMovement>().isRunning)
        {
            playerAnimator.SetBool("isRunning", true);
        }
        else
        {
            playerAnimator.SetBool("isRunning", false);
        }
    }
}
