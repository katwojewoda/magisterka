using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum2 : MonoBehaviour
{
   // public static pendul instance;
    Quaternion start, end;
    public float angle0;
    public float v;
    public float timpStart = 0;
    private float angle;
    private bool isInTrigger = false;
    private bool measure = false;

    public GameObject playerParent;
    public GameObject lineParent;

    // Use this for initialization
    void Start()
    {
        start = PendulRote(angle0);
        end = PendulRote(-angle0);
        angle = angle0;
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
   
    private void FixedUpdate()
    {
        if (measure == true)
        {
            GameObject varGameObject = GameObject.Find("weight1");
            varGameObject.GetComponent<PickUp>().enabled = false;

            GameObject varGameObject2 = GameObject.Find("weight2");
            varGameObject2.GetComponent<PickUp>().enabled = false;

            timpStart += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(start, end, (Mathf.Sin(timpStart * v + Mathf.PI / 2) + 1.0f) / 2.0f);
            if (angle != angle0)
            {
                start = PendulRote(angle0);
                end = PendulRote(-angle0);
                angle = angle0;
            }
        }
        if (measure == false)
        {

            GameObject varGameObject = GameObject.Find("weight1");
            varGameObject.GetComponent<PickUp>().enabled = true;

            GameObject varGameObject2 = GameObject.Find("weight2");
            varGameObject2.GetComponent<PickUp>().enabled = true;
            transform.rotation = Quaternion.identity;
        }
    }
    void Update()
    {
        if (isInTrigger)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (lineParent.transform.childCount == 1)
                {
                    measure = !measure;
                }
            }
        }
        

    }


    void ResetTimer()
    {
        timpStart = 0;
    }

    Quaternion PendulRote(float angle)
    {
        var PendulRote = transform.rotation;
        var angleZ = PendulRote.eulerAngles.z + angle;
        if (angleZ > 180) angleZ -= 360;
        else if (angleZ < -180) angleZ += 360;
        PendulRote.eulerAngles = new Vector3(PendulRote.eulerAngles.x, PendulRote.eulerAngles.y, angleZ);
        return PendulRote;
    }
}