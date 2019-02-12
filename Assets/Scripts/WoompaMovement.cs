using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoompaMovement : MonoBehaviour
{
    public float speed = 2f;
    private bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(facingRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else 
            transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Pillar"))
        facingRight = !facingRight;
    }
}
