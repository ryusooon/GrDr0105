using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public struct GetAccel
{
    public float X;
    public float Y;
    public float Z;
}

struct SphereSize
{
    public float X;
    public float Y;
    public float Z;
}

public class TestControllerScript : MonoBehaviour
{

    [SerializeField] public GameObject Controller;
    [SerializeField] VelocityEstimator VelEstim;
    [SerializeField] AccelerationScript Acceleration;
    [SerializeField] TrigerPullScript NowTriger;

    // Sphere�֘A
    [SerializeField] Transform SphereModel;
    SphereSize BlueSphere;
    Vector3 SphereUp;
    Vector3 SphereReset;

    public int SpherePower;

    public int CutTime = 30;
    public float UpSpeed = 2f;

    public float ShotValue;

    float NowTime;

    GetAccel Get;

    // Start is called before the first frame update
    void Start()
    {
        // ������Sphere�̃T�C�Y���L�^
        BlueSphere.X = SphereModel.transform.localScale.x;
        BlueSphere.Y = SphereModel.transform.localScale.y;
        BlueSphere.Z = SphereModel.transform.localScale.z;

        SphereUp = new Vector3(UpSpeed, UpSpeed, UpSpeed);
        SphereReset = new Vector3(BlueSphere.X, BlueSphere.Y, BlueSphere.Z);
    }

    // Update is called once per frame
    void Update()
    {
        // �g���K�[���͒��̏���
        if (NowTriger.PullRight == 1)
        {
            // �����x�擾
            GetAE();

            // �g���K�[���͒��ɃR���g���[���[��U�艺�낵����
            if (Get.X > ShotValue && Get.Y > ShotValue && SpherePower > 0)
            {
                Debug.Log("NowTime(�o�ߎ���):" + NowTime + " SpherePower(�e�̃T�C�Y):" + SpherePower);

                // �e�̐���
                SphereMove();
            }

            // �m�F�p
            Debug.Log("�g���K�[���͒�");
            Debug.Log("�擾�����x��X:" + Get.X + " Y:" + Get.Y + " Z:" + Get.Z);
        }


        // 10�b�Ԓe���c���
        if (NowTime < 10)
        {
            PowerCharge();
        }

        NowTime += Time.deltaTime;
        //Debug.Log("NowTime(�o�ߎ���):" + NowTime + " SpherePower(�e�̃T�C�Y):" + SpherePower);

    }

    // �`���[�W�̏���
    void PowerCharge()
    {
        // �e�̈З͂𑝂₷
        SpherePower += 1;

        // ���f���̒e��傫������
        SphereModel.transform.localScale += SphereUp;
    }

    // �e�̐�������є��ˏ���
    void SphereMove()
    {
        // ���˂�����e�͈ꔭ
        //Acceleration.PrehabCount = 1;

        // ��������e�̃T�C�Y���`���[�W���ɂ��Ėc��܂���
        //Acceleration.ChargeCount = SpherePower / 80;


        Acceleration.PrehabCount = SpherePower / CutTime;
        Acceleration.ChargeCount = SpherePower / 20;

        // ���Z�b�g
        ReSet();

    }

    // ���Z�b�g�̏���
    void ReSet()
    {
        // �З͂̐��l���[���ɂ���
        SpherePower = 0;

        // �e�̃T�C�Y��������ԂɃ��Z�b�g
        SphereModel.transform.localScale = SphereReset;

        // �o�ߎ��ԃ[��
        NowTime = 0;

    }

    void GetAE()
    {
        // �R���g���[���[�̉����x���擾
        Get.X = VelEstim.GetAccelerationEstimate().x;
        Get.Y = VelEstim.GetAccelerationEstimate().y;
        Get.Z = VelEstim.GetAccelerationEstimate().z;
    }

}
