using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 控制人物行走投掷攻击等行为
/// </summary>
public class Player_Control : MonoBehaviour {
    public float MaxSpeed=1;//移动速度
    public float jumpForce=10;//跳跃高度
    private Rigidbody2D rig_player;//获取自身刚体
    public Animator anim;//获取动画
    public Transform checkGround;//Player位置，用于检测是否在地面
    public LayerMask groundLayer;//检测可以向上跳跃的层级
    bool isGround;//判断是否在地面
    public GameObject green;//绿色史莱姆
    public float force = 10f;
    // Use this for initialization
    private void Awake()
    {
        rig_player = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(checkGround.position, 0.1f, groundLayer);
        if (Input.GetButton("Jump")&&isGround)//跳跃
        {
            rig_player.velocity = new Vector2(rig_player.velocity.x, jumpForce);
        }
        float hor = Input.GetAxis("Horizontal");//行走
        rig_player.velocity = new Vector2(hor * MaxSpeed,rig_player.velocity.y);
        //anim.SetFloat("SPeed", Mathf.Abs(rig_player.velocity.x));
        //转向
        if (rig_player.velocity.x > 0) {
            transform.localScale = new Vector3(1,1,1);
        }
        if (rig_player.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetMouseButtonUp(0))//投掷
        {
            Throw_Slem(Input.mousePosition);
        }
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void Throw_Slem(Vector2 pos)//投掷实现
    {
        Vector2 location = Camera.main.ScreenToWorldPoint(pos);//鼠标位置转化为世界坐标系
        Vector2 ray = location.normalized;//转化为单位向量，得到扔出方向的射线
        float angle = Vector2.Angle(ray, transform.up);   //与Y轴夹角
        Quaternion rotation = Quaternion.Euler(0, 0, angle);    //扔出时-史莱姆的角度
        GameObject Addforce = Instantiate(green, transform.position, rotation);
        Addforce.GetComponent<Rigidbody2D>().AddForce(ray * force); //添加射线方向的力
    }
}
