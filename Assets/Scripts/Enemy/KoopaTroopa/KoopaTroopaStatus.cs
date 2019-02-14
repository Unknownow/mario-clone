using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaTroopaStatus : MonoBehaviour
{
    
    private bool normalState = true;        //check xem co phai trang thai binh thuong hay ko
    private bool bowlingState = false;      //check xem co dang phai trong trang thai bowling ko
    public int maxTimeChangeState = 5;      //thoi gian toi da de chuyen trang thai tu
    public float changeStateCountdown;
    private float maxSpeed;                 //bien luu toc do

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

        //countdown thoat khoi trang thai chui trong vo
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

    //chuyen tu trang thai chui trong vo thanh trang thai di lai binh thuong va nguoc lai
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //neu trong trang thai chui trong vo thi se bi ban di neu co nguoi choi cham vao
        if (!normalState)
        {
            if (collision.transform.CompareTag("Player") || collision.transform.CompareTag("Player's Feet"))
            {
                movementController.speed = maxSpeed * 4;
                bowlingState = true;
                if (collision.transform.position.x > transform.position.x)
                    movementController.changeSide(false);
                else
                    movementController.changeSide(true);
            }
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
}
