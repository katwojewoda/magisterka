using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRubber : MonoBehaviour
{
    public GameObject Rubber1;
    public GameObject Rubber2;
    
    private bool isInTrigger = false;
   
    private void OnTriggerStay(Collider other)
    {



    }
    private void OnTriggerEnter(Collider other)
    {
        isInTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isInTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInTrigger)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (Rubber1.activeSelf == true)
                {
                    Rubber1.SetActive(false);
                    Rubber2.SetActive(true);
                    
                }

                else
                {
                    Rubber2.SetActive(false);
                    Rubber1.SetActive(true);

                }
            }
        }
    }
}
