using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    protected bool facingRight = true;

    void Update()
    {
        movementController();
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Pillar"))
            changeSide();
    }

    protected void movementController()
    {
        if (facingRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void changeSide()
    {
        facingRight = !facingRight;
    }

    public bool isFacingRight()
    {
        return facingRight;
    }
}
