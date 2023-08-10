using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float reloadDelay = 1f;

    void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Get outta heeeere!");
                break;

            case "Finish":
                StartLevelSequence();
                break;

            default:
                StartCrashSequence();
                break;

        }
    }
    

    void StartCrashSequence()
    {
        //add SFX upon crash
        //add particle effect upon crash
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", reloadDelay);
    }

    void StartLevelSequence()
    {
        //add SFX upon success
        //add particle effect upon success
        GetComponent<Movement>().enabled = false;
        Invoke("NextLevel", reloadDelay);
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
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
        //Loads next scene Index
    }
    
}
