using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5;
    public Rigidbody2D rb2d;
    public GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }
    private void Update()
    {
        playerMoveVelocityIncrease();
    }
    protected void playerMoveVelocityIncrease()
    {
        float move = Input.GetAxis("Horizontal");
        if(move > 0 && player.transform.position.x >= transform.position.x - 5)
            rb2d.position += Vector2.right * move * Time.deltaTime * moveSpeed;
    }
}