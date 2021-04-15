using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HangPendulum : MonoBehaviour
{
    private bool isInTrigger = false;
    private GameObject item;
    private GameObject lineParent;
    private GameObject hangingPoint;

    public GameObject playerParent;
    public GameObject LineL;
    public GameObject LineM;
    public GameObject LineS;
    public GameObject hPL;
    public GameObject hPM;
    public GameObject hPS;

    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        if (playerParent.transform.Find("weight1"))
        {
            item = playerParent.transform.Find("weight1").gameObject;            
        }
        else if (playerParent.transform.Find("weight2"))
        {
            item = playerParent.transform.Find("weight2").gameObject;            
        }

        if (LineS.activeSelf == true)
        {
            lineParent = LineS;
            hangingPoint = hPS;
        }
        if (LineM.activeSelf == true)
        {
            lineParent = LineM;
            hangingPoint = hPM;
        }
        if (LineL.activeSelf == true)
        {
            lineParent = LineL;
            hangingPoint = hPL;
        }

        isInTrigger = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        isInTrigger = false;
    }

    void Update()
    {
        if (isInTrigger)
        {            
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (lineParent.transform.childCount == 0)
                {
                    if (playerParent.transform.Find("weight1") || playerParent.transform.Find("weight2"))
                    {

                        item.GetComponent<Rigidbody>().useGravity = false;
                        item.GetComponent<Rigidbody>().isKinematic = true;
                        item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                        item.transform.position = hangingPoint.transform.position;
                        item.transform.parent = lineParent.transform;

                    }
                }
            }
        }
    }
}
