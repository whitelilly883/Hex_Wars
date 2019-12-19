using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ex: GameManager.Instance.Pause(true); or GameManager.Instance.NextPlayersTurn; 

public class GameManager
{ 
    private static GameManager instance;
    private int turn;

    //initialize here do not reference game objects as they are not created yet
    private GameManager()
    {
        turn = 0;       
    }


    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new GameManager();
            }

            return instance;
        }
    }


    public int GetTurn()
    {
        return turn;
    }

    public void Pause(bool paused)
    {

    }

    public void NextTurn()
    {
        Debug.Log("Turn: " + turn + " End");
        turn++;
        Debug.Log("Turn: " + turn + " Start");
    }

    public void Reset()
    {
        instance = null;
    }

}
