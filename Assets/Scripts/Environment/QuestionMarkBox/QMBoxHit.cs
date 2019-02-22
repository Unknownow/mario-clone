using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QMBoxHit : MonoBehaviour
{
    GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        go = transform.root.gameObject;
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
                if (!collision.gameObject.GetComponent<PlayerStatus>().isBigger)
                {
                    go.GetComponent<QMBoxController>().spawnMushroom = true;
                    return;
                }
            }
            go.GetComponent<QMBoxController>().spawnStar = true;
        }
    }
}
