using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private int nextSceneLoad;
    public void Next()
    {
        
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex+1;
        if (nextSceneLoad > 5)
        {
            SceneManager.LoadScene("LEVEL0");
        }
        else
        {
            SceneManager.LoadScene(nextSceneLoad);
        }
        
        
    }

    public void Retry()
    {
        Scene scene = SceneManager.GetActiveScene();
        
        SceneManager.LoadScene(scene.name);
    }
}
