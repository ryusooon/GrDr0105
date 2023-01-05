using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TrigerPullScript : MonoBehaviour
{
    //�g���K�[���ǂꂾ��������Ă���̂����擾���邽�߂̕ϐ�
    public SteamVR_Action_Single TriggerPull;

    //���ʂ̊i�[�pfloot�^�֐�
    public float PullLeft, PullRight;

    // Start is called before the first frame update
    void Start()
    {
        //�ϐ���SteamVR_Actions.default_Squeeze���Œ�
        TriggerPull = SteamVR_Actions.default_Squeeze;
    }

    // Update is called once per frame
    void Update()
    {
        //���ʂ�GetLastAxis�Ŏ擾���Ċi�[�i���R���g���[���Łj
       �@PullLeft = TriggerPull.GetLastAxis(SteamVR_Input_Sources.LeftHand);
        //���g�̊m�F
        Debug.Log("Left:" + PullLeft);

        //���ʂ�GetLastAxis�Ŏ擾����pullright�Ɋi�[�i�E�R���g���[���Łj
        PullRight = TriggerPull.GetLastAxis(SteamVR_Input_Sources.RightHand);
        //���g�̊m�F
        Debug.Log("Right:" + PullRight);
    }
}
