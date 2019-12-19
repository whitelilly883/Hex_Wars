using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    public GameObject hexPrefab;
    public GameObject boardBlocker;
    public int blockerPiecesPerPlayer = 5;
    //number of coluumns
    int column = 7;
    //number of tiles per row
    int columnTiles = 4;
    int numColumns = 0;
    //variables related to tile positioning within grid
    float columnOffSet = 42.3f;
    float zOffSet = 24.2f;
    float zIncrease = 48.6f;

    // Use this for initialization
    void Start()
    {
        ChipObserver.Instance.SetBoardBlocker(boardBlocker);
        MouseClickGlobal.blockersPerPlayer = blockerPiecesPerPlayer;
        // X and Z position for unity
        float X = 0f;
        float Z = 0f;
        int currentColumn = 0;
        //
        int ind = 0;
        numColumns = columnTiles;
        for (int c = 0; c < column; c++)
        {

            for (int p = 0; p < columnTiles; p++)
            {
                //spawn the playing field pieces
                GameObject temp = Instantiate(hexPrefab, new Vector3(X, 0, Z), Quaternion.identity);
                ChipObserver.Instance.AddToBoardPieces(temp.GetComponentInChildren<MouseClick>().gameObject);
                Z = Z + zIncrease;

            }
            currentColumn++;
            if (currentColumn < numColumns)
            {
                ind++;
                columnTiles++;
                Z = ((Z * 0) - ind) * zOffSet;
                X = X + columnOffSet;
            }
            else if (currentColumn == numColumns || currentColumn > numColumns)
            {
                ind--;
                columnTiles--;
                Z = ((Z * 0) - ind) * zOffSet;
                X = X + columnOffSet;
            }
        }
    }
}

