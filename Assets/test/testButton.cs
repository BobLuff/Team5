using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testButton : MonoBehaviour {
   public bool isMouseDown = false;
    private Vector3 lastMousePosition = Vector3.zero;
    private Vector3 offset;

    private void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
        }

        if(isMouseDown)
        {
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity);
            if(hit.collider!=null)
            {
                if(hit.collider.tag=="boot")
                {
                  //  print("OK");
                    MoveCube();
                }
               
            }



        }
     
 
    }

    void MoveCube()
    {

      
        offset = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset.z = 0;

        Debug.Log("offset:" + offset);
    

        transform.position = offset;
        lastMousePosition = transform.position;
      
    


        
    }
         

}

