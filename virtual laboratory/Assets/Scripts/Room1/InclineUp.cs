using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InclineUp : MonoBehaviour
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
                if (InclineM.activeSelf == true)
                {
                    InclineH.SetActive(true);
                    InclineM.SetActive(false);
                    InclineS.SetActive(false);
                }

                if (InclineS.activeSelf == true)
                {
                   InclineH.SetActive(false);
                   InclineM.SetActive(true);
                    InclineS.SetActive(false);
                }
            }
        }
    }
    

}
