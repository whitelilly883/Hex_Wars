using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickGlobal:MonoBehaviour
{
    public static int count = 0;
    public static int blockersPerPlayer;
    
}

public class MouseClick : MonoBehaviour 
{
    public bool Clickable = true;
    private Vector3 pos;
    [SerializeField]
    private GameObject playerOne, playerTwo;

    public void Start()
    {
        pos = transform.position;
        pos.y += 3;
    }

    void OnMouseDown()
	{
        if (gameObject.GetComponent<MouseClick>().enabled)
        {
            //Player one blocker pieces
            if (MouseClickGlobal.count < MouseClickGlobal.blockersPerPlayer
                && GameManager.Instance.GetTurn() == 0)
            {
                //Debug.Log("Player1");
                Instantiate(playerOne.GetComponent<PlayerControlles>().blockPiece
                    , pos, Quaternion.identity);
            }

            //player two blocker pieces
            if (MouseClickGlobal.count >= MouseClickGlobal.blockersPerPlayer
                && GameManager.Instance.GetTurn() == 0)
            {
                //Debug.Log("Player2");
                Instantiate(playerTwo.GetComponent<PlayerControlles>().blockPiece
                    , pos, Quaternion.identity);
            }

            MouseClickGlobal.count++;

            if (MouseClickGlobal.count == MouseClickGlobal.blockersPerPlayer * 2)
            {
                MouseClickGlobal.count++;
                ChipObserver.Instance.EndBlockPlacement();
            }

            Clickable = false;
            GetComponent<PlayNumberedPiece>().enabled = false;
            GetComponent<MouseClick>().enabled = false;
        }
    }

    public GameObject GetPlayerOne()
    {
        return playerOne;
    }

    public GameObject GetPlayerTwo()
    {
        return playerTwo;
    }
}
