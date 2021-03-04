using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeighItem : MonoBehaviour
{
    private bool isInTrigger = false;
    public GameObject item;
    public GameObject scaleParent;
    public Transform scaleGuide;
    public GameObject playerParent;
    public Transform playerGuide;
    public GameObject UiObject_text;
    public Text scaleText;
    private float mass;    
    bool weighting;



    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        isInTrigger = true;
       
        if (playerParent.transform.Find("weight1")) 
        { 
          item = playerParent.transform.Find("weight1").gameObject;
        }
        if (playerParent.transform.Find("weight2"))
        {
            item = playerParent.transform.Find("weight2").gameObject;
        }
        if (playerParent.transform.Find("weight3"))
        {
            item = playerParent.transform.Find("weight3").gameObject;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        isInTrigger = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInTrigger)
        {
            if (weighting == false)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    placeOnScale();
                    weighting = true;
                    mass = item.GetComponent<Rigidbody>().mass;
                    scaleText.text = mass.ToString("F2");
                }
            }
            else if (weighting == true)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    pickUp();
                    weighting = false;
                    scaleText.text = "00.00";
                    item = null;
                }
            }
        } 
    }
    void placeOnScale()
    {
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.position = scaleGuide.transform.position;
        item.transform.rotation = scaleGuide.transform.rotation;
        item.transform.parent = scaleParent.transform;
    }
    void pickUp()
    {
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.position = playerGuide.transform.position;
        item.transform.rotation = playerGuide.transform.rotation;
        item.transform.parent = playerParent.transform;
    }
}
