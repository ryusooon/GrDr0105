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

    SoundManagerScript soundscript;

    public GameObject gamemanager;

    [SerializeField] public GameObject Controller;
    [SerializeField] VelocityEstimator VelEstim;
    [SerializeField] AccelerationScript Acceleration;
    [SerializeField] TrigerPullScript NowTriger;

    // Sphere�֘A
    //[SerializeField] Transform SphereModel;
    //SphereSize BlueSphere;
    //Vector3 SphereUp;
    //Vector3 SphereReset;
    //[SerializeField] Material Red, Green, Blue;
    //[SerializeField] MeshRenderer NowMaterial;

    [SerializeField] CollisionDetectionScript ColDetSc;
    [SerializeField] GameObject ThunderBall1, ThunderBall2, ThunderBall3;

    public int SpherePower;

    public int CutTime = 30;
    public float UpSpeed = 2f;

    public float ShotValue;

    float NowTime;

    GetAccel Get;

    [SerializeField] TouchPadScript TouPadSc;

    // Start is called before the first frame update
    void Start()
    {
        // ������Sphere�̃T�C�Y���L�^
        //BlueSphere.X = SphereModel.transform.localScale.x;
        //BlueSphere.Y = SphereModel.transform.localScale.y;
        //BlueSphere.Z = SphereModel.transform.localScale.z;

        //SphereUp = new Vector3(UpSpeed, UpSpeed, UpSpeed);
        //SphereReset = new Vector3(BlueSphere.X, BlueSphere.Y, BlueSphere.Z);

        soundscript = gamemanager.GetComponent<SoundManagerScript>();

        //NowMaterial.material = Blue;

        // �T���_�[��1�ȊO��\����
        ThunderBall1.SetActive(true);
        ThunderBall2.SetActive(false);
        ThunderBall3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // �X�^����Ԃ���Ȃ��ꍇ ���|�[�Y������Ȃ�
        if (!ColDetSc.Stan && TouPadSc.game)
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
                    //soundscript.PlayerSound(1);
                    // ����InstantiatePrehabScript��

                }

                // �m�F�p
                Debug.Log("�g���K�[���͒�");
                Debug.Log("�擾�����x��X:" + Get.X + " Y:" + Get.Y + " Z:" + Get.Z);
            }


            // 10�b�Ԓe���c���
            if (NowTime < 5)
            {
                PowerCharge();
                PowerCheck();
            }

            NowTime += Time.deltaTime;
            //Debug.Log("NowTime(�o�ߎ���):" + NowTime + " SpherePower(�e�̃T�C�Y):" + SpherePower);

            //Debug.Log("�X�t�B�A�F" + SpherePower / 20);

        }

    }

    // �`���[�W�̏���
    void PowerCharge()
    {
        // �e�̈З͂𑝂₷
        SpherePower += 1;

        // ���f���̒e��傫������
        //SphereModel.transform.localScale += SphereUp;
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
        //SphereModel.transform.localScale = SphereReset;

        // �o�ߎ��ԃ[��
        NowTime = 0;

        // �}�e���A���̃��Z�b�g
        //NowMaterial.material = Blue;

        // �T���_�[�\���̃��Z�b�g
        ThunderBall1.SetActive(true);
        ThunderBall2.SetActive(false);
        ThunderBall3.SetActive(false);

    }
    void GetAE()
    {
        // �R���g���[���[�̉����x���擾
        Get.X = VelEstim.GetAccelerationEstimate().x;
        Get.Y = VelEstim.GetAccelerationEstimate().y;
        Get.Z = VelEstim.GetAccelerationEstimate().z;
    }

    void PowerCheck()
    {
        // �p���[�̐��l�ɍ��킹�ă}�e���A����ύX����֐�
        
        if (SpherePower / 20 < 8)
        {
            // �p���[��300�����̏ꍇ

            //if (NowMaterial != Blue)
            //{
            //    // �p���[��300�����̏�ԂŃ}�e���A����Blue����Ȃ��ꍇ
            //    NowMaterial.material = Blue;
            //}

            if (!ThunderBall1.activeSelf)
            {
                // �p���[��300�����̏�ԂŃT���_�[1���\������ĂȂ��ꍇ
                ThunderBall1.SetActive(true);
            }
            else 
            {
                // �����\���ɂ���
                ThunderBall2.SetActive(false);
                ThunderBall3.SetActive(false);
            }

        }
        else if (SpherePower / 20 >= 8 && SpherePower / 20 < 14)
        {
            // �p���[��300�ȏ�600�����̏ꍇ

            //if (NowMaterial != Green)
            //{
            //    // �p���[��300�ȏ�600�����̏�ԂŃ}�e���A����Green����Ȃ��ꍇ
            //    NowMaterial.material = Green;
            //}

            if (!ThunderBall2.activeSelf)
            {
                // �p���[��300�ȏ�600�����̏�ԂŃT���_�[2���\������ĂȂ��ꍇ
                ThunderBall2.SetActive(true);
            }
            else
            {
                // �����\���ɂ���
                ThunderBall1.SetActive(false);
                ThunderBall3.SetActive(false);
            }

        }
        else if (SpherePower / 20 >= 14)
        {
            // �p���[��600�ȏ�̏ꍇ

            //if (NowMaterial != Red)
            //{
            //    // �p���[��600�ȏ�̏�ԂŃ}�e���A����Red����Ȃ��ꍇ
            //    NowMaterial.material = Red;
            //}

            if (!ThunderBall2.activeSelf)
            {
                // �p���[��600�ȏ�̏�ԂŃT���_�[3���\������ĂȂ��ꍇ
                ThunderBall3.SetActive(true);
            }
            else
            {
                // �����\���ɂ���
                ThunderBall1.SetActive(false);
                ThunderBall2.SetActive(false);
            }

        }

    }

}
