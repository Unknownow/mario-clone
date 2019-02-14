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
        if(collision.transform.CompareTag("Player's Feet") && status.isNormalState())
        {
            status.changeNormalState();
        }
    }
}
