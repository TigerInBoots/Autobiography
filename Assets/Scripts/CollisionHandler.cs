using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                Debug.Log("You Win!");
                break;
            default:
                Debug.Log("OOF, you died.");
                break;

        }
    }
}
