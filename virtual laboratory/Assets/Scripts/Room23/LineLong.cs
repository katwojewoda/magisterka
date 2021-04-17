using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineLong : MonoBehaviour
{
    public GameObject LineL;
    public GameObject LineM;
    public GameObject LineS;
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
                if (LineM.activeSelf == true)
                {
                    if (LineM.transform.childCount == 0)
                    {
                        LineL.SetActive(true);
                        LineM.SetActive(false);
                        LineS.SetActive(false);
                    }
                }

                else if (LineS.activeSelf == true)
                {
                    if (LineS.transform.childCount == 0)
                    {
                        LineL.SetActive(false);
                        LineM.SetActive(true);
                        LineS.SetActive(false);
                    }
                }
            }
        }
    }

}
