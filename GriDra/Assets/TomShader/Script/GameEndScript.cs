using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.Extras;

public class GameEndScript : MonoBehaviour
{
    public bool end = false;
    public GameObject endButton;

    // Start is called before the first frame update
    void Start()
    {
        endButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(end == true)
        {
            endButton.SetActive(true);
            //SceneManager.LoadScene("EndScene");
        }
    }
    public void PrintEvent(string e)
    {
        Debug.Log(e);
        if(e == "End")
        {
            end = true;
        }
    }
}
