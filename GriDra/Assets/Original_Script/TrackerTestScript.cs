using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.XR;
using Valve.VR;

public class TrackerTestScript : MonoBehaviour
{

    //�g���b�J�[�̈ʒu���W�i�[�p
    public Vector3 Tracker1Posision;

    //�g���b�J�[�̉�]���W�i�[�p�i�N�H�[�^�j�I���j
    public Quaternion Tracker1RotationQ;
    //�g���b�J�[�̉�]���W�i�[�p�i�I�C���[�p�j
    public Vector3 Tracker1Rotation;

    //�g���b�J�[��pose�����擾���邽�߂�tracker1�Ƃ����֐���SteamVR_Actions.default_Pose���Œ�
    public SteamVR_Action_Pose tracker1 = SteamVR_Actions.default_Pose;

    //1�t���[�����ɌĂяo�����Update���]�b�g
    void Update()
    {
        //�ʒu���W���擾
        Tracker1Posision = tracker1.GetLocalPosition(SteamVR_Input_Sources.Waist);
        //��]���W���N�H�[�^�j�I���Œl���󂯎��
        Tracker1RotationQ = tracker1.GetLocalRotation(SteamVR_Input_Sources.Waist);
        //�擾�����l���N�H�[�^�j�I�� �� �I�C���[�p�ɕϊ�
        Tracker1Rotation = Tracker1RotationQ.eulerAngles;
    }

}