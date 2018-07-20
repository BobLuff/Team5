using System.Collections;
using System.Collections.Generic;
using UnityEngine;            
          

/// <summary>
/// 控制人物行走投掷攻击等行为
/// </summary>

    [RequireComponent(typeof(TrackGraphic))]
public class Player_Control : MonoBehaviour {

    public enum MySlime
    {
        Slime_Red,
        Slime_Yellow,
    }
    [Header("player准备投掷的slime")]

    [SerializeField] private MySlime mySlime1;

    [Header("player运动的最大速度")]
    public float MaxSpeed=1;//移动速度

    [Header("player的跳跃高度")]
    public float jumpForce=10;//跳跃高度

    private Rigidbody2D rig_player;//获取自身刚体
 
    bool isGround;//判断是否在地面

    [Header("史莱姆的预制体")]
    [Header("0-Red；1-Yellow；2-Blue")]
    public GameObject[] SlimePrefab;//三种 史莱姆
    [Header("史莱姆的出生点")]
    public GameObject SpawnPoint;
    [Header("player的运动速度")]
    public float playerMoveForce = 20f;
    //public float force = 10f;
    public bool facingRight = true;

    [Header("UI-> Image，需手动拖拽进来")]
    public Red_CoolingTime UI_Red;
    public Yellow_CoolingTime UI_Yellow;

   


  //  public bool Having_Slime_Blue = true;
    public bool Having_Slime_Yellow = true;
    public bool Having_Slime_Red = true;

    public MySlime MySlime1
    {
        get
        {
            return MySlime11;
        }

        set
        {
            MySlime11 = value;
        }
    }

    public MySlime MySlime11
    {
        get
        {
            return mySlime1;
        }

        set
        {
            mySlime1 = value;
        }
    }


    // Use this for initialization
    private void Awake()
    {
        rig_player = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }
    private void Start()
    {
        MySlime1 = MySlime.Slime_Red;
    }



    private void FixedUpdate()
    {
        #region 选择不同的史莱姆
        if (Input.GetKey(KeyCode.Alpha1))                 //1--选择红色Slime
        {
            MySlime1 = MySlime.Slime_Red;
           // Having_Slime_Red = false;
        }
        if(Input.GetKey(KeyCode.Alpha2))
        {
            MySlime1 = MySlime.Slime_Yellow;
        }
    

        #endregion

        #region player进行跳跃，对地面和天花板进行的判断
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics2D.Raycast(transform.position, Vector2.down, 2f, LayerMask.GetMask("Platform")))
            {
                transform.GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
                Debug.Log("IsGround");
            }

            if (Physics2D.Raycast(transform.position, Vector2.up, 2f, LayerMask.GetMask("ceiling")))
            {
                transform.GetComponent<Rigidbody2D>().AddForce(Vector3.down * jumpForce, ForceMode2D.Impulse);
                Debug.Log("IsCeiling");
            }

        }
        #endregion


        float hor = Input.GetAxis("Horizontal");//行走
        if(hor*rig_player.velocity.x<MaxSpeed)
        {
            rig_player.AddForce(Vector2.right * hor * playerMoveForce);
        }
        if(Mathf.Abs(rig_player.velocity.x)>MaxSpeed)
        {
            rig_player.velocity = new Vector2(Mathf.Sign(rig_player.velocity.x) * MaxSpeed, rig_player.velocity.y);
        }


        #region    进行player的转向
        if (hor>0&&!facingRight) {
       
            Flip();
            print(1);
        }
        if (hor < 0&&facingRight)
        {
            Flip();
            print(2);
 
        }
        #endregion

        #region 投掷物体
        if (Input.GetMouseButton(0))//投掷
        {
            switch(MySlime1)
            {
                case MySlime.Slime_Red:  
                    if(Having_Slime_Red)
                    {
                        Instantiate(SlimePrefab[0], SpawnPoint.transform.position, Quaternion.identity);
                      //  mySlime = MySlime.idle;
                        Having_Slime_Red = false;
                        UI_Red.HavingRed = false;
                    }     
                    break;
                case MySlime.Slime_Yellow:
                    if(Having_Slime_Yellow)
                    {
                        Instantiate(SlimePrefab[1], SpawnPoint.transform.position, Quaternion.identity);
                        Having_Slime_Yellow = false;
                        UI_Yellow.HavingYellow = false;
                    }
                    break;
  
                default:
                    //return;
                    break;

            }

        }
        #endregion
    }

    /// <summary>
    /// Flip()用左右翻转player
    /// </summary>
   public  void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
	
	


}
