using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 板子的移动
/// </summary>

public class Brick_Move : MonoBehaviour {
      public enum movestate{
        moveX,
        moveY
      }

    [Header("选取移动方式，X轴 Or Y轴")]
    public  movestate mystate;

    private bool IsChangeX = false;
    private bool IsChangeY = false;

    [Header("移动距离的最大值")]
    public float MaxHeight = 0f;
    [Header("移动距离的最小值")]
    public float MinHeight = -4f;
    [Header("板的移动速度")]
    public float Speed = 1;




    // Use this for initialization
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        switch(mystate)
        {
            case movestate.moveX:
                MoveX_Axis(MaxHeight,MinHeight);
                break;
            case movestate.moveY:
                MoveY_Axis(MaxHeight,MinHeight);
                break;
            default:
                break;
        }


       // MoveY_Axis();
       
    }


    /// <summary>
    /// 控制Y轴移动
    /// </summary>
    /// <param name="maxHeight"></param>
    /// <param name="minHeight"></param>
    private void MoveY_Axis(float maxHeight,float minHeight)
    {
        //if(transform.position.y)
        if (transform.localPosition.y >= maxHeight)
        {
            IsChangeY = false;
        }
        if (transform.localPosition.y <= minHeight)
        {
            IsChangeY = true;
        }

        if (!IsChangeY)
        {
            transform.Translate(0, -Speed * Time.deltaTime, 0, Space.World);
        }
        else
        {
            transform.Translate(0, Speed * Time.deltaTime, 0, Space.World);
        }


    }


    /// <summary>
    /// 控制X轴移动
    /// </summary>
    /// <param name="maxHeight"></param>
    /// <param name="minHeight"></param>

    private void MoveX_Axis(float maxHeight, float minHeight)
    {
        if (transform.localPosition.x >= maxHeight)
        {
            print("test");
            IsChangeX = false;
        }
        if (transform.localPosition.x <= minHeight)
        {
            IsChangeX = true;
        }

        if (!IsChangeX)
        {
            transform.Translate(-Speed * Time.deltaTime,0, 0, Space.World);
        }
        else
        {
            transform.Translate(Speed * Time.deltaTime, 0, 0, Space.World);
        }

    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        
       // Debug.Log(coll.gameObject.tag);
        if(coll.gameObject.CompareTag("Player"))
        {
            coll.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            coll.transform.SetParent(null);
        }

    }


}
