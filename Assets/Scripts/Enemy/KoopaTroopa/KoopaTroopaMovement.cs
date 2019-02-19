using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaTroopaMovement : EnemyMovement
{
    private KoopaTroopaStatus status;
    private new void Start()
    {
        face = transform.GetChild(1);
        isTurnaroud = false;
        isAlive = true;
        facingRight = true;
        status = gameObject.GetComponentInParent<KoopaTroopaStatus>();
    }

    private void Update()
    {
        if (status.isNormalState() || status.isBowlingState()) 
            movementController();
    }
}
