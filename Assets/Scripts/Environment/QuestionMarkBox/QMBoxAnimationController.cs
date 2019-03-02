using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QMBoxAnimationController : MonoBehaviour
{
    Animator qMBoxAnimator;
    GameObject go;

    public void AlertObservers(string message)
    {
        if (message.Equals("Ended"))
        {
            go.GetComponent<QMBoxController>().isOpen = true;
            go.GetComponent<QMBoxController>().Spawn();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        go = this.gameObject;
        qMBoxAnimator = transform.GetComponent<Animator>();
        qMBoxAnimator.SetBool("Open Mushroom", false);
        qMBoxAnimator.SetBool("Open Star", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (go.GetComponent<QMBoxController>().spawnMushroom)
        {
            qMBoxAnimator.SetBool("Open Mushroom", true);
        }
        if (go.GetComponent<QMBoxController>().spawnStar)
        {
            qMBoxAnimator.SetBool("Open Star", true);
        }
    }
}
