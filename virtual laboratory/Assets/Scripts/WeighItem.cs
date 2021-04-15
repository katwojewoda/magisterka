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
    public Text scaleText;
    public Text res_weight_1;
    public Text res_weight_2;
    public Text res_weight_3;
    private Text res;
    private float mass;    
    bool weighting;
    public GameObject UiObject_res;
    public GameObject UiObject_table;
    public GameObject UiObject_htable;
    bool hide = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        isInTrigger = true;
       
        if (playerParent.transform.Find("weight1")) 
        { 
          item = playerParent.transform.Find("weight1").gameObject;
            res = res_weight_1;
        }
        if (playerParent.transform.Find("weight2"))
        {
            item = playerParent.transform.Find("weight2").gameObject;
            res = res_weight_2;
        }
        if (playerParent.transform.Find("weight3"))
        {
            item = playerParent.transform.Find("weight3").gameObject;
            res = res_weight_3;
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
        if (isInTrigger )
        {
            if (weighting == false && scaleParent.transform.childCount < 2)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    placeOnScale();
                    weighting = true;
                    mass = item.GetComponent<Rigidbody>().mass;
                    scaleText.text = mass.ToString("F2");
                    res.text = scaleText.text;

                }
                
            }
            else if (weighting == true)
            {
                if (Input.GetKeyDown(KeyCode.F) && playerParent.transform.childCount < 4)
                {
                    pickUp();
                    weighting = false;
                    scaleText.text = "00.00";
                    item = null;
                }
                
            }
        }
        if (weighting == true && Input.GetKeyDown(KeyCode.G))
        {
            weighting = false;
            scaleText.text = "00.00";
            item = null;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            hide = !hide;
            if (hide)
            {
                UiObject_res.SetActive(false);
                UiObject_table.SetActive(true);
                UiObject_htable.SetActive(false);
            }
            else
            {
                UiObject_res.SetActive(true);
                UiObject_table.SetActive(false);
                UiObject_htable.SetActive(true);
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
