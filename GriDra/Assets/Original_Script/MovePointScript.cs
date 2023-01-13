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

        // BoxPosvec�ɃX�t�B�A�̌��݈ʒu���L�^������B
        BoxPosvec = To_Sphere.position;

        // ���Z�b�g������ON/OFF
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
            // �X�t�B�A�̈ʒu���g���Ċ�l�X�V
            if (StandardPos != To_Sphere.position)
            {
                StandardPos = To_Sphere.position;

                Rote = new Vector3(plane.transform.localEulerAngles.x, 0, 0);
                PointBox.transform.eulerAngles = Rote;
            }
        }

        // �Y���l�ƃ{�b�N�XY���l�̍������L�^
        Y_Difference = StandardPos.y - BoxPosvec.y;

        X_Difference = StandardPos.x - BoxPosvec.x;
        Z_Difference = StandardPos.z - BoxPosvec.z;

        // �������g����tmp���X�V������
        tmp = new Vector3(0, StandardPos.y - BoxPosvec.y, 0);
        //tmp = new Vector3(StandardPos.x - BoxPosvec.x, 0, StandardPos.z - BoxPosvec.z);

        // ���݂̈ʒu�ɉ��Z���Ĕ��f������
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
