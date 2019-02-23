using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingKill : MonoBehaviour
{

    KoopaTroopaStatus status;
    // Start is called before the first frame update
    void Start()
    {
        status = transform.parent.GetComponent<KoopaTroopaStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            if (!status.isBowlingState())
                return;
            collision.gameObject.GetComponent<Collider2D>().isTrigger = true;
            collision.gameObject.GetComponent<EnemyMovement>().enabled = false;
            collision.transform.Rotate(0, 0, 180);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 2) * 5, ForceMode2D.Impulse);
            if (collision.gameObject.GetComponent<EnemyMovement>().isKoopa)
            {
                collision.gameObject.GetComponent<KoopaTroopaStatus>().anim.SetBool("isBowling", true);
            }
        }
    }
}
