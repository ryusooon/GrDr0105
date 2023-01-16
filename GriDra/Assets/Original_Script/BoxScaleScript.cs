using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScaleScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float ScaleChangeValue;
    Vector3 X_Up, X_Down, Y_Up, Y_Down;

    // 縦長状態 スケールY軸2.0f
    // 横長状態 スケールX軸2.0f

    // 通常状態 スケジュール(1.0f, 1.0f, 1.0f)

    void Start()
    {
        ScaleChangeValue = 0.1f;

        X_Up = new Vector3(ScaleChangeValue, 0f, 0f);
        X_Down = new Vector3(-ScaleChangeValue, 0f, 0f);

        Y_Up = new Vector3(0f, ScaleChangeValue, 0f);
        Y_Down = new Vector3(0f, -ScaleChangeValue, 0f);
    }

    void ScaleChange_Y_Up()
    {
        if (this.transform.localScale.y < 2.0f)
        {
            this.transform.localScale += Y_Up;
        }
    }

    void ScaleChange_Y_Down()
    {
        if (this.transform.localScale.y > 1.0f)
        {
            this.transform.localScale += Y_Down;
        }
    }

    void ScaleChange_X_Up()
    {
        if (this.transform.localScale.x < 2.0f)
        {
            this.transform.localScale += X_Up;
        }
    }

    void ScaleChange_X_Down()
    {
        if (this.transform.localScale.x > 1.0f)
        {
            this.transform.localScale += X_Down;
        }
    }
}
