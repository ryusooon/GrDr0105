using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventScript : MonoBehaviour
{
    [SerializeField] PlayerScript PlaySc;
    [SerializeField] BoxScaleScript BoxSc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StringParameter(string s)
    {
        // イベントから方角を取得
        Debug.Log("イベント発生：" + s);

        // LookDirection更新
        PlaySc.LookDirection = s;
    }

    public void ScaleChange_Y_Up(float y)
    {
        //Debug.Log("Y拡大");
        //BoxSc.PleaseChange = true;
        BoxSc.Y_Change = true;
        //BoxSc.ChangeFloat_Y = y;
    }

    public void ScaleChange_Y_Down(float y)
    {
        //Debug.Log("Y縮小");
        //BoxSc.PleaseChange = true;
        BoxSc.Y_Change = false;
        //BoxSc.ChangeFloat_Y = y;
    }

    public void ScaleChange_X_Up(float x)
    {
        //Debug.Log("X拡大");
        //BoxSc.PleaseChange = true;
        BoxSc.X_Change = true;
        //BoxSc.ChangeFloat_X = x;
    }

    public void ScaleChange_X_Down(float x)
    {
        //Debug.Log("X縮小");
        //BoxSc.PleaseChange = true;
        BoxSc.X_Change = false;
        //BoxSc.ChangeFloat_X = x;
    }

}
