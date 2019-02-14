using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaTroopaStatus : MonoBehaviour
{
    private bool normalState = true;
    private bool bowlingState = false;
    public int maxTimeChangeState = 5;
    public float changeStateCountdown;
    private float maxSpeed;

    private KoopaTroopaMovement movementController;
    // Start is called before the first frame update
    void Start()
    {
        changeStateCountdown = maxTimeChangeState;
        movementController = gameObject.GetComponentInParent<KoopaTroopaMovement>();
        maxSpeed = movementController.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!normalState && movementController.speed == maxSpeed)
        {
            changeStateCountdown -= Time.deltaTime;
            if(changeStateCountdown <= 0)
            {
                changeStateCountdown = maxTimeChangeState;
                changeNormalState();
            }
        }
    }

    public void changeNormalState()
    {
        if (normalState)
        {
            normalState = !normalState;
        }
        else if(!normalState && movementController.speed == maxSpeed)
        {
            normalState = !normalState;
        }
    }

    public bool isNormalState()
    {
        return normalState;
    }
    public bool isBowlingState()
    {
        return bowlingState;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player") || collision.transform.CompareTag("Player's Feet"))
        {
            movementController.speed = maxSpeed * 4;
            bowlingState = true;
            if(collision.transform.position.x > transform.position.x)
        }
    }
}
