using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject UiObject_text;
    public GameObject UiObject_camera;
    public GameObject UiObject_key;
    public GameObject incline_s;
    public GameObject incline_m;
    public GameObject incline_h;
    public Text timerText;
    bool hide = false;
    private float startTime;
    private float time0;
    private bool isInTrigger = false;
    
    public Text time_1;
    public Text vk_1;
   
    public Text time_2;
    public Text vk_2;

    private float acc;
    private float vk;
    private float f = 0.12f;
    private float g = 9.81f;
    private float alpha;
    private float h;


    // Start is called before the first frame update
    void Start()
    {
        acc = 0f;
        vk = 0f;
        time0 = startTime;
        timerText.text = startTime.ToString("F2");
        time_1.text = startTime.ToString("F2");
        vk_1.text = vk.ToString("F2");
        time_2.text = startTime.ToString("F2");
        vk_2.text = vk.ToString("F2");
        if (incline_h.activeSelf == true)
        {
            alpha = 32.7f;
            h = 5.8f * 1.6f;
        }
        else if (incline_m.activeSelf == true)
        {
            alpha = 26.6f;
            h = 4.65f * 1.6f;
        }
        else if (incline_s.activeSelf == true)
        {
            alpha = 16.1f;
            h = 2.91f * 1.6f;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (!(other.CompareTag("car1") || other.CompareTag("car"))) return;
            isInTrigger = true;

    }

    private void OnTriggerExit(Collider other)
    {
        isInTrigger = false;
        if (!other.CompareTag("car1"))
        {
            vk = 17f / startTime;
            time_1.text = startTime.ToString("F2");
                                  
            vk_1.text = vk.ToString("F2");
        }
        if (!other.CompareTag("car"))
        {
            vk = 17f / startTime;
            time_2.text = startTime.ToString("F2");
            
            vk_2.text = vk.ToString("F2");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInTrigger == true)
        {
           
            UiObject_text.SetActive(false);
            UiObject_camera.SetActive(true);
            startTime += Time.deltaTime;
            timerText.text = startTime.ToString("F2");            
        }
        
        if (isInTrigger == false)
        {
            
            if (Input.GetKeyDown(KeyCode.T))
            {
                timerText.text = time0.ToString("F2");
                startTime = time0;
            } 
            UiObject_text.SetActive(true);
            UiObject_camera.SetActive(false);
            
        }

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
