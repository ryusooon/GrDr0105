using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] Transform MyObj;

    [SerializeField] Rigidbody MyRig;

    Vector3 Up_Force;
    Vector3 Down_Force;

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

    [SerializeField] Transform Broom;
    Vector3 Broom_Left, Broom_Right;

    // Start is called before the first frame update

    void Start()
    {
        Up_Force = new Vector3(0f, MoveSpeed1, 0f);
        Down_Force = new Vector3(0f, -MoveSpeed1, 0f);

        Center_x = MyObj.transform.position.x;
        Center_y = MyObj.transform.position.y;
        Center_z = MyObj.transform.position.z;

        Broom_Left = Broom.transform.right;
        Broom_Right = -Broom.transform.right;
    }

    // Update is called once per frame
    void Update()
    {
        MyVec = DirectionObject.transform.up;

        Up_Force = new Vector3(0f, MoveSpeed1, 0f);
        Down_Force = new Vector3(0f, -MoveSpeed1, 0f);

        Broom_Left = Broom.transform.right;
        Broom_Right = -Broom.transform.right;
    }

    void FixedUpdate()
    {
        // ���݃G���A�̔���
        if ((MyVec.x >= -0.5 && MyVec.x <= 0.5) && (MyVec.z <= 1.0 && MyVec.z >= 0.5))
        {
            // �O�����Ă鎞
            Debug.Log("�����F�O");
        }
        else if ((MyVec.x >= -0.5 && MyVec.x <= 0.5) && (MyVec.z >= -1.0 && MyVec.z <= -0.5))
        {
            // �������Ă鎞
            Debug.Log("�����F���");
        }
        else if ((MyVec.x < -0.5 && MyVec.x >= -1.0) && (MyVec.z < 0.5 && MyVec.z > -0.5))
        {
            // �������Ă��鎞
            Debug.Log("�����F��");
        }
        else if ((MyVec.x > 0.5 && MyVec.x <= 1.0) && (MyVec.z < 0.5 && MyVec.z > -0.5))
        {
            // �E�����Ă��鎞
            Debug.Log("�����F�E");
        }
        else
        {
            if (MyVec.z < -0.5)
            {
                //Debug.Log("���ԃG���A(���)�̍��E�ړ�");
                Debug.Log("����:���Ԍ��");
            }
            else if (MyVec.z > -0.5)
            {
                //Debug.Log("���ԃG���A(�O��)�̍��E�ړ�");
                //Debug.Log("����:���ԑO");
            }
            else
            {
                //Debug.Log("���ԃG���A");
                //Debug.Log("���ԃG���A��X" + MyVec.x);
                //Debug.Log("���ԃG���A��Z" + MyVec.z);
            }
        }


        //�㉺�ړ�
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


        // ���E�ړ�
        if (Hit2.Left)
        {
            LEFT();  
        }
        else
        {
            MyRig.velocity = Vector3.zero;
        }

        if (Hit2.Right)
        {
            RIGHT();
        }
        else
        {
            MyRig.velocity = Vector3.zero;
        }

    }

    void UP()
    {
        MyRig.AddForce(Up_Force, ForceMode.Impulse);
        //Debug.Log("Up");
    }

    void DOWN()
    {
        MyRig.AddForce(Down_Force, ForceMode.Impulse);
        //Debug.Log("Down");
    }

    void LEFT()
    {

        // ���ړ�
        MyRig.AddForce(Broom_Left * MoveSpeed2, ForceMode.Impulse);
        //Debug.Log("Left");
    }

    void RIGHT()
    {
        // �E�ړ�
        MyRig.AddForce(Broom_Right * MoveSpeed2, ForceMode.Impulse);
        //Debug.Log("Right");

    }


}