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
        // �C�x���g������p���擾
        Debug.Log("�C�x���g�����F" + s);

        // LookDirection�X�V
        PlaySc.LookDirection = s;
    }

}
