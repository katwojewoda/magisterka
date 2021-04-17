using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoUI : MonoBehaviour
{
    public GameObject InfoMenuUI;
    public static bool GamePause = false;
    private bool isInTrigger = false;
   
    
    int currentUiID = 0;
    public List<GameObject> UiObject;
    

   public void Next()
    {
    switch(currentUiID)
    {
        case 0:
                currentUiID = 1;
                EnableUi(1, 0);
            break;
        case 1:
                currentUiID = 2;
                EnableUi(2, 1);
            break;
        case 2:
                currentUiID = 3;
                EnableUi(3, 2);
            break;
        
        case 3:
                currentUiID = 0;
                EnableUi(1, 3);
            break;
    }
}

public void Previous()
{
        switch (currentUiID)
    {
        case 0:
                currentUiID = 3;
                EnableUi(3, 0);
        break;
        case 1:
                currentUiID = 0;
                EnableUi(0, 1);
        break;
        case 2:
                currentUiID = 1;
                EnableUi(1, 2);
        break;
        case 3:
                currentUiID = 2;
                EnableUi(2, 3);
        break;
        
    }
}

private void EnableUi(int newID, int previousID)
{
    UiObject[previousID].SetActive(false);
    UiObject[newID].SetActive(true);

}
private void OnTriggerStay(Collider other)
    {



    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        isInTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        isInTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInTrigger)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (GamePause == false)
                {
                 
                    Pause();
                }
            }
        }
    }
    public void Resume()
    {
         
        InfoMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePause = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Pause()
    {
        
        InfoMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePause = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void QuitGame()
    {
        Application.Quit();
    }    
}
