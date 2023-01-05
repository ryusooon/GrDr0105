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
        // コライダーの再構築とメッシュの反転
        ReCreate();

        LimChScr.enabled = true;

        Debug.Log("OK!");
    }

    public void ReCreate()
    {
        // コライダーの再構築
        if (removeExistingColliders)
            RemoveColliders();

        // メッシュの反転
        MeshReverse();

        gameObject.AddComponent<MeshCollider>();
    }

    private void RemoveColliders()
    {
        // 既にコンポーネントされているコライダーのデータを格納
        Collider[] colliders = GetComponents<Collider>();

        // 既存の各コライダーデータを消す
        for (int i = 0; i < colliders.Length; i++)
            DestroyImmediate(colliders[i]);

        Debug.Log("Break");
    }

    private void MeshReverse()
    {   
        // メッシュフィルターを取得
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        // メッシュを反転
        mesh.triangles = mesh.triangles.Reverse().ToArray();

        Debug.Log("Reverse");
    }

}
