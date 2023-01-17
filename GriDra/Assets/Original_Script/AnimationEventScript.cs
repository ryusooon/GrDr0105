using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventScript : MonoBehaviour
{
    [SerializeField] PlayerScript PlaySc; 

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

}
