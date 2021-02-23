using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutObjectOnIncline : MonoBehaviour
{
   
    private bool isInTrigger = false;
    public GameObject start;
    public GameObject destination;
    
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
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                 transform.position = destination.transform.position;
                 transform.rotation = destination.transform.rotation;
            }
       }
    }


}

