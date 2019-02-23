using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBreak : MonoBehaviour
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
		if(collision.transform.CompareTag("Player"))
		{
            if(collision.GetComponent<PlayerStatus>().isBigger)
                go.GetComponent<BrickBreakAnimationController>().isHit = true;
		}
	}
}
