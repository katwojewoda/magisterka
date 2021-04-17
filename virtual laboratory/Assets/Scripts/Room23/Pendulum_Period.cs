using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pendulum_Period : MonoBehaviour
{
    public GameObject UiObject_text;
    public GameObject UiObject_key;
    public Text timerText;
    public Text counterText;
    bool hide = false;
    private float startTime;
    private float time0 = 0;
    private int counter = -1;
    bool measuring = false;

    public Text timeres;
    public Text counterres;
    public Text timeres_red;
    public Text counterres_red;
    public GameObject lineParent;
    private float stopTime;
    private bool isInTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (!(other.CompareTag("ball") || other.CompareTag("ball_red"))) return;
        measuring = true;
        counter = counter + 1;
        isInTrigger = true;

    }
    private void OnTriggerExit(Collider other)
    {
        if (!(other.CompareTag("ball") || other.CompareTag("ball_red"))) return;
        isInTrigger = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        startTime = time0; 
    }

    // Update is called once per frame
    void Update()
    {
        

        if (counter <= 5 && counter >= 0)
        {
            measuring = true;
            UiObject_text.SetActive(false);
            startTime += Time.deltaTime;
            timerText.text = startTime.ToString("F2");
            counterText.text = counter.ToString("");
            stopTime = startTime; 
        }
        if (counter == 5 && isInTrigger == true)
        {   

            if (lineParent.transform.Find("weight1"))
            {
                timeres.text = stopTime.ToString("F1");
                counterres.text = counter.ToString("");
            }
            else if (lineParent.transform.Find("weight2"))
            {
                timeres_red.text = stopTime.ToString("F1");
                counterres_red.text = counter.ToString("");
            }
        }

        if (counter >5)
        {
            measuring = false;
            startTime = time0;
            
            counter = 0;
        }



        if (Input.GetKeyDown(KeyCode.T))
            {
                counter = -1;
                measuring = false;
                timerText.text = time0.ToString("F1");           
                counterText.text = 0.ToString();
            
            startTime = time0;
            }

            UiObject_text.SetActive(true);
            

      

        if (Input.GetKeyDown(KeyCode.R))
        {
            hide = !hide;
            if (hide)
            {
                UiObject_key.SetActive(false);
            }
            else UiObject_key.SetActive(true);
        }


    }
}
