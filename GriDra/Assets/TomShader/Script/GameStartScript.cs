using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.Extras;

public class GameStartScript : MonoBehaviour
{
    public bool start = false;
    public GameObject CountDownCanvas;
    public GameObject three;
    public GameObject two;
    public GameObject one;
    public GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        CountDownCanvas.SetActive(false);
        StartCoroutine("Hoge");
    }

    // Update is called once per frame
    void Update()
    {
        Gamestart();
    }

    private IEnumerator Hoge()
    {
        if (Input.GetKey("l"))
        {
            //Time.timeScale = 1;
            CountDownCanvas.SetActive(true);
            three.SetActive(true);
            two.SetActive(false);
            one.SetActive(false);
            go.SetActive(false);
            yield return new WaitForSeconds(1.0f);
            CountDownCanvas.SetActive(true);
            three.SetActive(false);
            two.SetActive(true);
            one.SetActive(false);
            go.SetActive(false);
            yield return new WaitForSeconds(1.0f);
            CountDownCanvas.SetActive(true);
            three.SetActive(false);
            two.SetActive(false);
            one.SetActive(true);
            go.SetActive(false);
            yield return new WaitForSeconds(1.0f);
            CountDownCanvas.SetActive(true);
            three.SetActive(false);
            two.SetActive(false);
            one.SetActive(false);
            go.SetActive(true);
            yield return new WaitForSeconds(1.0f);
            CountDownCanvas.SetActive(false);
        }
    }

    public void Gamestart()
    {
        if (start == true)
        {
            Hoge();
            //Time.timeScale = 0;
        }
    }

    public void PrintEvent(string s)
    {
        Debug.Log(s);
        if (s == "Start")
        {
            start = true;
        }
    }
}
