using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoopaDeadZone : EnemyDeadZone
{
    public Animator woompaAnimator;
    private void Start()
    {
        woompaAnimator = transform.GetComponentInParent<Animator>();
    }

    

    protected override void deadFunction()
    {
        woompaAnimator.SetBool("isAlive", false);
        transform.GetComponentInParent<WoompaMovement>().speed = 0;
        transform.GetComponentInParent<WoompaMovement>().die();
    }
}
