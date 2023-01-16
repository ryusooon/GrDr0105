using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScript : MonoBehaviour
{
    [SerializeField] Image Result;
    [SerializeField] Sprite resultPNG;
    [SerializeField] Image Score;
    [SerializeField] Sprite scorePNG1;
    [SerializeField] Sprite scorePNG2;
    [SerializeField] Sprite scorePNG3;
    [SerializeField] Sprite scorePNG4;
    public GameObject resultCanv;

    int score;

    public GameObject endButton;

    // Start is called before the first frame update
    void Start()
    {
        //score = ←ここに他スクリプトからもってきたスコアを代入
        resultCanv.SetActive(false);
        endButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ResultScreen()
    {
        endButton.SetActive(true);
        //score = ←ここに他スクリプトからもってきたスコアを代入
        resultCanv.SetActive(true);
        Result.enabled = true;
        Result.sprite = resultPNG;
        Score.enabled = true;
        //スコアの値によって表示する画像(評価)を変える
        //if(score <= )
        //{
        //    Score.sprite = scorePNG1;
        //}
        //else if (score <= )
        //{
        //    Score.sprite = scorePNG2;
        //}
        //else if (score <= )
        //{
        //    Score.sprite = scorePNG3;
        //}
        //else
        //{
        //    Score.sprite = scorePNG4;
    }
}
