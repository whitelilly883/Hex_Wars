using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipObserver/* : MonoBehaviour*/
{
    private static ChipObserver instance;
    public List<GameObject> boardPieces;
    public List<GameObject> numberedPieces;
    public List<FlipInformation> flippablePieces;
    private GameObject boardBlocker;

    ChipObserver()
    {
        boardPieces = new List<GameObject>();
        numberedPieces = new List<GameObject>();
        flippablePieces = new List<FlipInformation>();
    }

    public static ChipObserver Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ChipObserver();
            }

            return instance;
        }
    }

    public void SetBoardBlocker(GameObject pBlocker)
    {
        boardBlocker = pBlocker;
    }

    public void AddToBoardPieces(GameObject pBoardPiece)
    {
        boardPieces.Add(pBoardPiece);
    }

    public void AddToNumberedPieces(GameObject pNumberedPieces)
    {
        numberedPieces.Add(pNumberedPieces);
    }



    public int FlippablePiecesCount()
    {
        return Instance.flippablePieces.Count;
    }

    public void CheckForFlippableFirst()
    {
        for (int i = 0; i < numberedPieces.Count; i++)
        {
            #region Debug 
            //Debug.Log(numberedPieces.Count
            //    + " C : i " + i + " ChipObserver CheckForFlipFirst");
            //Debug.Log(numberedPieces[i].GetComponentInChildren<PlayChipManager>().GetCanFlip() 
            //    + " Bool for if CheckForFlippableFirst " + GameManager.Instance.GetTurn());
            #endregion
            if (Instance.numberedPieces[i].GetComponentInChildren<PlayChipManager>().GetCanFlip())
            {
                flippablePieces.Add(numberedPieces[i].GetComponentInChildren<PlayChipManager>().GetPossibleFlips(0));
            }
        }
    }

    public void FlipFlippable()
    {
        if (flippablePieces.Count <= 0)
        {
            CheckForFlippableFirst();
        }

        #region Above Debug
        //Debug.Log("FlipFlippable entered before for loop");
        //Debug.Log(GameManager.Instance.GetTurn() + " numberedPiece count before CheckForFlippableFirst()");
        //Debug.Log(flippablePieces.Count + " flippableCount : " + GameManager.Instance.GetTurn());

        //if (flippablePieces.Count <= 0)
        //{
        //    Debug.Log(flippablePieces.Count + " In FlipFlippable turn " + GameManager.Instance.GetTurn() + " ");
        //    CheckForFlippableFirst();
        //    Debug.Log(flippablePieces.Count + " flippableCount at end of if check : " + GameManager.Instance.GetTurn());

        //}
        #endregion

        for (int i = 0; i < flippablePieces.Count; i++)
        {
            flippablePieces[i].GetPlayChip().GetComponent<FlipControlles>().FlipChip();

            #region Debug for above 
            //Debug.Log("FlipFlippable begining " + i);

            ////Debug.Log(numberedPieces.Count
            ////    + " C : i " + i + " ChipObserver FlipFlippable");
            ////Debug.Log(Instance.numberedPieces[i].GetComponentInChildren<PlayChipManager>().GetCanFlip()
            ////    + " Bool for if FlipFlippable turn " + GameManager.Instance.GetTurn());
            ////if (numberedPieces[i].GetComponentInChildren<PlayChipManager>().GetCanFlip())
            ////{
            ////Debug.Log("FlipFlippable if triggered " + i);
            ////Debug.Log(flippablePieces.Count + " number of possible flips");
            ////Debug.Log(numberedPieces[i].GetComponentInChildren<PlayChipManager>().GetPossibleFlips(0).GetFlipAxis());
            ////Debug.Log(flippablePieces[0].GetFlipAxis());
            ////Debug.Log(flippablePieces[0].GetFlipAxis() + " which axis it should flip on " 
            ////    + flippablePieces[0].GetTriangleToFlip());
            //Debug.Log(i + " HALLO : " + GameManager.Instance.GetTurn());
            ////Instance.flippablePieces.Add(numberedPieces[i].GetComponentInChildren<PlayChipManager>().GetPossibleFlips(0));
            //flippablePieces[i].GetPlayChip().GetComponent<FlipControlles>().FlipChip();
            ////}
            #endregion
        }
    }

    public void EndBlockPlacement()
    {
        for (int i = 0; i < boardPieces.Count; i++)
        {
            if (boardPieces[i].GetComponent<MouseClick>().enabled == true)
            {
                boardPieces[i].GetComponent<PlayNumberedPiece>().enabled = true;
            }
            boardPieces[i].GetComponent<MouseClick>().enabled = false;
        }

        GameManager.Instance.NextTurn();
    }

    public void EndNumberedPlacement()
    {
        #region Debug
        //Debug.Log(Instance.numberedPieces.Count + " ChipObserver EndNumberedPlacement Before check");
        //CheckForFlippableFirst();
        //Debug.Log(Instance.numberedPieces.Count + " ChipObserver EndNumberedPlacement after check");

        //Debug.Log(Instance.FlippablePiecesCount() + " Flipable Pieces at end of turn "
        //+ GameManager.Instance.GetTurn());
        /*        Instance.*/
        //FlipFlippable();
        #endregion
        for (int i = 0; i < numberedPieces.Count; i++)
        {
            numberedPieces[i].GetComponentInChildren<PlayChipManager>().SetCanFlip(false);
            numberedPieces[i].GetComponentInChildren<PlayChipManager>().SetJustFlipped(false);
            numberedPieces[i].GetComponentInChildren<PlayChipManager>().ResetPossibleFlips();
            flippablePieces = new List<FlipInformation>();
        }
        MouseClickGlobal.count++;
        GameManager.Instance.NextTurn();
    }

    public void ToggleBoardBlocker()
    {
        if (boardBlocker != null)
        {
            Instance.boardBlocker.SetActive(!Instance.boardBlocker.activeSelf);
        }
        else
        {
            Debug.Log("Set board blocker on map.");
        }
    }

    public void Reset()
    {
        boardPieces = new List<GameObject>();
        numberedPieces = new List<GameObject>();
        flippablePieces = new List<FlipInformation>();
        
    }

}

