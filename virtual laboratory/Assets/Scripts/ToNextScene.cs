using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ToNextScene : MonoBehaviour
{
    private int nextSceneToLoad;
    private void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        else
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene(nextSceneToLoad);
            }
        }
    }
    
}
