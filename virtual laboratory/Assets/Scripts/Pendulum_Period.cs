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
    private float time0;
    private int counter = -1;
    bool measuring = false;

    public Text time1res;
    public Text counterres1;
    private float stopTime;

    private void OnTriggerEnter(Collider other)
    {
        if (!(other.CompareTag("ball") || other.CompareTag("ball_red"))) return;
        measuring = true;
        counter = counter + 1;
        

    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (counter < 11 && counter >= 0)
        {
            measuring = true;
            UiObject_text.SetActive(false);
            startTime += Time.deltaTime;
            timerText.text = startTime.ToString("F2");
            counterText.text = counter.ToString("");
            stopTime = startTime; 
        }

        if (counter > 10)
        {
            measuring = false;
            startTime = time0;
            time1res.text = stopTime.ToString("F2");
            counterres1.text = (counter-1).ToString("");
            counter = 0;
        }



        if (Input.GetKeyDown(KeyCode.T))
            {
                counter = -1;
                measuring = false;
                timerText.text = time0.ToString("F2");                
                counterres1.text = (counter - 1).ToString();
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
