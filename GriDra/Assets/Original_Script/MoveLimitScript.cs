using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoveLimitScript : MonoBehaviour
{
    public bool removeExistingColliders = true;

    [SerializeField] LimitCheckScript LimChScr;

    private void Start()
    {
        // �R���C�_�[�̍č\�z�ƃ��b�V���̔��]
        ReCreate();

        LimChScr.enabled = true;

        Debug.Log("OK!");
    }

    public void ReCreate()
    {
        // �R���C�_�[�̍č\�z
        if (removeExistingColliders)
            RemoveColliders();

        // ���b�V���̔��]
        MeshReverse();

        gameObject.AddComponent<MeshCollider>();
    }

    private void RemoveColliders()
    {
        // ���ɃR���|�[�l���g����Ă���R���C�_�[�̃f�[�^���i�[
        Collider[] colliders = GetComponents<Collider>();

        // �����̊e�R���C�_�[�f�[�^������
        for (int i = 0; i < colliders.Length; i++)
            DestroyImmediate(colliders[i]);

        Debug.Log("Break");
    }

    private void MeshReverse()
    {   
        // ���b�V���t�B���^�[���擾
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        // ���b�V���𔽓]
        mesh.triangles = mesh.triangles.Reverse().ToArray();

        Debug.Log("Reverse");
    }

}
