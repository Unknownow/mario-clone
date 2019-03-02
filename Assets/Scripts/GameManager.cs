using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool playerAlive = true;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        playerAlive = true;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerAlive = player.GetComponent<PlayerMovement>().isAlive;
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(0);
        if (Input.GetKeyDown(KeyCode.X))
            Application.Quit();
    }
}
