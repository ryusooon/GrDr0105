using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.InteractionSystem;

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

    [SerializeField] TrigerPullScript NowTriger;
    [SerializeField] TestControllerScript testcon;

    private GameManagerScript gamemanager;
    public GameObject GM;

    int score;

    public GameObject endButton;

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GM.GetComponent<GameManagerScript>();
        //score = ; //�������ɑ��X�N���v�g��������Ă����X�R�A����
        resultCanv.SetActive(false);
        endButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gamemanager.tmp);
    }

    void ResultScreen()
    {
        testcon.enabled = false;

        endButton.SetActive(true);
        score = gamemanager.tmp; //�������ɑ��X�N���v�g��������Ă����X�R�A����
        resultCanv.SetActive(true);
        Result.enabled = true;
        Result.sprite = resultPNG;
        Score.enabled = true;
        //�X�R�A�̒l�ɂ���ĕ\������摜(�]��)��ς���
        if (score <= 25)
        {
            Score.sprite = scorePNG1; //���̏���4��
        }
        else if (score <= 50)
        {
            Score.sprite = scorePNG2;
        }
        else if (score <= 75)
        {
            Score.sprite = scorePNG3;
        }
        else
        {
            Score.sprite = scorePNG4;
        }

        if (NowTriger.PullRight == 1)
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
