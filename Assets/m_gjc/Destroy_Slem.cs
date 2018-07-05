using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Slem : MonoBehaviour {

    public float destroy_time = 5;

    // Use this for initialization
    void Start()
    {

        Destroy(this.gameObject, destroy_time);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
