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
        // 現在エリアの判別
        //if ((MyVec.x >= -0.5 && MyVec.x <= 0.5) && (MyVec.z <= 1.0 && MyVec.z >= 0.5))
        if ((MyVec.x >= -0.5 && MyVec.x <= 0.5) && (MyVec.z <= 1.0 && MyVec.z >= 0.5))
        {
            // 前向いてる時
            Debug.Log("方向：前");
            FORWARD();
        }
        else if ((MyVec.x >= -0.5 && MyVec.x <= 0.5) && (MyVec.z >= -1.0 && MyVec.z <= -0.5))
        {
            // 後ろ向いてる時
            Debug.Log("方向：後ろ");
            BACK();
        }
        else if ((MyVec.x < -0.5 && MyVec.x >= -1.0) && (MyVec.z < 0.5 && MyVec.z > -0.5))
        {
            // 左向いている時
            Debug.Log("方向：左");
            LEFT();
        }
        else if ((MyVec.x > 0.5 && MyVec.x <= 1.0) && (MyVec.z < 0.5 && MyVec.z > -0.5))
        {
            // 右向いている時
            Debug.Log("方向：右");
            RIGHT();
        }
        else
        {
            if (MyVec.z < -0.5)
            {
                //Debug.Log("隙間エリア(後方)の左右移動");
                Debug.Log("方向:隙間後ろ");
                BACK();
            }
            else if (MyVec.z > -0.5)
            {
                //Debug.Log("隙間エリア(前方)の左右移動");
                Debug.Log("方向:隙間前");
                FORWARD();
            }
            else
            {
                //Debug.Log("隙間エリア");
                //Debug.Log("隙間エリアのX" + MyVec.x);
                //Debug.Log("隙間エリアのZ" + MyVec.z);
            }
        }


        //上下移
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

        // 前向いている時の左右移動

        if (Hit2.Left)
        {
            // 前向いてる時の左移動
            MyRig.AddForce(Left_Force_X, ForceMode.Impulse);
            Debug.Log("FのL");
        }
        else
        {
            MyRig.velocity = Vector3.zero;
        }

        if (Hit2.Right)
        {
            // 前向いてる時の右移動
            MyRig.AddForce(Right_Force_X, ForceMode.Impulse);
            Debug.Log("FのR");
        }
        else
        {
            MyRig.velocity = Vector3.zero;
        }

    }

    void BACK()
    {

        // 後ろ向いている時の左右移動

        if (Hit2.Left)
        {
            // 後ろ向いてる時の左移動
            MyRig.AddForce(Right_Force_X, ForceMode.Impulse);
            Debug.Log("BのL");
        }
        else
        {
            MyRig.velocity = Vector3.zero;
        }

        if (Hit2.Right)
        {
            // 後ろ向いてる時の右移動
            MyRig.AddForce(Left_Force_X, ForceMode.Impulse);
            Debug.Log("BのR");
        }
        else
        {
            MyRig.velocity = Vector3.zero;
        }

    }

    void LEFT()
    {

        // 左向いている時の左右移動

        if (Hit2.Left)
        {
            //左向いている時の左移動
            MyRig.AddForce(Left_Force_Z, ForceMode.Impulse);
            Debug.Log("LのL");
        }
        else
        {
            MyRig.velocity = Vector3.zero;
        }


        if (Hit2.Right)
        {
            // 左向いている時の右移動
            MyRig.AddForce(Right_Force_Z, ForceMode.Impulse);
            Debug.Log("LのR");
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
        // 右向いている時の左右移動

        if (Hit2.Left)
        {
            // 右向いている時の左移動
            MyRig.AddForce(Right_Force_Z, ForceMode.Impulse);
            Debug.Log("RのL");
        }
        else
        {
            MyRig.velocity = Vector3.zero;
        }


        if (Hit2.Right)
        {
            // 右向いている時の右移動
            MyRig.AddForce(Left_Force_Z, ForceMode.Impulse);
            Debug.Log("RのR");
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
        // LookDirectionを元に向いている方角と、方角に合わせて掛けるべき力のパターンを判別

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