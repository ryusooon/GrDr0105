using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScaleScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float ScaleChangeValue;
    public float ChangeFloat;
    Vector3 Change;
    Vector3 Y_Up_Force, Y_Down_Force, X_Up_Force, X_Down_Force;
    public bool Y_Change, X_Change;

    public int MaxValue;

    bool AAA = true;
    [SerializeField] GameObject Cubes;

    // 縦長状態 スケールY軸2.0f
    // 横長状態 スケールX軸2.0f

    // 通常状態 スケジュール(1.0f, 1.0f, 1.0f)

    void Start()
    {
        ScaleChangeValue = 0.1f;

        Y_Up_Force = new Vector3(0f, ScaleChangeValue, 0f);
        Y_Down_Force = new Vector3(0f, -ScaleChangeValue, 0f);

        X_Up_Force = new Vector3(ScaleChangeValue, 0f, 0f);
        X_Down_Force = new Vector3(-ScaleChangeValue, 0f, 0f);
    }

    void Update()
    {

        //if (this.transform.localScale.y < ChangeFloat && Y_Change)
        //{
        //    //Change = Cubes.transform.localScale;
        //    //Change.y = Change.y + ScaleChangeValue;
        //    //Cubes.gameObject.transform.localScale = Change;

        //    Cubes.gameObject.transform.localScale += Y_Up_Force;
        //    Debug.Log("Y_UP");
        //}
        //else if (this.transform.localScale.y > ChangeFloat && !Y_Change)
        //{
        //    //Change = Cubes.transform.localScale;
        //    //Change.y = Change.y - ScaleChangeValue;
        //    //Cubes.gameObject.transform.localScale = Change;

        //    Cubes.gameObject.transform.localScale += Y_Down_Force;
        //    Debug.Log("Y_DOWN");
        //}

        //if (this.transform.localScale.x < ChangeFloat && X_Change)
        //{
        //    //Change = Cubes.transform.localScale;
        //    //Change.y = Change.x + ScaleChangeValue;
        //    //Cubes.gameObject.transform.localScale = Change;

        //    Cubes.gameObject.transform.localScale += X_Up_Force;
        //    Debug.Log("X_UP");
        //}
        //else if (this.transform.localScale.x > ChangeFloat && !X_Change)
        //{
        //    //Change = Cubes.transform.localScale;
        //    //Change.x = Change.x - ScaleChangeValue;
        //    //Cubes.gameObject.transform.localScale = Change;

        //    Cubes.gameObject.transform.localScale += X_Down_Force;
        //    Debug.Log("X_DOWN");
        //}

        Debug.Log("Cubes:X" + Cubes.transform.localScale.x);
        Debug.Log("Cubes:Y" + Cubes.transform.localScale.y);
        Debug.Log("Cubes:Z" + Cubes.transform.localScale.z);
    }

     void FixedUpdate()
    {
        Change = new Vector3(0, 0.1f, 0);
        Cubes.gameObject.transform.localScale += Change;


        //if (AAA) 
        //{
        //    //if(Yがプラスの時)Change = new Vector3(0, 0.1f, 0);
        //    //if (Yがマイナスの時) Change = new Vector3(0, -0.1f, 0);

        //    for (int Max = 0; Max < 10; Max++)
        //    {
        //        Cubes.gameObject.transform.localScale += Change;
        //        if (Max <= 10) AAA = false;
        //    }
        //}

    }
}
