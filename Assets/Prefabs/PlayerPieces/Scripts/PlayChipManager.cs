using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayChipManager : MonoBehaviour
{
    public GameObject redColliders, blueColliders;
    public LayerMask chipLayers;
    public GameObject testPlacer;
    [SerializeField]
    private bool justFlipped = false;

    [SerializeField]
    private bool canFlip = false;
    private List<FlipInformation> possibleFlips;


    void Start()
    {
        possibleFlips = new List<FlipInformation>();
    }

    public string ColorShowing()
    {
        Vector3 bellowChip = transform.position;
        bellowChip.y -= 5;

        RaycastHit hit;
        Physics.Raycast(bellowChip, Vector3.up, out hit, 10, chipLayers);
        if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Blue"))
        {
            return "Red";
        }
        else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Red"))
        {
            return "Blue";
        }
        else
        {
            return "";
        }
    }

    public void CheckColliders()
    {
        Vector3 bellowChip = transform.position;
        bellowChip.y -= 5;

        RaycastHit hit;
        Physics.Raycast(bellowChip, Vector3.up, out hit, 10, chipLayers);

        if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Blue"))
        {
            redColliders.SetActive(true);
            blueColliders.SetActive(false);
        }
        else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Red"))
        {
            blueColliders.SetActive(true);
            redColliders.SetActive(false);
        }
    }

    public string ColorOnBottom()
    {
        Vector3 bellowChip = transform.position;
        bellowChip.y -= 5;

        RaycastHit hit;
        Physics.Raycast(bellowChip, Vector3.up, out hit, 10, chipLayers);

        if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Blue"))
        {
            return "Blue";
        }
        else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Red"))
        {
            return "Red";
        }

        return null;
    }

    public void SetJustFlipped(bool temp)
    {
        justFlipped = temp;
    }


    public bool GetJustFlipped()
    {
        return justFlipped;
    }

    public bool GetCanFlip()
    {
        return canFlip;
    }

    public void SetCanFlip(bool temp)
    {
        canFlip = temp;
    }

    public int PossibleFlipsCount()
    {
            return possibleFlips.Count;
    }

    public void AddPossibleFlips(FlipInformation temp)
    {
        possibleFlips.Add(temp);    
    }

    public void RemovePossibleFlip(FlipInformation temp)
    {
        possibleFlips.Remove(temp);
    }

    public void CheckIfStillFlippable()
    {
        if(possibleFlips.Count <= 0)
        {
            canFlip = false;
        }
    }

    public FlipInformation GetPossibleFlips(int i)
    {
            return possibleFlips[i];
    }

    public void ResetPossibleFlips()
    {
        possibleFlips = new List<FlipInformation>();
    }
}
