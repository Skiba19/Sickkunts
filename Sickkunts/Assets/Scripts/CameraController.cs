using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed=20f;
    public float scrollSpeed=2f;
    public float minY=2.5f;
    public float maxY=20f;
    
    // Update is called once per frame
    void Update()
    {
        if(GameManager.GameIsOver)
        {
            this.enabled=false;
            return;
        }
        if(Input.GetKey("d"))
        {
            transform.Translate(Vector3.forward*panSpeed*Time.deltaTime, Space.World);
        }
        if(Input.GetKey("a"))
        {
            transform.Translate(Vector3.back*panSpeed*Time.deltaTime, Space.World);
        }
        if(Input.GetKey("w"))
        {
            transform.Translate(Vector3.left*panSpeed*Time.deltaTime, Space.World);
        }
        if(Input.GetKey("s"))
        {
            transform.Translate(Vector3.right*panSpeed*Time.deltaTime, Space.World);
        }
        if(Input.GetKey("q"))
        {
            transform.Rotate(0f, -1f, 1f);
        }
        if(Input.GetKey("e"))
        {
            transform.Rotate(0f, 1f, -1f);
        }

        float scroll=Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos=transform.position;
        pos.y-=scroll*250*scrollSpeed*Time.deltaTime;
        pos.y=Mathf.Clamp(pos.y,minY,maxY);
        transform.position=pos;
    }
}
