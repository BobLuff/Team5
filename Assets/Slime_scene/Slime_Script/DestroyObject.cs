using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 销毁物体
/// </summary>
public class DestroyObject : MonoBehaviour {
    [Header("持续时间")]
    public float timer = 5f;


    public void Start()
    {
        Destroy(gameObject, timer);
    }

}
