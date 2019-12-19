using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenue : MonoBehaviour
{

    public void ReturnToMainMenue()
    {
        StartCoroutine(LoadToMainMenue());
    }

    public IEnumerator LoadToMainMenue()
    {
        GameManager.Instance.Reset();
        ChipObserver.Instance.Reset();
        MouseClickGlobal.count = 0;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainMenue");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
   
    }
}