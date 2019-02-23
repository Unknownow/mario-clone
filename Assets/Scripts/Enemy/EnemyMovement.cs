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
    protected bool isActivated = false;
    protected GameObject gameManager;

    protected void Start()
    {
        face = transform.GetChild(1);
        isTurnaroud = false;
        isAlive = true;
        facingRight = true;
        destroyable = false;
        isActivated = false;
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    void Update()
    {
        movementController();
    }

    protected virtual void movementController()
    {
        if (!gameManager.GetComponent<GameManager>().playerAlive)
            return;
        if (!isActivated)
            return;
        if (destroyable)
            Destroy(gameObject);
        if (!isAlive)
            return;
        isTurnaroud = Physics2D.OverlapCircle(face.position, .3f, LayerMask.GetMask("Ground"));
        if (isTurnaroud)
        {
            changeSide();
            
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
        transform.Rotate(Vector2.up, 180);
    }

    public void changeSide(bool isRightSide)
    {
        facingRight = isRightSide;
        if (isRightSide && transform.rotation.y != 0)
        {
            transform.Rotate(Vector2.up, 180);
        }
        else if(!isRightSide && transform.rotation.y == 0)
        {
            transform.Rotate(Vector2.up, 180);
        }
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
        if (collision.transform.CompareTag("MainCamera"))
        {
            isActivated = true;
        }
        else if (collision.transform.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
    }

}
