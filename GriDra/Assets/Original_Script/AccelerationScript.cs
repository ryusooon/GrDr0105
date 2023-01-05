using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR.InteractionSystem;

public class AccelerationScript : MonoBehaviour
{
    // �R���g���[���[�̉����x���l���擾���邽�߂̕ϐ�
    [SerializeField] public VelocityEstimator ControllerVE;

    float NowVE_X = 0.0f;
    float NowVE_Y = 0.0f;
    float NowVE_Z = 0.0f;

    GameObject TestPrehab;
    public int PrehabCount = 0;
    public int PosCount = 0;
    public int ChargeCount = 0;

    public float AccelerationValue = 100.0f;

    //[SerializeField] InstantiatePrehabScript[] PrehabBool = new InstantiatePrehabScript[5];
    [SerializeField] InstantiatePrehabScript PrehabBool;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        NowVE_X = ControllerVE.GetAccelerationEstimate().x;
        NowVE_Y = ControllerVE.GetAccelerationEstimate().y;
        NowVE_Z = ControllerVE.GetAccelerationEstimate().z;

        // PrehabCount��0�ȏ�̎�
        if (PrehabCount > 0)
        {

            PrehabBool.PrehabOn = true;

            // �v���n�u�������̏���
            if (ChargeCount > 3)
            {
                PrehabBool.ChargeUp = true;
                PrehabBool.ScaleCount = ChargeCount;
                Debug.Log("ChargeCount:" + ChargeCount);
            }

            PrehabCount = 0;
            ChargeCount = 0;
        }

    }
}
