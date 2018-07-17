using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 当player跳到该物体上，给player一个向上的弹力
/// 该脚本原本用作弹跳，现已遗弃，不过可用在有弹力的挡板上
/// </summary>


public class Bounce_Slime : MonoBehaviour {
    [Header("向上跳的力的大小")]
    public float UpForce = 5f;
    private bool IsBounce = false;     //是否进行弹跳
    private GameObject m_Player;


	// Use this for initialization
	void Start () {
        m_Player = GameObject.FindGameObjectWithTag("Player");
      
        if(m_Player==null)
        {
            Debug.LogError("Player is null");
            return;
        }
		
	}
	
	// Update is called once per frame
	void Update () {

        if (IsBounce) 
        {
         //   Debug.Log(m_Player.GetComponent<Player_Control>().facingRight);
           
                if (m_Player.GetComponent<Player_Control>().facingRight)
                {
                    m_Player.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 1) * UpForce, ForceMode2D.Impulse);
                }
                else
                {
                    m_Player.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 1) * UpForce, ForceMode2D.Impulse);
                }
     
         
    
            IsBounce = false;
        }
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
               Debug.Log("Bounce");
            IsBounce = true;
            m_Player.transform.position += new Vector3(0, 0.5f,0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }
}
