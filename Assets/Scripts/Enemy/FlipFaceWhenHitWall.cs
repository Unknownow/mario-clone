using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipFaceWhenHitWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.parent.transform.Rotate(Vector2.up, 180);
    }
}
