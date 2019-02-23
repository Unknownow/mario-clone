using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QMBoxHit : MonoBehaviour
{
    public GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        go = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (go.GetComponent<QMBoxController>().hasMushroom)
            {
                go.GetComponent<QMBoxController>().spawnMushroom = true; 
                return;
            }
            go.GetComponent<QMBoxController>().spawnStar = true;
        }
    }
}
