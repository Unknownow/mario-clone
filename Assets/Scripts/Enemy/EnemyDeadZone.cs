using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadZone : MonoBehaviour
{ 
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player's Feet"))
        {
            deadFunction();
            Rigidbody2D temp = collision.transform.GetComponentInParent<Rigidbody2D>();
            temp.velocity = new Vector2(temp.velocity.x, 0);
            temp.AddForce(Vector2.up * 50, ForceMode2D.Impulse);
        }
    }
    protected virtual void deadFunction()
    {

    }
}
