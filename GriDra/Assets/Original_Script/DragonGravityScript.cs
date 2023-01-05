using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonGravityScript : MonoBehaviour
{
    // 引力の発生する対象(今回はドラゴン)
    public GameObject Dragon;

    // 加速度の大きさ
    public float AccelScale;

    // 加速度を与えるために使う
    Rigidbody ThisRig;

    void Start()
    {
        Dragon = GameObject.Find("DrRootAnimObj");
        ThisRig = this.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Destroy(this.gameObject, 3.0f);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        // ドラゴンに向かう向きの取得
        Vector3 Direction = Dragon.transform.position - this.transform.position;
        //Direction.Normalize();

        // 加速度を与える
        ThisRig.AddForce((AccelScale / 0.3f) * Direction, ForceMode.Impulse);

    }

}

