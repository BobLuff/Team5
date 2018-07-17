using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 控制黄色史莱姆的喷溅效果,其中粘性效果使用的插件脚本，可在黄色史莱姆的预制体的参数面板中查看
/// </summary>

public class Slime_Yellow : MonoBehaviour {


   // public GameObject Bounce_Brick;
    SplatterSystem.AbstractSplatterManager splatter;



    // Use this for initialization
    void Awake () {
        splatter = GameObject.FindGameObjectWithTag("splatterMgr").GetComponent<SplatterSystem.MeshSplatterManager>();
      

    }   
    

    /// <summary>
    /// 当有弹性效果后，变成了触发器模式
    /// </summary>
    /// <param name="collision"></param>

    void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log("Boom");
     
        splatter.Spawn(transform.position,Color.red);
        //Instantiate(Bounce_Brick, transform.position + new Vector3(0, 0.2f, 0), Quaternion.identity);
    }


}
