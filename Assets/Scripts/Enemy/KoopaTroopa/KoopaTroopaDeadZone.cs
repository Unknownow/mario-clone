using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaTroopaDeadZone : EnemyDeadZone
{
    private KoopaTroopaStatus status;
    private void Start()
    {
        status = gameObject.GetComponentInParent<KoopaTroopaStatus>();
    }
    private new void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player's Feet"))
        {
            if (status.isNormalState())
            {
                status.changeNormalState();
                transform.parent.gameObject.tag = "Bowling";
                gameObject.GetComponentInParent<KoopaTroopaStatus>().anim.SetBool("isBowling", true);
            }
            Rigidbody2D temp = collision.transform.GetComponentInParent<Rigidbody2D>();
            temp.velocity = new Vector2(temp.velocity.x, 0);
            temp.AddForce(Vector2.up * 50, ForceMode2D.Impulse);
        }  
    }
}
