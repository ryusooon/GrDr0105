using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.Extras;

public class CountDown : MonoBehaviour
{
    public GameObject timer_object = null;
    public float countTime = 4.0f;
    int seconds;

    [SerializeField] Image Count;
    [SerializeField] Sprite three;
    [SerializeField] Sprite two;
    [SerializeField] Sprite one;
    [SerializeField] Sprite start;
    [SerializeField] Sprite menu;

    [SerializeField] Image Pauseimg;
    [SerializeField] Sprite pause;

    public GameObject countobj; //CountObject、CountDownScriptの有効化、無効化をするのに使用
    public GameObject countcanv; //CountDownCanvsの表示、非表示の切り替えに使用

    public GameObject closeButton;
    public GameObject buckButton;

    // ↓築花追記
    [SerializeField] MovePointScript ToX1;
    [SerializeField] MovePointScript ToZ2;

    //public GameObject Righthand;            //林
    //private SteamVR_LaserPointer slScript;　//林

    // Start is called before the first frame update
    void Start()
    {
        Count = GameObject.Find("Image").GetComponent<Image>();
        Count.enabled = false;
        countobj.GetComponent<CountDown>().enabled = false;

        ToX1.ReSet = !ToX1.ReSet;
        ToZ2.ReSet = !ToZ2.ReSet;

        //slScript = Righthand.GetComponent<SteamVR_LaserPointer>();//林
    }

    // Update is called once per frame
    void Update()
    {
        countTime -= Time.deltaTime * 100.0f; //カウント中はゲーム内時間が0.01倍速になっているので100をかける
        seconds = (int)countTime;

        //デバッグ用のタイマーのテキスト表示
        //Text timer_text = timer_object.GetComponent<Text>();
        //timer_text.text = seconds.ToString();

        //タイマー(countTime)が4未満の時画像3を表示
        if (countTime < 4)
        {
            closeButton.SetActive(false);
            buckButton.SetActive(false);
            Pauseimg.enabled = false;
            Count.enabled = true;
            Count.sprite = three;
        }

        //タイマー(countTime)が3未満の時画像2を表示
        if (countTime < 3)
        {
            Count.sprite = two;
        }

        //タイマー(countTime)が2未満の時画像1を表示
        if (countTime < 2)
        {
            Count.sprite = one;
        }

        //タイマー(countTime)が1未満の時画像startを表示
        if (countTime < 1)
        {
            Count.sprite = start;
        }

        //タイマー(countTime)が0もしくは0未満になった時、CountObject、CountDownScriptを無効化してCanvasを非表示にしゲーム内時間を通常に戻してゲームを再開させ、countTimeを4.0にする
        if (countTime <= 0)
        {
            countobj.GetComponent<CountDown>().enabled = false;
            countcanv.SetActive(false);
            Time.timeScale = 1.0f;
            countTime = 4.0f;

            
        }

        //タイマー(countTime)が4の時pauseを表示する
        {
            if (countTime == 4)
            {
                Count.enabled = true;
                Count.sprite = menu;
                Pauseimg.enabled = true;
                Pauseimg.sprite = pause;
            }
        }
    }
}
