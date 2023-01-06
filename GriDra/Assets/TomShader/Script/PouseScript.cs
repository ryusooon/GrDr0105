using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PouseScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StopGame();
        ReStartGame();
    }

    public void StopGame()
    {
        if (Input.GetKeyDown("u"))
        {
            Time.timeScale = 0;
        }
    }
    public void ReStartGame()
    {
        if(Time.timeScale == 0)
        {
            if (Input.GetKeyDown("r"))
            {
                SceneManager.LoadScene("MainScene");
                Time.timeScale = 1;
            }
            if (Input.GetKeyDown("s"))
            {
                SceneManager.LoadScene("StartScene");
                Time.timeScale = 1;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1;
            }
        }
    }
}