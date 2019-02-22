using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public bool facingRight = true;
    protected Transform face;
    protected bool isTurnaroud = false;
    protected bool isAlive = true;
    public bool destroyable = false;
    public bool isKoopa = false;

    protected void Start()
    {
        face = transform.GetChild(1);
        isTurnaroud = false;
        isAlive = true;
        facingRight = true;
        destroyable = false;
    }

    void Update()
    {
        movementController();
    }

    protected virtual void movementController()
    {
        if (destroyable)
            Destroy(gameObject);
        if (!isAlive)
            return;
        isTurnaroud = Physics2D.OverlapCircle(face.position, 1f, LayerMask.GetMask("Ground"));
        if (isTurnaroud)
        {
            changeSide();
            transform.Rotate(Vector2.up, 180);
            isTurnaroud = !isTurnaroud;
        }
        if (facingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
            
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
            
    }

    public void changeSide()
    {
        facingRight = !facingRight;
    }

    public void changeSide(bool isRightSide)
    {
        facingRight = isRightSide;
    }

    public bool isFacingRight()
    {
        return facingRight;
    }

    public void die()
    {
        isAlive = false;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
    }
}
