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

    public GameObject countObj; //CountObject、CountDownScriptの有効化、無効化をするのに使用
    //public GameObject closeButton;
    //public GameObject buckButton;

    public GameObject Righthand;            //林
    private SteamVR_LaserPointer slScript;　//林
    private GameObject line;

    private void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    //レーザーポインターが対象のオブジェクトに触れている時にコントローラーのトリガー(人差し指)を押すと
    public void PointerClick(object sender, PointerEventArgs e)
    {
        //対象のオブジェクトがStartButtonの場合ボタンを赤くしMainSceneに遷移
        if (e.target.name == "StartButton")
        {
            GameObject startbutton = GameObject.Find("StartButton");
            startbutton.GetComponent<Renderer>().material.color = Color.red;
            Time.timeScale = 0.01f;
            SceneManager.LoadScene("MainScene");
        }

        //対象のオブジェクトがEndButtonの場合ボタンを赤くしアプリを閉じる　StartSceneに遷移
        //if (e.target.name == "EndButton")
        //{
        //    GameObject endbutton = GameObject.Find("EndButton");
        //    endbutton.GetComponent<Renderer>().material.color = Color.red;
        //    UnityEditor.EditorApplication.isPlaying = false;
        //    Application.Quit(); //ゲーム終了
        //    //SceneManager.LoadScene("StartScene");
        //}

        //対象のオブジェクトがBuckToTitolButtonの場合ボタンを赤くしStartSceneに遷移
        //if (e.target.name == "BuckToTitolButton")
        //{
        //    GameObject bucktotitolbutton = GameObject.Find("BuckToTitolButton");
        //    bucktotitolbutton.GetComponent<Renderer>().material.color = Color.red;
        //    Time.timeScale = 0.01f;
        //    SceneManager.LoadScene("StartScene");
        //}

        //対象のオブジェクトがCloseButtonの場合ボタンを赤くしPause画面を閉じる
        //if (e.target.name == "CloseButton")
        //{
        //    GameObject closebutton = GameObject.Find("CloseButton");
        //    closebutton.GetComponent<Renderer>().material.color = Color.red;
        //    countObj.GetComponent<CountDown>().enabled = true;

        //    //closeButton.SetActive(false);
        //    //buckButton.SetActive(false);

        //    //ToX1.ReSet = !ToX1.ReSet;
        //    //ToZ2.ReSet = !ToZ2.ReSet;

        //    slScript.line.SetActive(false);//林
        //    //SceneManager.LoadScene("StartScene");
        //}
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
            startbutton.GetComponent<Renderer>().material.color = Color.blue;
        }

        //if (e.target.name == "BuckToTitolButton")
        //{
        //    GameObject startbutton = GameObject.Find("BuckToTitolButton");
        //    startbutton.GetComponent<Renderer>().material.color = Color.blue;
        //}

        //if (e.target.name == "CloseButton")
        //{
        //    GameObject startbutton = GameObject.Find("CloseButton");
        //    startbutton.GetComponent<Renderer>().material.color = Color.blue;
        //}
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

        //if (e.target.name == "BuckToTitolButton")
        //{
        //    GameObject startbutton = GameObject.Find("BuckToTitolButton");
        //    startbutton.GetComponent<Renderer>().material.color = Color.yellow;
        //}

        //if (e.target.name == "CloseButton")
        //{
        //    GameObject startbutton = GameObject.Find("CloseButton");
        //    startbutton.GetComponent<Renderer>().material.color = Color.yellow;
        //}
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Viveなしのテスト用(StartSceneからの移動のみ)
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    Time.timeScale = 0.01f;
        //    SceneManager.LoadScene("MainScene");
        //}
    }
}
