using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HangWeights : MonoBehaviour
{
    private GameObject item;
    public GameObject playerParent;
    public GameObject dynamoParent;
    public GameObject HangingPoint;
    public GameObject Rubber1;
    public GameObject Rubber2;

    private bool isInTrigger = false;
    Vector3 startHangingPoint;
    private float mass = 0f;
    private float Q = 0f;
    private float x0;
    private float itemHeight;
    public Text dynamoText;

    public Text QText_1;
    public Text x0Text_1;

    public Text QText_2;
    public Text x0Text_2;

    public Text QText_3;
    public Text x0Text_3;

    // Start is called before the first frame update
    void Start()
    {
        startHangingPoint = HangingPoint.transform.position;
    }

        private void OnTriggerEnter(Collider other)
    {
        isInTrigger = true;
        if (!other.CompareTag("Player")) return;        

        if (playerParent.transform.Find("weight1"))
        {
            item = playerParent.transform.Find("weight1").gameObject;
            itemHeight = 2f;
        }
        if (playerParent.transform.Find("weight2"))
        {
            item = playerParent.transform.Find("weight2").gameObject;
            itemHeight = 2.5f;
        }
        if (playerParent.transform.Find("weight3"))
        {
            item = playerParent.transform.Find("weight3").gameObject;
            itemHeight = 3.0f;
        }
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
                if (playerParent.transform.Find("weight1") || playerParent.transform.Find("weight2") || playerParent.transform.Find("weight3"))
                {
                    
                    item.GetComponent<Rigidbody>().useGravity = false;
                    item.GetComponent<Rigidbody>().isKinematic = true;
                    item.transform.position = new Vector3(HangingPoint.transform.position.x, HangingPoint.transform.position.y - 0.425f, HangingPoint.transform.position.z);
                    HangingPoint.transform.position = new Vector3(HangingPoint.transform.position.x, HangingPoint.transform.position.y - itemHeight, HangingPoint.transform.position.z);
                    item.transform.parent = dynamoParent.transform;
                    
                    for (int i = 0; i < dynamoParent.transform.childCount; i++)
                     {
                       GameObject child = dynamoParent.transform.GetChild(i).gameObject;
                       mass = mass + child.GetComponent<Rigidbody>().mass;
                     }
                    Q = mass * 9.81f;  
                    dynamoText.text = Q.ToString("F1");
                    if (Rubber1.activeSelf == true)
                    {
                        x0= Q / 0.3f;
                    }
                    if (Rubber2.activeSelf == true)
                    {
                        x0= Q / 0.7f;
                    }
                    mass = 0f; 

                }
            }
            
        }
        if (Input.GetKeyDown(KeyCode.G))
            {
                HangingPoint.transform.position = startHangingPoint;
                mass = 0f;
                dynamoText.text = "0.00";
            }
    }

   
}
