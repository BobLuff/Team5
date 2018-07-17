using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


/// <summary>
/// 已遗弃，不需要蓄力过程；
/// 存在一个bug，还需要判断，只有player站在物体上放才有弹跳效果
/// 控制player在史莱姆上的弹跳；
/// 需要引用插件Dotween；
/// </summary>

public class Slime_Bouncy : MonoBehaviour {

    private Vector3 orginPos;      //记录初始位置
    private Vector3 orginScale;   //初始的Scale

    private GameObject player;

   [Header("计时器的初始值，初始值越大，弹力越大")]
    public float timer = 4;  //计时器，用来计算按下s键的时长。按的越久，弹力越大,因按下的时间间隔短，需设置初始时间
    private bool IsTouch = false;//player是否站在史莱姆上。

    // Use this for initialization
    void Start()
    {
       // print(transform.lossyScale);
    //    print(transform.lossyScale);
        player = GameObject.FindGameObjectWithTag("Player");
        if (!player)
            return;
        orginPos = transform.position;
        orginScale = transform.localScale;

        // transform.DOScaleY(5, 10);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S) && IsTouch)
        {

            if (transform.localScale.y >= 0.5f)
            {
                timer += 1 * Time.deltaTime;


                // 盒子也要进行缩放
                transform.localScale += new Vector3(0, -1, 0) * 0.1f * Time.deltaTime;
                // （注意盒子上下缩放的时候会离开地面，因此要同时向下进行移动）
                transform.localPosition += new Vector3(0, -1, 0) * 0.04f * Time.deltaTime;
            }




        }
        if (Input.GetKeyUp(KeyCode.S) && IsTouch)
        {
            OnJump();

            // 盒子在形状和位置上进行还原
            transform.DOMove(orginPos, 0.01f);
            transform.DOScale(orginScale, 0.01f);
            IsTouch = false;

        }


    }

    void OnJump()
    {
        Debug.Log("Timer : " + timer);
        //  player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Rigidbody2D>().AddForce(Vector2.up*timer, ForceMode2D.Impulse);
       // player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * timer, ForceMode2D.Impulse);
        timer = 4;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           // Debug.Log("Player touch Slime!");
            IsTouch = true;
        }
        if (collision.gameObject.CompareTag("ground"))
        {
          //  Debug.Log("Touch ground");

        }
    }

}
