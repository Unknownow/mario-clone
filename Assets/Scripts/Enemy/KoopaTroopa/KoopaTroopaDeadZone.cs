using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaTroopaDeadZone : EnemyDeadZone
{
    private new void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player's Feet"))
        {
            gameObject.GetComponentInParent<KoopaTroopaStatus>().changeNormalState();
        }
    }
}
