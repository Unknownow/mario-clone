using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

	public bool isBigger = false;
    public bool isInvicible = false;
    public bool isFabulous = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isInvicible || isFabulous)
        {
            invicibleAnimation();
        }
    }

    void invicibleAnimation()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = !gameObject.GetComponent<SpriteRenderer>().enabled;
    }
}
