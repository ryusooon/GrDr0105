using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonGravityScript : MonoBehaviour
{
    // ���͂̔�������Ώ�(����̓h���S��)
    public GameObject Dragon;

    // �����x�̑傫��
    public float AccelScale;

    // �����x��^���邽�߂Ɏg��
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
        // �h���S���Ɍ����������̎擾
        Vector3 Direction = Dragon.transform.position - this.transform.position;
        //Direction.Normalize();

        // �����x��^����
        ThisRig.AddForce((AccelScale / 0.3f) * Direction, ForceMode.Impulse);

    }

}

