using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaTroopaMovement : EnemyMovement
{
    private KoopaTroopaStatus status;
    private void Start()
    {
        status = gameObject.GetComponentInParent<KoopaTroopaStatus>();
    }

    private void Update()
    {
        if (status.isNormalState() || status.isBowlingState()) 
            movementController();
    }
}
