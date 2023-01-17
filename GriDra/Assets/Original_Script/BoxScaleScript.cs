using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScaleScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float ScaleChangeValue;
    public float ChangeFloat;
    Vector3 X_Up, X_Down, Y_Up, Y_Down;

    // �c����� �X�P�[��Y��2.0f
    // ������� �X�P�[��X��2.0f

    // �ʏ��� �X�P�W���[��(1.0f, 1.0f, 1.0f)

    void Start()
    {
        ScaleChangeValue = 0.0f;

        X_Up = new Vector3(ScaleChangeValue, 0f, 0f);
        X_Down = new Vector3(-ScaleChangeValue, 0f, 0f);

        Y_Up = new Vector3(0f, ScaleChangeValue, 0f);
        Y_Down = new Vector3(0f, -ScaleChangeValue, 0f);
    }

    void Update()
    {

        if (this.transform.localScale.y < ChangeFloat)
        {
            this.transform.localScale += Y_Up;
        }
        else if (this.transform.localScale.y > ChangeFloat)
        {
            this.transform.localScale += Y_Down;
        }

        if (this.transform.localScale.x < ChangeFloat)
        {
            this.transform.localScale += X_Up;
        }
        else if (this.transform.localScale.x > ChangeFloat)
        {
            this.transform.localScale += X_Down;
        }

    }
}
