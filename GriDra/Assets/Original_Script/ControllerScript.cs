using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public struct Accel
{
    public float X;
    public float Y;
    public float Z;
}

public class ControllerScript : MonoBehaviour
{
    [SerializeField] public GameObject Controller;
    [SerializeField] VelocityEstimator VelEstim;
    [SerializeField] AccelerationScript Acceleration;
    [SerializeField] TrigerPullScript NowTriger;

    float funk;

    public int Time = 0, Charge = 0;

    public int Cut = 20;

    public float ShotPoint = 0.90f;

    Accel Get;

    public float InstancePoint = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        Get.X = VelEstim.GetAccelerationEstimate().x;
        Get.Y = VelEstim.GetAccelerationEstimate().y;
        Get.Z = VelEstim.GetAccelerationEstimate().z;
    }

    // Update is called once per frame
    void Update()
    {
        Get.X = VelEstim.GetAccelerationEstimate().x;
        Get.Y = VelEstim.GetAccelerationEstimate().y;
        Get.Z = VelEstim.GetAccelerationEstimate().z;

        // �R���g���[���[��Y�����̒l���擾
        funk = Controller.transform.forward.y;

        if (NowTriger.PullRight >= 1.0)
        {
            Charge += 1;
        }

        if (funk > ShotPoint)
        {
            // Y�����̒l��ShotPoint��荂��������
            Up();
        }
        else if(funk <= ShotPoint)
        {
            // Y�����̒l��ShotPoint���Ⴉ������
            Down();
        }

        //Debug.Log("forward:" + funk);
        // Debug.Log("GetAccelerationEstimateX:" + Get.X);
        // Debug.Log("GetAccelerationEstimateY:" + Get.Y);
        // Debug.Log("GetAccelerationEstimateZ:" + Get.Z);

        Debug.Log("Charge:" + Charge);
    }

    void Up()
    {
        // Time�̒l����
        Time += 1;
    }

    void Down()
    {

        //if (Get.X >= InstancePoint && Get.Y >= InstancePoint && Get.Z >= InstancePoint)
        //if (Get.Y >= InstancePoint)
        //{
        // �v���n�u�����p�̒l��PrehabCount�ɓn����Time���[���ɂ���B
        Acceleration.PrehabCount = Time / Cut;
        Acceleration.ChargeCount = Charge /20;
        Time = 0;
        Charge = 0;
        //}

    }


}
