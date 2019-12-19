using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipInformation 
{
    private Vector3 flipAxis = new Vector3(0, 0, 0);
    private GameObject triangleToFlip;
    private GameObject playChip;

    public void SetFlipAxis(Vector3 temp)
    {
        flipAxis = temp;
    }

    public Vector3 GetFlipAxis()
    {
        return flipAxis;
    }

    public void SetTriangleToFlip(GameObject temp)
    {
        triangleToFlip = temp;
    }

    public GameObject GetTriangleToFlip()
    {
        return triangleToFlip;
    }

    public void SetPlayChip(GameObject temp)
    {
        playChip = temp;
    }

    public GameObject GetPlayChip()
    {
        return playChip;
    }
}

public class TriangleNumber : MonoBehaviour
{
    [SerializeField]
    private int triangleNumber = 0;
    [SerializeField]
    private GameObject playingChip;
    [SerializeField]
    private string color = null;
    [SerializeField]
    private int numberPosition = 0;
    [SerializeField]
    private LayerMask chipLayers;

    private FlipInformation flipInfo = new FlipInformation();

    private  float c_AngleToTurn = 60;

    Vector3 debugCurrentAxis;
    float debugAngleToTurn;

    void Start()
    {
        flipInfo.SetPlayChip(playingChip);
        flipInfo.SetTriangleToFlip(gameObject);
    }

    public int GetNumber()
    {
        return triangleNumber;
    }

    public string GetColor()
    {
        return color;
    }

    //checking for collision with triangles that have a higher value then this triangle
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<TriangleNumber>() != null
            && color != collider.gameObject.GetComponent<TriangleNumber>().GetColor())
        {
            if (collider.gameObject.GetComponent<TriangleNumber>().GetNumber() > triangleNumber
                && collider.gameObject.GetComponent<TriangleNumber>()
                    .playingChip.GetComponent<PlayChipManager>().GetJustFlipped())
            {
                DebugFindNewAxis();
                playingChip.GetComponent<PlayChipManager>().SetCanFlip(true);
                playingChip.GetComponent<PlayChipManager>().AddPossibleFlips(flipInfo);

                #region Debug multi
                //Debug.Log(flipInfo.GetFlipAxis() + " " + GetColor());
                //Debug.Log("After SetCanFlip in TriangleNumer " + playingChip.GetComponent<PlayChipManager>().GetCanFlip());

                //finds axis that this triangle flips on and adds it to flipInfo

                //Adds this trianlge to possibleFlips in PlayChipManager
                //Debug.Log(playingChip.GetComponent<PlayChipManager>().PossibleFlipsCount()
                //    + " before adding to possibleFLips in PlayChipManager " + GameManager.Instance.GetTurn());

                //Debug.Log(playingChip.GetComponent<PlayChipManager>().GetPossibleFlips(0).GetFlipAxis());
                //Debug.Log(playingChip.GetComponent<PlayChipManager>().PossibleFlipsCount()
                //    + " After adding to possibleFLips in PlayChipManager " + GameManager.Instance.GetTurn());
                #endregion

            }
        }
    }

    public void DebugFindNewAxis()
    {
        debugCurrentAxis = playingChip.transform.right;
        debugAngleToTurn = (60 * numberPosition) + 30;

        float x = debugCurrentAxis.x;

        float z = debugCurrentAxis.z;

        debugCurrentAxis.x = x * Mathf.Cos(debugAngleToTurn * Mathf.Deg2Rad) + z * Mathf.Sin(debugAngleToTurn * Mathf.Deg2Rad);
        debugCurrentAxis.z = -x * Mathf.Sin(debugAngleToTurn * Mathf.Deg2Rad) + z * Mathf.Cos(debugAngleToTurn * Mathf.Deg2Rad);

        x = debugCurrentAxis.x;

        z = debugCurrentAxis.z;

        #region Debug draw ray
        //switch (numberPosition)
        //{
        //    case 1:
        //        Debug.DrawRay(playingChip.transform.position, debugCurrentAxis * 150, Color.white, 1);
        //        break;
        //    case 2:
        //        Debug.DrawRay(playingChip.transform.position, debugCurrentAxis * 150, Color.blue, 1);
        //        break;
        //    case 3:
        //        Debug.DrawRay(playingChip.transform.position, debugCurrentAxis * 150, Color.green, 1);
        //        break;
        //    case 4:
        //        Debug.DrawRay(playingChip.transform.position, debugCurrentAxis * 150, Color.magenta, 1);
        //        break;
        //    case 5:
        //        Debug.DrawRay(playingChip.transform.position, debugCurrentAxis * 150, Color.yellow, 1);
        //        break;
        //    case 6:
        //        Debug.DrawRay(playingChip.transform.position, debugCurrentAxis * 150, Color.gray, 1);
        //        break;
        //}
        #endregion

        debugCurrentAxis.x = x * Mathf.Cos(90 * Mathf.Deg2Rad) + z * Mathf.Sin(90 * Mathf.Deg2Rad);
        debugCurrentAxis.z = -x * Mathf.Sin(90 * Mathf.Deg2Rad) + z * Mathf.Cos(90 * Mathf.Deg2Rad);

        #region Debug draw ray
        //switch (numberPosition)
        //{
        //    case 1:
        //        Debug.DrawRay(playingChip.transform.position, debugCurrentAxis * 150, Color.white, 100);
        //        break;
        //    case 2:
        //        Debug.DrawRay(playingChip.transform.position, debugCurrentAxis * 150, Color.blue, 100);
        //        break;
        //    case 3:
        //        Debug.DrawRay(playingChip.transform.position, debugCurrentAxis * 150, Color.green, 100);
        //        break;
        //    case 4:
        //        Debug.DrawRay(playingChip.transform.position, debugCurrentAxis * 150, Color.magenta, 100);
        //        break;
        //    case 5:
        //        Debug.DrawRay(playingChip.transform.position, debugCurrentAxis * 150, Color.yellow, 100);

        //        break;
        //    case 6:
        //        Debug.DrawRay(playingChip.transform.position, debugCurrentAxis * 150, Color.gray, 100);
        //        break;
        //        //Debug.DrawRay(playingChip.transform.position, debugCurrentAxis * 150, Color.cyan, 35);
        //}
        #endregion

        flipInfo.SetFlipAxis(debugCurrentAxis);
    }
}
