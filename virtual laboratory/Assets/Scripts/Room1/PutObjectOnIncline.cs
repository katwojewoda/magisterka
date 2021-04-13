using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutObjectOnIncline : MonoBehaviour
{

    private bool isInTrigger = false;
    public GameObject start;
    public GameObject destinationM;
    public GameObject destinationH;
    public GameObject destinationS;
    public GameObject inM;
    public GameObject inH;
    public GameObject inS;
    public GameObject item;

    // Start is called before the first frame update


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
                transform.position = start.transform.position;
                transform.rotation = start.transform.rotation;
                item.GetComponent<Rigidbody>().isKinematic = true;
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                item.GetComponent<Rigidbody>().isKinematic = false;
                if (inH.activeSelf == true)
                {
                    transform.position = destinationH.transform.position;
                    transform.rotation = destinationH.transform.rotation;
                }
                if (inM.activeSelf == true)
                {
                    transform.position = destinationM.transform.position;
                    transform.rotation = destinationM.transform.rotation;
                }
                if (inS.activeSelf == true)
                {
                    transform.position = destinationS.transform.position;
                    transform.rotation = destinationS.transform.rotation;
                }
            }
        }
    }


}

