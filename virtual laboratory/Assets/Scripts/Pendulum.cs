using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pendulum : MonoBehaviour
{
    float timer = 0f;
    public float speed;
    int phase = 0;

    private bool isInTrigger = false;
    private bool measure = false;
    
    public GameObject playerParent;
    public GameObject lineParent;
    
   
    void Start()
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

    void FixedUpdate()
    {
        if (measure == true)
        {
            timer += Time.fixedDeltaTime;
            if (timer > 1f)
            {
                phase++;
                phase %= 4;
                timer = 0f;
            }

            switch (phase)
            {
                case 0:
                    transform.Rotate(0f, 0f, speed * (1 - timer));  //Speed, from maximum to zero.
                    break;
                case 1:
                    transform.Rotate(0f, 0f, -speed * timer);       //Speed, from zero to maximum.
                    break;
                case 2:
                    transform.Rotate(0f, 0f, -speed * (1 - timer)); //Speed, from maximum to zero.
                    break;
                case 3:
                    transform.Rotate(0f, 0f, speed * timer);        //Speed, from zero to maximum.
                    break;
            }
        }
        if (measure == false)
        {
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
}
