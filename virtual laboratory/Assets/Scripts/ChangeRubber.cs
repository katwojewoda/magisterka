using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeRubber : MonoBehaviour
{
    public GameObject Rubber1;
    public GameObject Rubber2;
    public Text dynamoText;

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
            if (dynamoText.text == "00.00")
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
}
