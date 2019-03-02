using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QMBoxController: MonoBehaviour
{
    public bool spawnMushroom = false;
    public bool spawnStar = false;

    public bool hasMushroom = true;
    public bool isOpen = false;
    Transform spawnLocation;

    public GameObject mushroom;
    public GameObject star;
    
    GameObject go, cgo;

    // Start is called before the first frame update
    void Start()
    {
        go = this.gameObject;
        cgo = this.transform.GetChild(0).gameObject;
        spawnLocation = this.transform.GetChild(2);
        go.GetComponent<Renderer>().enabled = true;
        cgo.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            go.GetComponent<Renderer>().enabled = false;
            cgo.GetComponent<Renderer>().enabled = true;
        }
    }

    public void Spawn()
    {
        if (spawnMushroom)
            Instantiate(mushroom, spawnLocation.position, spawnLocation.rotation);
        if (spawnStar)
            Instantiate(star, spawnLocation.position, spawnLocation.rotation);
    }
}
