using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour
{

    public float flagStart = 4.5f;
    public float flagEnd= -3.5f;
    public float speed = 4f;

    bool isHit;
    Transform flag;

    // Start is called before the first frame update
    void Start()
    {
        flag = transform.GetChild(0);
        flag.transform.localPosition = new Vector3 (flag.localPosition.x,flagStart);
        isHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHit)
            if (flag.transform.localPosition.y > flagEnd)
            {
                flag.transform.Translate(Vector2.down * speed * Time.deltaTime);
            }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            isHit = true;
        }
    }
}
