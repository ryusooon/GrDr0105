using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MovePointScript : MonoBehaviour
{

    [SerializeField] Transform To_Sphere;
    [SerializeField] Transform PointBox;

    public GameObject BoxPos;
    public Vector3 BoxPosvec;
    public Vector3 tmp;

    public bool ReSet;
    public Vector3 StandardPos;

    public float Y_Difference;

    public float X_Difference;
    public float Z_Difference;

    public Transform plane;
    public Vector3 Rote;

    // Start is called before the first frame update
    void Start()
    {
        PointBox.transform.position = To_Sphere.transform.position;
        ReSet = false;

        StandardPos = To_Sphere.position;
        Y_Difference = StandardPos.y - BoxPosvec.y;

        X_Difference = StandardPos.x - BoxPosvec.x;
        Z_Difference = StandardPos.z - BoxPosvec.z;
    }

    // Update is called once per frame
    void Update()
    {

        // BoxPosvecにスフィアの現在位置を記録させる。
        BoxPosvec = To_Sphere.position;

        // リセット処理のON/OFF
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReSet = !ReSet;
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            ReSet = !ReSet;
        }

        if (ReSet)
        {
            // スフィアの位置を使って基準値更新
            if (StandardPos != To_Sphere.position)
            {
                StandardPos = To_Sphere.position;

                Rote = new Vector3(plane.transform.localEulerAngles.x, 0, 0);
                PointBox.transform.eulerAngles = Rote;
            }
        }

        // 基準Y軸値とボックスY軸値の差分を記録
        Y_Difference = StandardPos.y - BoxPosvec.y;

        X_Difference = StandardPos.x - BoxPosvec.x;
        Z_Difference = StandardPos.z - BoxPosvec.z;

        // 差分を使ってtmpを更新させる
        tmp = new Vector3(0, StandardPos.y - BoxPosvec.y, 0);
        //tmp = new Vector3(StandardPos.x - BoxPosvec.x, 0, StandardPos.z - BoxPosvec.z);

        // 現在の位置に加算して反映させる
        PointBox.position = BoxPosvec + tmp;

    }

    void Reset()
    {
        Vector3 SphereTransformPoint = transform.TransformPoint(StandardPos = To_Sphere.position);

        for (; ;)
        {

            if (BoxPosvec != SphereTransformPoint)
            {
                BoxPosvec = SphereTransformPoint;
            }
            else
            {
                break;
            }

        }

    }

}
