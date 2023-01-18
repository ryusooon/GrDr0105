using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] Transform MyObj;

    [SerializeField] Rigidbody MyRig;

    Vector3 Up_Force;
    Vector3 Down_Force;

    //�O��������Ă���ꍇ�Ɏg��Vec
    Vector3 Left_Force_X;
    Vector3 Right_Force_X;

    //�O��������Ă���ꍇ�Ɏg��Vec
    Vector3 Left_Force_Z;
    Vector3 Right_Force_Z;

    private float Center_x;
    private float Center_y;
    private float Center_z;

    [SerializeField] AngleScript Angle;

    [SerializeField] Transform DirectionObject;

    Vector3 MyVec;

    [SerializeField] HitScript Hit;
    [SerializeField] HitScript2 Hit2;

    public float MoveSpeed1;
    public float MoveSpeed2;

    public string LookDirection;

    //public float ForcePower = 0.25f;
    //public float MaxVal = 1.5f;

    // Start is called before the first frame update

    void Start()
    {
        Up_Force = new Vector3(0f, MoveSpeed1, 0f);
        Down_Force = new Vector3(0f, -MoveSpeed1, 0f);

        Left_Force_X = new Vector3(-MoveSpeed2, 0f, -MoveSpeed2);
        Right_Force_X = new Vector3(MoveSpeed2, 0f, MoveSpeed2);

        Left_Force_Z = new Vector3(MoveSpeed2, 0f, -MoveSpeed2);
        Right_Force_Z = new Vector3(-MoveSpeed2, 0f, MoveSpeed2);

        Center_x = MyObj.transform.position.x;
        Center_y = MyObj.transform.position.y;
        Center_z = MyObj.transform.position.z;

        LookDirection = "North";
    }

    // Update is called once per frame
    void Update()
    {
        MyVec = DirectionObject.transform.up;
        //Debug.Log("MyVec:" + MyVec);

        ForceCheck();

        Debug.Log("MyVecX:" + MyVec.x);
        Debug.Log("MyVecY:" + MyVec.y);
        Debug.Log("MyVecZ:" + MyVec.z);

        Up_Force = new Vector3(0f, MoveSpeed1, 0f);
        Down_Force = new Vector3(0f, -MoveSpeed1, 0f);

        //Left_Force_X = new Vector3(-MoveSpeed2, 0f, -MoveSpeed2);
        //Right_Force_X = new Vector3(MoveSpeed2, 0f, MoveSpeed2);

        //Left_Force_Z = new Vector3(MoveSpeed2, 0f, -MoveSpeed2);
        //Right_Force_Z = new Vector3(-MoveSpeed2, 0f, MoveSpeed2);
    }

    void FixedUpdate()
    {
        // ���݃G���A�̔���
        //if ((MyVec.x >= -0.5 && MyVec.x <= 0.5) && (MyVec.z <= 1.0 && MyVec.z >= 0.5))
        if ((MyVec.x >= -0.5 && MyVec.x <= 0.5) && (MyVec.z <= 1.0 && MyVec.z >= 0.5))
        {
            // �O�����Ă鎞
            Debug.Log("�����F�O");
            FORWARD();
        }
        else if ((MyVec.x >= -0.5 && MyVec.x <= 0.5) && (MyVec.z >= -1.0 && MyVec.z <= -0.5))
        {
            // �������Ă鎞
            Debug.Log("�����F���");
            BACK();
        }
        else if ((MyVec.x < -0.5 && MyVec.x >= -1.0) && (MyVec.z < 0.5 && MyVec.z > -0.5))
        {
            // �������Ă��鎞
            Debug.Log("�����F��");
            LEFT();
        }
        else if ((MyVec.x > 0.5 && MyVec.x <= 1.0) && (MyVec.z < 0.5 && MyVec.z > -0.5))
        {
            // �E�����Ă��鎞
            Debug.Log("�����F�E");
            RIGHT();
        }
        else
        {
            if (MyVec.z < -0.5)
            {
                //Debug.Log("���ԃG���A(���)�̍��E�ړ�");
                Debug.Log("����:���Ԍ��");
                BACK();
            }
            else if (MyVec.z > -0.5)
            {
                //Debug.Log("���ԃG���A(�O��)�̍��E�ړ�");
                Debug.Log("����:���ԑO");
                FORWARD();
            }
            else
            {
                //Debug.Log("���ԃG���A");
                //Debug.Log("���ԃG���A��X" + MyVec.x);
                //Debug.Log("���ԃG���A��Z" + MyVec.z);
            }
        }


        //�㉺��
        if (Hit.Up)
        {
            UP();
        }
        else
        {
            MyRig.velocity = Vector3.zero;
        }

        if (Hit.Down)
        {
            DOWN();
        }
        else
        {
            MyRig.velocity = Vector3.zero;
        }

    }

    void UP()
    {
        MyRig.AddForce(Up_Force, ForceMode.Impulse);
        Debug.Log("Up");
    }

    void DOWN()
    {
        MyRig.AddForce(Down_Force, ForceMode.Impulse);
        Debug.Log("Down");
    }

    void FORWARD()
    {

        // �O�����Ă��鎞�̍��E�ړ�

        if (Hit2.Left)
        {
            // �O�����Ă鎞�̍��ړ�
            MyRig.AddForce(Left_Force_X, ForceMode.Impulse);
            Debug.Log("F��L");
        }
        else
        {
            MyRig.velocity = Vector3.zero;
        }

        if (Hit2.Right)
        {
            // �O�����Ă鎞�̉E�ړ�
            MyRig.AddForce(Right_Force_X, ForceMode.Impulse);
            Debug.Log("F��R");
        }
        else
        {
            MyRig.velocity = Vector3.zero;
        }

    }

    void BACK()
    {

        // �������Ă��鎞�̍��E�ړ�

        if (Hit2.Left)
        {
            // �������Ă鎞�̍��ړ�
            MyRig.AddForce(Right_Force_X, ForceMode.Impulse);
            Debug.Log("B��L");
        }
        else
        {
            MyRig.velocity = Vector3.zero;
        }

        if (Hit2.Right)
        {
            // �������Ă鎞�̉E�ړ�
            MyRig.AddForce(Left_Force_X, ForceMode.Impulse);
            Debug.Log("B��R");
        }
        else
        {
            MyRig.velocity = Vector3.zero;
        }

    }

    void LEFT()
    {

        // �������Ă��鎞�̍��E�ړ�

        if (Hit2.Left)
        {
            //�������Ă��鎞�̍��ړ�
            MyRig.AddForce(Left_Force_Z, ForceMode.Impulse);
            Debug.Log("L��L");
        }
        else
        {
            MyRig.velocity = Vector3.zero;
        }


        if (Hit2.Right)
        {
            // �������Ă��鎞�̉E�ړ�
            MyRig.AddForce(Right_Force_Z, ForceMode.Impulse);
            Debug.Log("L��R");
        }
        else
        {
            MyRig.velocity = Vector3.zero;
        }

        //MyRig.AddForce(Left_Force_X, ForceMode.Impulse);
        Debug.Log("Left");

    }

    void RIGHT()
    {
        // �E�����Ă��鎞�̍��E�ړ�

        if (Hit2.Left)
        {
            // �E�����Ă��鎞�̍��ړ�
            MyRig.AddForce(Right_Force_Z, ForceMode.Impulse);
            Debug.Log("R��L");
        }
        else
        {
            MyRig.velocity = Vector3.zero;
        }


        if (Hit2.Right)
        {
            // �E�����Ă��鎞�̉E�ړ�
            MyRig.AddForce(Left_Force_Z, ForceMode.Impulse);
            Debug.Log("R��R");
        }
        else
        {
            MyRig.velocity = Vector3.zero;
        }

        //MyRig.AddForce(Right_Force_X, ForceMode.Impulse);
        Debug.Log("Right");

    }

    void ForceCheck()
    {
        // LookDirection�����Ɍ����Ă�����p�ƁA���p�ɍ��킹�Ċ|����ׂ��͂̃p�^�[���𔻕�

        if (LookDirection == "North")
        {
            Left_Force_X = new Vector3(-MoveSpeed2, 0f, -MoveSpeed2);
            Right_Force_X = new Vector3(MoveSpeed2, 0f, MoveSpeed2);

            Left_Force_Z = new Vector3(MoveSpeed2, 0f, -MoveSpeed2);
            Right_Force_Z = new Vector3(-MoveSpeed2, 0f, MoveSpeed2);
        }
        else if (LookDirection == "West")
        {
            Left_Force_X = new Vector3(MoveSpeed2, 0f, MoveSpeed2);
            Right_Force_X = new Vector3(-MoveSpeed2, 0f, -MoveSpeed2);

            Left_Force_Z = new Vector3(0f, 0f, MoveSpeed2);
            Right_Force_Z = new Vector3(0f, 0f, -MoveSpeed2);
        }
        else if (LookDirection == "South")
        {
            Left_Force_X = new Vector3(MoveSpeed2, 0f, 0f);
            Right_Force_X = new Vector3(-MoveSpeed2, 0f, 0f);

            Left_Force_Z = new Vector3(0f, 0f, MoveSpeed2);
            Right_Force_Z = new Vector3(0f, 0f, -MoveSpeed2);
        }
        else if (LookDirection == "East")
        {
            Left_Force_X = new Vector3(0f, 0f, MoveSpeed2);
            Right_Force_X = new Vector3(0f, 0f, -MoveSpeed2);

            Left_Force_Z = new Vector3(-MoveSpeed2, 0f, 0f);
            Right_Force_Z = new Vector3(MoveSpeed2, 0f, 0f);
        }

    }


}