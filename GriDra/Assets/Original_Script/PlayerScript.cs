using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] Transform MyObj;

    [SerializeField] Rigidbody MyRig;

    Vector3 Up_Force;
    Vector3 Down_Force;

    //前後を向いている場合に使うVec
    Vector3 Left_Force_X;
    Vector3 Right_Force_X;

    //前後を向いている場合に使うVec
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

    //public float ForcePower = 0.25f;
    //public float MaxVal = 1.5f;

    // Start is called before the first frame update

    void Start()
    {
        Up_Force = new Vector3(0f, MoveSpeed1, 0f);
        Down_Force = new Vector3(0f, -MoveSpeed1, 0f);

        Left_Force_X = new Vector3(-MoveSpeed2, 0f, 0f);
        Right_Force_X = new Vector3(MoveSpeed2, 0f, 0f);

        Left_Force_Z = new Vector3(0f, 0f, -MoveSpeed2);
        Right_Force_Z = new Vector3(0f, 0f, MoveSpeed2);

        Center_x = MyObj.transform.position.x;
        Center_y = MyObj.transform.position.y;
        Center_z = MyObj.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        MyVec = DirectionObject.transform.up;
        //Debug.Log("MyVec:" + MyVec);

        Up_Force = new Vector3(0f, MoveSpeed1, 0f);
        Down_Force = new Vector3(0f, -MoveSpeed1, 0f);

        Left_Force_X = new Vector3(-MoveSpeed2, 0f, 0f);
        Right_Force_X = new Vector3(MoveSpeed2, 0f, 0f);

        Left_Force_Z = new Vector3(0f, 0f, -MoveSpeed2);
        Right_Force_Z = new Vector3(0f, 0f, MoveSpeed2);
    }

    void FixedUpdate()
    {

        //上下移
        if(Hit.Up)
        {
            Up();
        }
        else
        {
            MyRig.velocity = Vector3.zero;
        }

        if (Hit.Down)
        {
            Down();
        }
        else
        {
            MyRig.velocity = Vector3.zero;
        }


        //左右移動
        if (Hit2.Right)
        {

            Right();
        }
        else
        {
            MyRig.velocity = Vector3.zero;
        }

        if (Hit2.Left)
        {
            Left();
        }
        else
        {
            MyRig.velocity = Vector3.zero;
        }


    }

    void Up()
    {
        MyRig.AddForce(Up_Force, ForceMode.Impulse);
        //Debug.Log("Up");
    }

    void Down()
    {
        MyRig.AddForce(Down_Force, ForceMode.Impulse);
       // Debug.Log("Down");
    }

    void Left()
    {

        // 左移動
        if ((MyVec.x >= -0.5 && MyVec.x <= 0.5) && (MyVec.z <= 1.0 && MyVec.z >= 0.5))
        {
            // 前向いてる時の左移動
            MyRig.AddForce(Left_Force_X, ForceMode.Impulse);
        }
        else if ((MyVec.x >= -0.5 && MyVec.x <= 0.5) && (MyVec.z >= -1.0 && MyVec.z <= -0.5))
        {
            // 後ろ向いてる時の左移動
            MyRig.AddForce(Right_Force_X, ForceMode.Impulse);
        }
        else if ((MyVec.x <= -0.5 && MyVec.x >= -1.0) && (MyVec.z <= 0.5 && MyVec.z >= -0.5))
        {
            //左向いている時の左移動
            MyRig.AddForce(Left_Force_Z, ForceMode.Impulse);
        }
        else if ((MyVec.x >= 0.5 && MyVec.x <= 1.0) && (MyVec.z <= 0.5 && MyVec.z >= -0.5))
        {
            // 右向いている時の右移動
            MyRig.AddForce(Right_Force_Z, ForceMode.Impulse);
        }

        //MyRig.AddForce(Left_Force_X, ForceMode.Impulse);
        //Debug.Log("Left");

    }

    void Right()
    {

        // 右移動
        if ((MyVec.x >= -0.5 && MyVec.x <= 0.5) && (MyVec.z <= 1.0 && MyVec.z >= 0.5))
        {
            // 前向いてる時の右移動
            MyRig.AddForce(Right_Force_X, ForceMode.Impulse);
        }
        else if ((MyVec.x >= -0.5 && MyVec.x <= 0.5) && (MyVec.z >= -1.0 && MyVec.z <= -0.5))
        {
            // 後ろ向いてる時の右移動
            MyRig.AddForce(Left_Force_X, ForceMode.Impulse);
        }
        else if ((MyVec.x <= -0.5 && MyVec.x >= -1.0) && (MyVec.z <= 0.5 && MyVec.z >= -0.5))
        {
            // 左向いている時の右移動
            MyRig.AddForce(Right_Force_Z, ForceMode.Impulse);
        }
        else if ((MyVec.x >= 0.5 && MyVec.x <= 1.0) && (MyVec.z <= 0.5 && MyVec.z >= -0.5))
        {
            // 右向いている時の右移動
            MyRig.AddForce(Left_Force_Z, ForceMode.Impulse);
        }

        //MyRig.AddForce(Right_Force_X, ForceMode.Impulse);
        Debug.Log("Right");

    }

}