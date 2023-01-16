using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

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

    //private Vector2 pos;
    //float r, sita;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Teleport.GetStateDown(hand))
        {
            Time.timeScale = 0.01f; //�y��
            countCanv.SetActive(true); //�y��

            //���Z�b�g�����؂�ւ�
            //ToX1.ReSet = !ToX1.ReSet;
            //ToZ2.ReSet = !ToZ2.ReSet;

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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            countObj.GetComponent<CountDown>().enabled = true;
        }
    }
}
