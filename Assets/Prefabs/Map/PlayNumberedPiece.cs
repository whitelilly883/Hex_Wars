using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayNumberedPiece : MonoBehaviour
{
    public LayerMask chipLayers;

    private GameObject playerOne, playerTwo;
    private Vector3 pos;
    private GameObject numberedChip;


    void Start()
    {
        numberedChip = new GameObject();
        playerOne = GetComponent<MouseClick>().GetPlayerOne();
        playerTwo = GetComponent<MouseClick>().GetPlayerTwo();
        pos = transform.position;
        pos.y += 8;
    }

    void OnMouseDown()
    {
        if (gameObject.GetComponent<PlayNumberedPiece>().enabled
            && MouseClickGlobal.count > MouseClickGlobal.blockersPerPlayer * 2)
        {
            //player one gets to choose first block player two
            //plays first numbered piece. This helps balance the fact
            //that the second player to place a numbered piece has a remaining chip at end of game
            if (GameManager.Instance.GetTurn() % 2 == 1)
            {
                Debug.Log("Player2");
                Quaternion tempRotaion = Quaternion.identity;
                tempRotaion.x = 180;

                if (playerTwo.GetComponent<PlayerControlles>() == null)
                {
                    playerTwo = GetComponent<MouseClick>().GetPlayerTwo();
                }

                numberedChip = Instantiate(playerTwo.GetComponent<PlayerControlles>().numberedPiece
                    , pos, Quaternion.identity);
                numberedChip.GetComponentInChildren<PlayChipManager>().gameObject.transform.Rotate(new Vector3(180, 0, 0));

            }
            else if (GameManager.Instance.GetTurn() % 2 == 0)
            {
                Debug.Log("Player1");

                if (playerOne.GetComponent<PlayerControlles>() == null)
                {
                    playerOne = GetComponent<MouseClick>().GetPlayerTwo();
                }

                numberedChip = Instantiate(playerOne.GetComponent<PlayerControlles>().numberedPiece
                    , pos, Quaternion.identity);

            }

            ChipObserver.Instance.AddToNumberedPieces(numberedChip);
            numberedChip.GetComponentInChildren<PlayChipManager>().CheckColliders();
            StartCoroutine(WaitForEndOfPlacement(numberedChip));

        }

        if (gameObject.GetComponent<PlayNumberedPiece>().enabled
            && MouseClickGlobal.count == MouseClickGlobal.blockersPerPlayer * 2)
        {
            MouseClickGlobal.count++;
        }
    }

    public IEnumerator WaitForEndOfPlacement(GameObject pPlayedPiece)
    {
        ChipObserver.Instance.ToggleBoardBlocker();
        GetComponent<PlayNumberedPiece>().enabled = false;

        while (pPlayedPiece.GetComponentInChildren<PlacementControl>().enabled == true)
        {
            yield return new WaitForSecondsRealtime(1 / 60);
        }

        StartCoroutine(WaitForChipFall());

    }

    IEnumerator WaitForChipFall()
    {
        yield return new WaitForSecondsRealtime(1/60);
 
        ChipObserver.Instance.CheckForFlippableFirst();
        yield return new WaitForSecondsRealtime(15 / 60);

        ChipObserver.Instance.FlipFlippable();
        yield return new WaitForSecondsRealtime(100 / 60);

        ChipObserver.Instance.EndNumberedPlacement();

        ChipObserver.Instance.ToggleBoardBlocker();

        #region Debug for multi
        //yield return new WaitForSecondsRealtime(1 / 60);
        //Debug.Log(ChipObserver.Instance.numberedPieces.Count + " numberedPiece count before CheckForFlippableFirst()");
        //Debug.Log(ChipObserver.Instance.flippablePieces.Count + " flippablePieces count before CheckForFlippableFirst()");


        //ChipObserver.Instance.CheckForFlippableFirst();
        //yield return new WaitForSecondsRealtime(15 / 60);

        //Debug.Log(ChipObserver.Instance.numberedPieces.Count + " numberedPiece count after CheckForFlippableFirst()");

        //ChipObserver.Instance.FlipFlippable();
        //Debug.Log("Tweet");
        //yield return new WaitForSecondsRealtime(100 / 60);
        //ChipObserver.Instance.EndNumberedPlacement();

        //ChipObserver.Instance.ToggleBoardBlocker();
        #endregion
    }
}
