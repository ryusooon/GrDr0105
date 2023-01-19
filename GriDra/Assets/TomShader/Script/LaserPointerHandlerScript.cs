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

    public GameObject countObj; //CountObject�ACountDownScript�̗L�����A������������̂Ɏg�p
    //public GameObject closeButton;
    //public GameObject buckButton;

    public GameObject Righthand;            //��
    private SteamVR_LaserPointer slScript;�@//��
    private GameObject line;

    private void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    //���[�U�[�|�C���^�[���Ώۂ̃I�u�W�F�N�g�ɐG��Ă��鎞�ɃR���g���[���[�̃g���K�[(�l�����w)��������
    public void PointerClick(object sender, PointerEventArgs e)
    {
        //�Ώۂ̃I�u�W�F�N�g��StartButton�̏ꍇ�{�^����Ԃ���MainScene�ɑJ��
        if (e.target.name == "StartButton")
        {
            GameObject startbutton = GameObject.Find("StartButton");
            startbutton.GetComponent<Renderer>().material.color = Color.red;
            Time.timeScale = 0.01f;
            SceneManager.LoadScene("MainScene");
        }

        //�Ώۂ̃I�u�W�F�N�g��EndButton�̏ꍇ�{�^����Ԃ����A�v�������@StartScene�ɑJ��
        //if (e.target.name == "EndButton")
        //{
        //    GameObject endbutton = GameObject.Find("EndButton");
        //    endbutton.GetComponent<Renderer>().material.color = Color.red;
        //    UnityEditor.EditorApplication.isPlaying = false;
        //    Application.Quit(); //�Q�[���I��
        //    //SceneManager.LoadScene("StartScene");
        //}

        //�Ώۂ̃I�u�W�F�N�g��BuckToTitolButton�̏ꍇ�{�^����Ԃ���StartScene�ɑJ��
        //if (e.target.name == "BuckToTitolButton")
        //{
        //    GameObject bucktotitolbutton = GameObject.Find("BuckToTitolButton");
        //    bucktotitolbutton.GetComponent<Renderer>().material.color = Color.red;
        //    Time.timeScale = 0.01f;
        //    SceneManager.LoadScene("StartScene");
        //}

        //�Ώۂ̃I�u�W�F�N�g��CloseButton�̏ꍇ�{�^����Ԃ���Pause��ʂ����
        //if (e.target.name == "CloseButton")
        //{
        //    GameObject closebutton = GameObject.Find("CloseButton");
        //    closebutton.GetComponent<Renderer>().material.color = Color.red;
        //    countObj.GetComponent<CountDown>().enabled = true;

        //    //closeButton.SetActive(false);
        //    //buckButton.SetActive(false);

        //    //ToX1.ReSet = !ToX1.ReSet;
        //    //ToZ2.ReSet = !ToZ2.ReSet;

        //    slScript.line.SetActive(false);//��
        //    //SceneManager.LoadScene("StartScene");
        //}
    }

    //���[�U�[�|�C���^�[���Ώۂ̃I�u�W�F�N�g�ɐG�ꂽ���I�u�W�F�N�g�̐F��ς���
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

    //���[�U�[�|�C���^�[���Ώۂ̃I�u�W�F�N�g���痣��Ă��鎞�I�u�W�F�N�g�̐F��ς���
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
        //Vive�Ȃ��̃e�X�g�p(StartScene����̈ړ��̂�)
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    Time.timeScale = 0.01f;
        //    SceneManager.LoadScene("MainScene");
        //}
    }
}
