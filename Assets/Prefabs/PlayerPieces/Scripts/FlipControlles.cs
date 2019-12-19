using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipControlles : MonoBehaviour
{
    public bool rotating = false;
    public float rotationSpeed = 30;

    private float rotationAmount = 0;
    private float deltaError;
    private WaitForSecondsRealtime frameRate;

    void Start()
    {
        frameRate = new WaitForSecondsRealtime(1 / 60f);
    }

    public void FlipChip()
    {
        StartCoroutine(FlipChipRun());
    }

    public IEnumerator FlipChipRun()
    {
        Debug.Log("Inside Ienumerator flipcontrolles");

        Vector3 rotationAxis = GetComponent<PlayChipManager>().GetPossibleFlips(0).GetFlipAxis();
        float trial = 0;

        rotating = true;
        rotationAmount = 0;

        while (rotating)
        {
            if (trial < 180f)
            {
                float deltaRotation = rotationSpeed * Time.deltaTime;
                rotationAmount += deltaRotation;
                Debug.Log(rotationAmount + " rotationAmount after update with deltaRotation");

                Debug.Log(transform.localRotation + " rotationAmount for rotation");
                //.RotateAroundLocal() is out of date use RotateAround(object position, rotation axis, rotation amount) instead;
                transform.RotateAround(transform.position, rotationAxis, deltaRotation);
                trial += deltaRotation;
            }
            else
            {
                deltaError = rotationAmount - 180;
                transform.RotateAround(transform.position, rotationAxis, -deltaError);
                rotationAmount = 0;
                rotating = false;
            }
            yield return frameRate;
        }
        GetComponent<PlayChipManager>().CheckColliders();
    }
}
