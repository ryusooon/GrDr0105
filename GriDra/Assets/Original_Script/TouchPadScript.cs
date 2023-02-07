using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;
using UnityEngine.SceneManagement;

public class TouchPadScript : MonoBehaviour
{
    //private SteamVR_Action_Vector2 TrackPad = SteamVR_Actions.default_TrackPad;

    [SerializeField] SteamVR_Input_Sources hand;
    [SerializeField] SteamVR_Action_Boolean Teleport;

    bool TrackPadTouch;

    [SerializeField] MovePointScript ToX1;
    [SerializeField] MovePointScript ToZ2;

    public GameObject countObj; //CountObject、CountDownScriptの有効化、無効化をするのに使用 //冨岡
    public GameObject countCanv;　//CountDownCanvsの表示、非表示の切り替えに使用　//冨岡
    public GameObject closeButton;
    public GameObject buckButton;


    //public GameObject ContRight;

    public GameObject Righthand;            //林
    private SteamVR_LaserPointer slScript;　//林
    private GameObject line;

    //private Vector2 pos;
    //float r, sita;

    //パッドのどこを触っているのかを取得するためのTrackPadという関数にSteamVR_Actions.default_TrackPadを固定
    private SteamVR_Action_Vector2 TrackPad = SteamVR_Actions.default_TrackPad;
    //結果の格納用Vector2型関数
    private Vector2 posleft, posright;

    public bool Touch_Up, Touch_Down;
    //[SerializeField] CountDown CouDoSc;

    public bool game;

    // Start is called before the first frame update
    void Start()
    {
        slScript = Righthand.GetComponent<SteamVR_LaserPointer>();//林


        Debug.Log("リセット");

        game = true;
    }

    // Update is called once per frame
    void Update()
    {

        posright = TrackPad.GetLastAxis(SteamVR_Input_Sources.RightHand);
        //posleftの中身を確認
        Debug.Log("触れてる所" + posright.x + " " + posright.y);

        if (posright.y > 0.0f)
        {
            Touch_Up = true;
            Touch_Down = false;
        }
        else if (posright.y < 0.0f)
        {
            Touch_Up = false;
            Touch_Down = true;
        }
        else
        {
            Touch_Up = false;
            Touch_Down = false;
        }

        if (Touch_Up)
        {
            Debug.Log("上触ってる");
        }
        if (Touch_Down)
        {
            Debug.Log("下触ってる");
        }

        if (game == false)
        {
            Debug.Log("gameはfalse");

            //if(Touch_Up && Teleport.GetStateDown(hand))
            if (Touch_Up)
            {
                Debug.Log("gameがfalse中に上");

                if (Teleport.GetStateDown(hand))
                {
                    game = true;
                    countObj.GetComponent<CountDown>().enabled = true;
                    Debug.Log("カウントダウン開始");
                }
            }
            //else if(Touch_Down && Teleport.GetStateDown(hand))
            else if (Touch_Down)
            {
                Debug.Log("gameがfalse中に下");

                if (Teleport.GetStateDown(hand))
                {
                    Time.timeScale = 1.0f;
                    game = true;
                    SceneManager.LoadScene("StartScene");
                    Debug.Log("タイトル画面へ遷移");
                }
            }

            //Viveなしのテスト用
            //if (Input.GetKeyDown(KeyCode.K))
            //{
            //    game = true;
            //    countObj.GetComponent<CountDown>().enabled = true;
            //    Debug.Log("カウントダウン開始");
            //}
            //if (Input.GetKeyDown(KeyCode.J))
            //{
            //    Time.timeScale = 1.0f;
            //    game = true;
            //    SceneManager.LoadScene("StartScene");
            //    Debug.Log("タイトル画面へ遷移");
            //}
        }
        else if(game == true)
        {
            if (Teleport.GetStateDown(hand) || Input.GetKeyDown(KeyCode.H))
            {
                Debug.Log("パッド入力！");

                //リセット処理切り替え
                ToX1.ReSet = !ToX1.ReSet;
                ToZ2.ReSet = !ToZ2.ReSet;

                //トラックパッドが押されたらtimeScaleを0.01にして、Pause画面を表示
                game = false;
                Time.timeScale = 0.01f; //冨岡
                countCanv.SetActive(true); //冨岡
                closeButton.SetActive(true);
                buckButton.SetActive(true);

                //GameObject line = GameObject.Find("New Game Object"); //林
                //line = slScript.line;                                 //林

                //slScript.line.SetActive(true);//林

                //line.SetActive(true);　//林

                TrackPadTouch = !TrackPadTouch;

            }

            if (Teleport.GetStateUp(hand))
            {
                //リセット処理切り替え
                ToX1.ReSet = !ToX1.ReSet;
                ToZ2.ReSet = !ToZ2.ReSet;

                TrackPadTouch = !TrackPadTouch;
                Debug.Log("パッドから指を放した！");
            }

            Debug.Log("gameはture");
        }


        Debug.Log("パッド状況" + TrackPadTouch);

        //pos = TrackPad.GetLastAxis(SteamVR_Input_Sources.RightHand);
        //r = Mathf.Sqrt(pos.x * pos.x + pos.y * pos.y);
        //sita = Mathf.Atan2(pos.y, pos.x) / Mathf.PI * 180;

        //Debug.Log("パッド：" + r + " " + sita);
        //Debug.Log("パッド：" + pos.x + " " + pos.y);

        //Escキーを押した時カウントダウンを開始してゲームを再開(ここボタン配置するなりしてゲーム内から操作できるようにする) //冨岡
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    countObj.GetComponent<CountDown>().enabled = true;

        //    ToX1.ReSet = !ToX1.ReSet;
        //    ToZ2.ReSet = !ToZ2.ReSet;

        //    slScript.line.SetActive(false);//林
        //}
    }
}
