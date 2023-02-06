using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class CollisionDetectionScript : MonoBehaviour
{

    public bool Stan;
    public float StanTime;

    SoundManagerScript soundscript;

    public GameObject gamemanager;

    float Time;

    private SteamVR_Action_Single squeeze = SteamVR_Actions.default_Squeeze;
    private SteamVR_Action_Vibration vibration = SteamVR_Actions.default_Haptic;

    // Start is called before the first frame update
    void Start()
    {
        Stan = false;
        Time = 0;
        soundscript = gamemanager.GetComponent<SoundManagerScript>();
    }

    // Update is called once per frame
     void FixedUpdate()
    {

        if (Stan) // �X�^����Ԃ̏ꍇ
        {

            if (Time < StanTime)
            {
                // �X�^���^�C����莞�Ԍo�߂��Ă��Ȃ����
                Time++;
            }
            else
            {
                // �X�^���^�C�������Ԍo�߂�����
                Stan = false;
                Time = 0;
            }

        }

        Debug.Log("�X�^�����̃^�C���F" + Time);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Drtama" || other.gameObject.tag == "Rubble")
        {
            Stan = true;
            float VibrationTime = (StanTime / 100f) + 0.3f;

            /*Execute(float secondsFromNow�F���݂̎�������A�N�V���������s����܂ł̎���0����ݒ��, float durationSeconds�F�ǂ̂��炢�U�����������i�b�P�ʁj, 
            �@float frequency�F�ǂ̂��炢�̕p�x�ŐU�����������邩�i0 - 320hz�j0�������߂炵��, float amplitude�F�U���̋����i0 - 1�j) �e���l�̂��Ƃ�f��floot�̐錾*/
            vibration.Execute(0, VibrationTime, 150f, 0.5f, SteamVR_Input_Sources.RightHand);

            //Debug.Log("�Ԃ������I");
            Debug.Log(other.name + "�ɂԂ������I");
        }
        else
        {

            //Debug.Log("�����ǂɂԂ������I");
        }

    }

}
