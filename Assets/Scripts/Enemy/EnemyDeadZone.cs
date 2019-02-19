using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadZone : MonoBehaviour
{ 
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player's Feet"))
        {
            Debug.Log("Died");
            deadFunction();
        }
    }
    protected virtual void deadFunction()
    {

    }
}
