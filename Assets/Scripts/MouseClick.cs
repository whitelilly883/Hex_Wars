using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour 
{
	public Vector3 pos;
	public GameObject hexBlock;
    public GameObject playerPiece;
    public MeshCollider meep; 

    void OnMouseDown ()
	{

		pos = transform.position;
		pos.y += 4;
		Global.count++;
        Debug.Log(Global.count);
        
		var X = pos.x;
		var Y = pos.y;
		var Z = pos.z;

        if (Global.count <= (Global.blockerPerPlayer * 2))
        {
            Instantiate(hexBlock, new Vector3(X, Y, Z), Quaternion.identity);
            meep.enabled = false;
            Debug.Log("pos " + pos);
            //Global.count++;
            
        }

        if (Global.count > (Global.blockerPerPlayer * 2))
        {
            Instantiate(playerPiece, new Vector3(X, Y, Z), Quaternion.identity);
            meep.enabled = false;
            Debug.Log("pos " + pos);
        }
    }
	
}
