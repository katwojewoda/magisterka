using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InclineDown : MonoBehaviour
{
    public GameObject InclineH;
    public GameObject InclineM;
    public GameObject InclineS;
    private bool isInTrigger = false;
    // Start is called before the first frame update

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
                if (InclineH.activeSelf == true)
                {
                    InclineH.SetActive(false);
                    InclineM.SetActive(true);
                    InclineS.SetActive(false);
                }

              else
              {
                    InclineH.SetActive(false);
                   InclineM.SetActive(false);
                  InclineS.SetActive(true);
                }
            }
        }
    }

}
