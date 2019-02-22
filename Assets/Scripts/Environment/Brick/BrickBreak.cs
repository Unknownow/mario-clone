using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBreak : MonoBehaviour
{
    public GameObject go;

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
		if(collision.transform.CompareTag("Player"))
		{
            Debug.Log("1");
            go.GetComponent<BrickBreakAnimationController>().isHit = true;
		}
	}
}
