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

    //���[�U�[�|�C���^�[���Ώۂ̃I�u�W�F�N�g�ɐG��Ă��鎞�ɃR���g���[���[�̃g���K�[(�l�����w)�������ƃV�[���J�ڂ���
    public void PointerClick(object sender, PointerEventArgs e)
    {
        //�Ώۂ̃I�u�W�F�N�g��StartButton�̏ꍇ�{�^����Ԃ���MainScene�ɑJ��
        if (e.target.name == "StartButton")
        {
            GameObject startbutton = GameObject.Find("StartButton");
            startbutton.GetComponent<Renderer>().material.color = Color.red;
            SceneManager.LoadScene("MainScene");
        }

        //�Ώۂ̃I�u�W�F�N�g��EndButton�̏ꍇ�{�^����Ԃ���StartScene�ɑJ��
        if (e.target.name == "EndButton")
        {
            GameObject startbutton = GameObject.Find("EndButton");
            startbutton.GetComponent<Renderer>().material.color = Color.red;
            SceneManager.LoadScene("StartScene");
        }
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
            startbutton.GetComponent<Renderer>().material.color = Color.yellow;
        }
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
