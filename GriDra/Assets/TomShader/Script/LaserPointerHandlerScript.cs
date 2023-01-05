using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Valve.VR.Extras;

public class LaserPointerHandlerScript : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;

    private void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    //レーザーポインターが対象のオブジェクトに触れている時にコントローラーのトリガー(人差し指)を押すとシーン遷移する
    public void PointerClick(object sender, PointerEventArgs e)
    {
        //対象のオブジェクトがStartButtonの場合ボタンを赤くしMainSceneに遷移
        if (e.target.name == "StartButton")
        {
            GameObject startbutton = GameObject.Find("StartButton");
            startbutton.GetComponent<Renderer>().material.color = Color.red;
            SceneManager.LoadScene("MainScene");
        }

        //対象のオブジェクトがEndButtonの場合ボタンを赤くしStartSceneに遷移
        if (e.target.name == "EndButton")
        {
            GameObject startbutton = GameObject.Find("EndButton");
            startbutton.GetComponent<Renderer>().material.color = Color.red;
            SceneManager.LoadScene("StartScene");
        }
    }

    //レーザーポインターが対象のオブジェクトに触れた時オブジェクトの色を変える
    public void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "StartButton")
        {
            GameObject startbutton = GameObject.Find("StartButton");
            startbutton.GetComponent<Renderer>().material.color = Color.blue;
        }

        if (e.target.name == "EndButton")
        {
            GameObject startbutton = GameObject.Find("EndButton");
            startbutton.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }

    //レーザーポインターが対象のオブジェクトから離れている時オブジェクトの色を変える
    public void PointerOutside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "StartButton")
        {
            GameObject startbutton = GameObject.Find("StartButton");
            startbutton.GetComponent<Renderer>().material.color = Color.yellow;
        }

        if (e.target.name == "EndButton")
        {
            GameObject startbutton = GameObject.Find("EndButton");
            startbutton.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
