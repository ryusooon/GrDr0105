using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TouchPadScript : MonoBehaviour
{
    //private SteamVR_Action_Vector2 TrackPad = SteamVR_Actions.default_TrackPad;

    [SerializeField] SteamVR_Input_Sources hand;
    [SerializeField] SteamVR_Action_Boolean Teleport;

    bool TrackPadTouch;

    [SerializeField] MovePointScript ToX1;
    [SerializeField] MovePointScript ToZ2;

    //private Vector2 pos;
    //float r, sita;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if (Teleport.GetStateDown(hand))
        {
            ToX1.ReSet = !ToX1.ReSet;
            ToZ2.ReSet = !ToZ2.ReSet;

            //TrackPadTouch = !TrackPadTouch;
            Debug.Log("�p�b�h���́I");
        }
        else if (Teleport.GetStateUp(hand))
        {
            ToX1.ReSet = !ToX1.ReSet;
            ToZ2.ReSet = !ToZ2.ReSet;

            //TrackPadTouch = !TrackPadTouch;
            Debug.Log("�p�b�h����w��������I");
        }

        //Debug.Log("�p�b�h��" + TrackPadTouch);

        //pos = TrackPad.GetLastAxis(SteamVR_Input_Sources.RightHand);
        //r = Mathf.Sqrt(pos.x * pos.x + pos.y * pos.y);
        //sita = Mathf.Atan2(pos.y, pos.x) / Mathf.PI * 180;

        //Debug.Log("�p�b�h�F" + r + " " + sita);
        //Debug.Log("�p�b�h�F" + pos.x + " " + pos.y);



    }
}
