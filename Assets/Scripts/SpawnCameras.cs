using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCameras : MonoBehaviour
{
    public Camera cam1;
    private Vector3 pos1;
    private Vector3 pos2;
    private Quaternion rotation1;
    private Quaternion rotation2;
    // Use this for initialization
    void Start()
    {
        pos1 = new Vector3(31.7f, 230.8f, -79.5f);
        rotation1 = Quaternion.Euler(63.424f, 32.543f, 1.877f);

        pos2 = new Vector3(217.4f, 236.4f, 217.6f);
        rotation2 = Quaternion.Euler(65.178f, -148.92f, 1.136f);
        transform.position = pos1;
        transform.rotation = rotation1;
    }

    
    void Update()
    {
        if (Global.count >= Global.blockerPerPlayer && Global.count < (Global.blockerPerPlayer * 2))
        {
            transform.position = pos2;
            transform.rotation = rotation2;
        }

        if (Global.count >= (Global.blockerPerPlayer *2))
        {
            if (Global.count % 2 == 1)
            {
                transform.position = pos2;
                transform.rotation = rotation2;
            }
            else if (Global.count % 2 == 0)
            {
                transform.position = pos1;
                transform.rotation = rotation1;
            }
        }
    }
}
