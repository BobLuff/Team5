using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 该脚本用来史莱姆在空中飞行时，进行射线检测，当检测到物体，就销毁自己，生成一个带有粘性的黄色史莱姆
/// 为什么要这样做？
/// 因为粘性效果和飞行不能共存，不然史莱姆不会沿着轨迹运动，
/// 这段代码请勿修改
/// </summary>
public class Slime_Yellow_Track : MonoBehaviour {
    private bool m_checkAround = true;
    public GameObject YellowSlime;      //该预制体为真正生成在场景中的预制体

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
      //  Debug.Log("m_CheckAround: " + m_checkAround);
        if (m_checkAround)
        {
            CheckAround();
        }

    }



    /// <summary>
    /// 进行圆形射线检测
    /// </summary>
    void CheckAround()
    {

        var coll = Physics2D.OverlapCircle(transform.position, 0.5f, (1 << 8));
        // 


        if (coll)
        {
            Debug.Log(coll.gameObject.tag);


            Instantiate(YellowSlime, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            m_checkAround = false;


        }


    }
}
