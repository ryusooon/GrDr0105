using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PouseScript : MonoBehaviour
{
    public GameObject three;
    public GameObject two;
    public GameObject one;
    public GameObject go;

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
            Time.timeScale = 0.01f;
        }
    }
    public void ReStartGame()
    {
        if(Time.timeScale == 0.01f)
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
                three.SetActive(true);
                Time.timeScale = 1;
            }
        }
    }
}
