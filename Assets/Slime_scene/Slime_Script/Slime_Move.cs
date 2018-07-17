using SplatterSystem.Platformer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 控制史莱姆的移动
/// </summary>

[RequireComponent(typeof(Rigidbody2D))]
public class Slime_Move : MonoBehaviour {
    public Vector3 SlinghotMiddleVector;
    public TrackGraphic m_TrackGraphic;

    private void Awake()
    {
        m_TrackGraphic = GameObject.FindGameObjectWithTag("Player").GetComponent<TrackGraphic>();
    }

    // Use this for initialization
    void Start()
    {
      //  GetComponent<Rigidbody2D>().isKinematic = false;

        //   GameObject Addforce = Instantiate(SlimePrefab, transform.position, rotation);
        Fly(m_TrackGraphic.distance, m_TrackGraphic.SlinghotMiddleVector);

    }

    /// <summary>
    /// 控制史莱姆的飞行，参数需和轨迹线保持一致
    /// </summary>
    /// <param name="distance"></param>
    /// <param name="mousePos"></param>


    void Fly(float distance, Vector2 mousePos)
    {


        Vector3 v2 = mousePos;
     //   Debug.Log(v2);
        //  Vector2 segVelocity = new Vector2(v2.x, v2.y)  * distance;

        transform.GetComponent<Rigidbody2D>().velocity = new Vector2(v2.x, v2.y) * distance * 2;

        //  transform.position+ =  segVelocity  + 0.5f * Physics2D.gravity * Mathf.Pow(time2, 2);


    }
}
