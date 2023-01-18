using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance = null;
    public bool lastbattle = false;

    CharacterStatus Dr;
    CharacterStatus Player;
    CharacterStatus Updatedate;

    public int shotDmg = 1;

    public GameObject Drtext;
    Text Statustext;

    public GameObject head;
    public GameObject tail;
    public GameObject rwing;
    public GameObject lwing;
    public GameObject body;







    private DragonHitScript DrHit;
    private ChangeMatScript Cscript;

    //以下説明文
    /*このManagerScriptにやりとりしてドラゴンとかプレイヤーの状態をやり取りすることにしようかなと
     StatusUpdateの箇所においてのint型の変数の受け渡し時にそれが0なら両方の更新1ならドラゴンのみ2ならプレイヤーのみにすること*/
    public struct CharacterStatus
    {
        public int Hp;
        public int Headhp;
        public int Bodyhp;
        public int Rwinghp;
        public int Lwinghp;
        public int tailhp;
        public int Status;
        public bool active;

        //public DrStatus(int hp, int status, bool active)
        //{
        //    this.Hp = hp;
        //    this.
        //}
    }
    



    // Start is called before the first frame update
    void Start()
    {
        

        Dr.Hp = 100;

        Dr.Status = 0;  //0なにもなし　1Anim中　2特殊Anim中　3撃沈中
        Dr.active = false;//0動作不能　1動作可能


        Dr.Headhp = 15;
        Dr.Bodyhp = 30; 
        Dr.Rwinghp = 15; 
        Dr.Lwinghp = 15; 
        Dr.tailhp = 15; 



        Player.Hp = 10000;
        Player.Status = 0;//0なにもなし　1Anim兼行動中 2 スタン中
        Player.active = false;//0動作不能　1動作可能

        Updatedate.Hp = 0;
        Updatedate.Status = 0;//0なにもなし　1Anim兼行動中 2 スタン中
        Updatedate.active = false;//0動作不能　1動作可能


        Statustext = Drtext.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        //Statustext.text = string.Format("{00} Dr.Hp",Dr.Hp); //毎フレーム呼び出さなくても変更時に一回呼び出すだけでいいかもしれない、けどDebug用ならこのままでおｋ
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void DateMove(int bui)
    {
        switch (bui)
        {
            case 1:
                Cscript = body.GetComponent<ChangeMatScript>();
                Cscript.ChangeMat(1);
                break;

            case 2:
                //Debug.Log("頭Change");
                Cscript = head.GetComponent<ChangeMatScript>();
                Cscript.ChangeMat(2);
                break;

            case 3:
                Cscript = lwing.GetComponent<ChangeMatScript>();
                Cscript.ChangeMat(3);
                break;

            case 4:
                Cscript = tail.GetComponent<ChangeMatScript>();
                Cscript.ChangeMat(4);
                break;

            case 5:
                Cscript = rwing.GetComponent<ChangeMatScript>();
                Cscript.ChangeMat(5);
                break;


            default:
                break;

        }

    }

    //private void StatusUpdate(CharacterStatus oldsta, CharacterStatus newsta, int pattern)//patternいらない説
   // {
    //    oldsta.Hp = newsta.Hp;
    //    oldsta.Status = newsta.Status;
   //     oldsta.active = newsta.active;
   // }


    public void HitAcceptance(int pate) 
    {
        //Debug.Log(pate+"にあたった");

        switch (pate)
        {
            case 1:
                Dr.Bodyhp -= shotDmg;
                Dr.Hp -= shotDmg;
                if (Dr.Bodyhp <= 0) DateMove(pate);
                if (Dr.Headhp <= 0) Dr.Hp -= shotDmg;
                break;

            case 2:
                Dr.Headhp -= shotDmg;
                Dr.Hp -= shotDmg;
                if (Dr.Headhp <= 0) DateMove(pate);
                if (Dr.Headhp <= 0) Dr.Hp -= shotDmg;
                break;

            case 3:
                Dr.Lwinghp -= shotDmg;
                Dr.Hp -= shotDmg;
                if (Dr.Lwinghp <= 0) DateMove(pate);
                if (Dr.Lwinghp <= 0) Dr.Hp -= shotDmg;
                break;

            case 4:
                Dr.tailhp -= shotDmg;
                Dr.Hp -= shotDmg;
                if (Dr.tailhp <= 0) DateMove(pate);
                if (Dr.tailhp <= 0) Dr.Hp -= shotDmg;
                break;

            case 5:
                Dr.Rwinghp -= shotDmg;
                Dr.Hp -= shotDmg;
                if (Dr.Rwinghp <= 0) DateMove(pate);
                if (Dr.Rwinghp <= 0) Dr.Hp -= shotDmg;
                break;


            default:
                Debug.Log("弾の判定ではない");
                break;


        }

        //if(Dr.Headhp == 0)


        //Debug.Log("総HP" + Dr.Hp + "\n頭Hp" + Dr.Headhp + "\n体Hp" + Dr.Bodyhp + "\n右羽Hp" + Dr.Rwinghp + "\n左羽Hp" + Dr.Lwinghp + "\n尻尾Hp" + Dr.tailhp);
        //Debug.Log("総HP" + Dr.Hp + "\n頭Hp" + Dr.Headhp);


    }

    public void PrintEvent(string s,CharacterStatus st)
    {
        if(s == "linecheck")//ボーダーライン
        {
            if (st.Hp == 40) lastbattle = true;
        }
    }
}
