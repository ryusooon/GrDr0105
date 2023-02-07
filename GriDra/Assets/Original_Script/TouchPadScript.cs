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

    public bool Touch_Up, Touch_Down;
    //[SerializeField] CountDown CouDoSc;

    public bool game;

    // Start is called before the first frame update
    void Start()
    {
        slScript = Righthand.GetComponent<SteamVR_LaserPointer>();//��


        Debug.Log("���Z�b�g");

        game = true;
    }

    // Update is called once per frame
    void Update()
    {

        posright = TrackPad.GetLastAxis(SteamVR_Input_Sources.RightHand);
        //posleft�̒��g���m�F
        Debug.Log("�G��Ă鏊" + posright.x + " " + posright.y);

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
            Debug.Log("��G���Ă�");
        }
        if (Touch_Down)
        {
            Debug.Log("���G���Ă�");
        }

        if (game == false)
        {
            Debug.Log("game��false");

            //if(Touch_Up && Teleport.GetStateDown(hand))
            if (Touch_Up)
            {
                Debug.Log("game��false���ɏ�");

                if (Teleport.GetStateDown(hand))
                {
                    game = true;
                    countObj.GetComponent<CountDown>().enabled = true;
                    Debug.Log("�J�E���g�_�E���J�n");
                }
            }
            //else if(Touch_Down && Teleport.GetStateDown(hand))
            else if (Touch_Down)
            {
                Debug.Log("game��false���ɉ�");

                if (Teleport.GetStateDown(hand))
                {
                    Time.timeScale = 1.0f;
                    game = true;
                    SceneManager.LoadScene("StartScene");
                    Debug.Log("�^�C�g����ʂ֑J��");
                }
            }

            //Vive�Ȃ��̃e�X�g�p
            //if (Input.GetKeyDown(KeyCode.K))
            //{
            //    game = true;
            //    countObj.GetComponent<CountDown>().enabled = true;
            //    Debug.Log("�J�E���g�_�E���J�n");
            //}
            //if (Input.GetKeyDown(KeyCode.J))
            //{
            //    Time.timeScale = 1.0f;
            //    game = true;
            //    SceneManager.LoadScene("StartScene");
            //    Debug.Log("�^�C�g����ʂ֑J��");
            //}
        }
        else if(game == true)
        {
            if (Teleport.GetStateDown(hand) || Input.GetKeyDown(KeyCode.H))
            {
                Debug.Log("�p�b�h���́I");

                //���Z�b�g�����؂�ւ�
                ToX1.ReSet = !ToX1.ReSet;
                ToZ2.ReSet = !ToZ2.ReSet;

                //�g���b�N�p�b�h�������ꂽ��timeScale��0.01�ɂ��āAPause��ʂ�\��
                game = false;
                Time.timeScale = 0.01f; //�y��
                countCanv.SetActive(true); //�y��
                closeButton.SetActive(true);
                buckButton.SetActive(true);

                //GameObject line = GameObject.Find("New Game Object"); //��
                //line = slScript.line;                                 //��

                //slScript.line.SetActive(true);//��

                //line.SetActive(true);�@//��

                TrackPadTouch = !TrackPadTouch;

            }

            if (Teleport.GetStateUp(hand))
            {
                //���Z�b�g�����؂�ւ�
                ToX1.ReSet = !ToX1.ReSet;
                ToZ2.ReSet = !ToZ2.ReSet;

                TrackPadTouch = !TrackPadTouch;
                Debug.Log("�p�b�h����w��������I");
            }

            Debug.Log("game��ture");
        }


        Debug.Log("�p�b�h��" + TrackPadTouch);

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
