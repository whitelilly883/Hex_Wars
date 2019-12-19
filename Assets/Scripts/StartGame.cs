using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void StartLoading()
    {
        StartCoroutine(StartGameLoad());
    }

    public IEnumerator StartGameLoad()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Ngon");

        while(!asyncLoad.isDone)
        {
            yield return null; 
        }
    }
}
