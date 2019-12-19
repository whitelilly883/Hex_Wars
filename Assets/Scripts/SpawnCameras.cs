using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCameras : MonoBehaviour
{
    public Camera cam1;

    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(31.7f, 230.8f, -79.5f);
        transform.rotation = Quaternion.Euler(63.424f, 32.543f, 1.877f);
    }
    void Update()
    {
        //if (MouseClickGlobal.count >= MouseClickGlobal.blockersPerPlayer 
        //    && MouseClickGlobal.count < (MouseClickGlobal.blockersPerPlayer * 2))
        //{
        //    transform.position = new Vector3(217.4f, 236.4f, 217.6f); 
        //    transform.rotation = Quaternion.Euler(65.178f, -148.92f, 1.136f);
        //}

        //if (MouseClickGlobal.count >= (MouseClickGlobal.blockersPerPlayer *2))
        //{
        //    if (MouseClickGlobal.count % 2 == 1)
        //    {
        //        transform.position = new Vector3(217.4f, 236.4f, 217.6f);
        //        transform.rotation = Quaternion.Euler(65.178f, -148.92f, 1.136f);
        //    }

        //    else if (MouseClickGlobal.count % 2 == 0)
        //    {
        //        transform.position = new Vector3(31.7f, 230.8f, -79.5f);
        //        transform.rotation = Quaternion.Euler(63.424f, 32.543f, 1.877f);
        //    }
        //}
    }
}
