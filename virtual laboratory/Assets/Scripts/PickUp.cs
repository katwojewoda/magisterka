using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    public GameObject item;
    public GameObject putBack;
    public GameObject tempParent; 
    public Transform guide; 
    bool carrying;
    public float range = 4;
    public GameObject UiObject;
    public GameObject UiObject_PickUp;

    // Start is called before the first frame update
    void Start()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
        UiObject.SetActive(false);
        UiObject_PickUp.SetActive(false);
    }

    
    // Update is called once per frame
    void Update()
    {
       
            if (carrying == false && (guide.transform.position - transform.position).sqrMagnitude < range * range)
            {
                UiObject_PickUp.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                     UiObject_PickUp.SetActive(false);
                     pickup();
                    carrying = true;

                }
            }
       
       else if (carrying == true)
        {
            UiObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.G))
            {
                drop();
                carrying = false;
                UiObject.SetActive(false);
            }
        }


    }
    void pickup()
    {
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.position = guide.transform.position;
        item.transform.rotation = guide.transform.rotation;
        item.transform.parent = tempParent.transform;
    }
    void drop()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.transform.parent = null;
        item.transform.position = putBack.transform.position;
        item.transform.rotation = putBack.transform.rotation;
    }
}
