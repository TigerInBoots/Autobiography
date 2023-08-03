using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Get outta heeeere!");
                break;
            case "Finish":
                if (SceneManager.GetActiveScene().buildIndex != 1)
                {
                    NextLevel();
                }
                else
                {
                    EndingLevel();
                }
                break;
            default:
                ReloadLevel();
                break;

        }
    }
    
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //Gets current scene Index.
        SceneManager.LoadScene(currentSceneIndex);
        //Loads current scene Index
    }

    void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //Gets current scene Index.
        SceneManager.LoadScene(currentSceneIndex + 1);
        //Loads next scene Index
    }
    
    void EndingLevel()
    {
        SceneManager.LoadScene(0);
    }
}
