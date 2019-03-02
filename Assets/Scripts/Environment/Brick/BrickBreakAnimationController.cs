using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBreakAnimationController : MonoBehaviour
{
    public bool isHit = false;
    Animator brickAnimator;

    public void AlertObservers(string message)
    {
        if (message.Equals("Ended"))
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        brickAnimator = transform.GetComponent<Animator>();
        brickAnimator.SetBool("isHit", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isHit)
        {
            brickAnimator.SetBool("isHit", true);
        }
    }
}
