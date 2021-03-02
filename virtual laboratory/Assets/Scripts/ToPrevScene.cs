using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToPrevScene : MonoBehaviour
{
    private int prevSceneToLoad;
    private void Start()
    {
        prevSceneToLoad = SceneManager.GetActiveScene().buildIndex - 1;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        else
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene(prevSceneToLoad);
            }
        }
    }

}
