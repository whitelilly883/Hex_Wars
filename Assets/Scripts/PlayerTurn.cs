using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTurn : MonoBehaviour
{
    public GameObject endGameButton;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMesh>().text = "Block placement phase";    
    }

    // Update is called once per frame
    void Update()
    {
        if (MouseClickGlobal.count < MouseClickGlobal.blockersPerPlayer
            && GameManager.Instance.GetTurn() == 0)
        {
            GetComponent<TextMesh>().text = "Players Turn: Red";
            GetComponent<TextMesh>().color = Color.red;
        }

        if (MouseClickGlobal.count >= MouseClickGlobal.blockersPerPlayer
            && GameManager.Instance.GetTurn() == 0)
        {
            GetComponent<TextMesh>().text = "Players Turn: Blue";
            GetComponent<TextMesh>().color = Color.blue;
        }

        if (GameManager.Instance.GetTurn() % 2 == 0 && GameManager.Instance.GetTurn() > 0)
        {
            GetComponent<TextMesh>().text = "Players Turn: Red";
            GetComponent<TextMesh>().color = Color.red;
        }

        if (GameManager.Instance.GetTurn() % 2 == 1 && GameManager.Instance.GetTurn() > 0)
        {
            GetComponent<TextMesh>().text = "Players Turn: Blue";
            GetComponent<TextMesh>().color = Color.blue;
        }

        if (GameManager.Instance.GetTurn() == 28)
        {
            int countBlue = 0;
            int countRed = 0;
            for(int i = 0; i < ChipObserver.Instance.numberedPieces.Count; i++)
            {
                if(ChipObserver.Instance.numberedPieces[i].GetComponentInChildren<PlayChipManager>().ColorShowing() == "Red")
                {
                    countRed++;
                }
                else if (ChipObserver.Instance.numberedPieces[i].GetComponentInChildren<PlayChipManager>().ColorShowing() == "Blue")
                {
                    countBlue++;
                }
            }

            if(countRed > countBlue)
            {
                GetComponent<TextMesh>().text = "Red player WINS";
                GetComponent<TextMesh>().color = Color.red;
            }
            else if (countBlue > countRed)
            {
                GetComponent<TextMesh>().text = "Blue Player WINS";
                GetComponent<TextMesh>().color = Color.blue;
            }
            else
            {
                GetComponent<TextMesh>().text = "Blue Player WINS";
                GetComponent<TextMesh>().color = Color.green;
            }

            endGameButton.SetActive(true);
        }
    }
}
