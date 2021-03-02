using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInformations : MonoBehaviour
{
    public GameObject UiObject;
    private bool isInTrigger = false;
        
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        isInTrigger = true;

    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        isInTrigger = false;
        UiObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        UiObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isInTrigger)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                UiObject.SetActive(true);
            }
        }
    }
}
