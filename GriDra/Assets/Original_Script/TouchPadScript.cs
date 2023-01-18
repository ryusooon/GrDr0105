using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;

public class TouchPadScript : MonoBehaviour
{
    //private SteamVR_Action_Vector2 TrackPad = SteamVR_Actions.default_TrackPad;

    [SerializeField] SteamVR_Input_Sources hand;
    [SerializeField] SteamVR_Action_Boolean Teleport;

    bool TrackPadTouch;

    [SerializeField] MovePointScript ToX1;
    [SerializeField] MovePointScript ToZ2;

    public GameObject countObj; //CountObject�ACountDownScript�̗L�����A������������̂Ɏg�p //�y��
    public GameObject countCanv;�@//CountDownCanvs�̕\���A��\���̐؂�ւ��Ɏg�p�@//�y��
    public GameObject closeButton;
    public GameObject buckButton;


    //public GameObject ContRight;

    public GameObject Righthand;            //��
    private SteamVR_LaserPointer slScript;�@//��
    private GameObject line;

    //private Vector2 pos;
    //float r, sita;

    //�p�b�h�̂ǂ���G���Ă���̂����擾���邽�߂�TrackPad�Ƃ����֐���SteamVR_Actions.default_TrackPad���Œ�
    private SteamVR_Action_Vector2 TrackPad = SteamVR_Actions.default_TrackPad;
    //���ʂ̊i�[�pVector2�^�֐�
    private Vector2 posleft, posright;


    // Start is called before the first frame update
    void Start()
    {
        slScript = Righthand.GetComponent<SteamVR_LaserPointer>();//��

        posright = TrackPad.GetLastAxis(SteamVR_Input_Sources.RightHand);
        //posleft�̒��g���m�F
        Debug.Log("�G��Ă鏊" + posright.x + " " + posright.y);
    }

    // Update is called once per frame
    void Update()
    {

        posright = TrackPad.GetLastAxis(SteamVR_Input_Sources.RightHand);
        //posleft�̒��g���m�F
        Debug.Log( "�G��Ă鏊" + posright.x + " " + posright.y);


        if (Teleport.GetStateDown(hand))
        {
            Time.timeScale = 0.01f; //�y��
            countCanv.SetActive(true); //�y��
            closeButton.SetActive(true);
            buckButton.SetActive(true);

            //GameObject line = GameObject.Find("New Game Object"); //��
            //line = slScript.line;                                 //��

            slScript.line.SetActive(true);//��

            //line.SetActive(true);�@//��

            //���Z�b�g�����؂�ւ�
            ToX1.ReSet = !ToX1.ReSet;
            ToZ2.ReSet = !ToZ2.ReSet;

            //TrackPadTouch = !TrackPadTouch;
            Debug.Log("�p�b�h���́I");
        }
        else if (Teleport.GetStateUp(hand))
        {
            //���Z�b�g�����؂�ւ�
            //ToX1.ReSet = !ToX1.ReSet;
            //ToZ2.ReSet = !ToZ2.ReSet;

            //TrackPadTouch = !TrackPadTouch;
            Debug.Log("�p�b�h����w��������I");
        }

        //Debug.Log("�p�b�h��" + TrackPadTouch);

        //pos = TrackPad.GetLastAxis(SteamVR_Input_Sources.RightHand);
        //r = Mathf.Sqrt(pos.x * pos.x + pos.y * pos.y);
        //sita = Mathf.Atan2(pos.y, pos.x) / Mathf.PI * 180;

        //Debug.Log("�p�b�h�F" + r + " " + sita);
        //Debug.Log("�p�b�h�F" + pos.x + " " + pos.y);

        //Esc�L�[�����������J�E���g�_�E�����J�n���ăQ�[�����ĊJ(�����{�^���z�u����Ȃ肵�ăQ�[�������瑀��ł���悤�ɂ���) //�y��
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    countObj.GetComponent<CountDown>().enabled = true;

        //    ToX1.ReSet = !ToX1.ReSet;
        //    ToZ2.ReSet = !ToZ2.ReSet;

        //    slScript.line.SetActive(false);//��
        //}
    }
}
