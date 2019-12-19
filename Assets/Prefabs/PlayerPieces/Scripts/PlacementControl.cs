using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementControl : MonoBehaviour
{
    public GameObject redColliders;
    public GameObject blueColliders;
    public GameObject numberChip;

    private int rotationCounter = 1;

    // Update is called once per frame
    void Update()
    {
        //Rotate the chip arround the y axis
        if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            if (GameManager.Instance.GetTurn() % 2 == 0)
            {
                transform.rotation = Quaternion.Euler(0, 60 * rotationCounter, 0);
            }

            //keeps player 2 chip in correct orientation.
            if (GameManager.Instance.GetTurn() % 2 == 1)
            {
                transform.rotation = Quaternion.Euler(180, 60 * rotationCounter, 0);
            }
            rotationCounter++;
        }
        Debug.DrawRay(transform.position, transform.right, Color.red, 20);

        //sets chip in place
        if (Input.touchCount == 2)
        {
            //Dissables this script
            GetComponent<PlacementControl>().enabled = false;
            //Sets justFlipped in PlayChipManager
            GetComponent<PlayChipManager>().SetJustFlipped(true);
            //Places chip in final placement
            Vector3 temp = new Vector3(numberChip.transform.position.x, numberChip.transform.position.y - 4, numberChip.transform.position.z);
            numberChip.transform.position = temp;
        }
    }
}
