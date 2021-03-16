using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowText_hang : MonoBehaviour
{
    public GameObject playerParent;
    public GameObject UiObject;
    // Start is called before the first frame update
    void Start()
    {
        UiObject.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if(playerParent.transform.Find("weight1") || playerParent.transform.Find("weight2") || playerParent.transform.Find("weight3")) UiObject.SetActive(true);

    }
    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        UiObject.SetActive(false);

    }
}
