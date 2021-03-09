using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject UiObject_text;
    public GameObject UiObject_camera;
    public GameObject UiObject_key;
    public Text timerText;
    bool hide = false;
    private float startTime;
    private float time0;
    private bool isInTrigger = false;
    bool timerActive = false;

    public Text time_1;
    public Text vk_1;
   
    public Text time_2;
    public Text vk_2;

    private float acc;
    private float vk;


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
    }
    private void OnTriggerEnter(Collider other)
    {
       isInTrigger = true;

    }

    private void OnTriggerExit(Collider other)
    {
        isInTrigger = false;
        if (!other.CompareTag("cube"))
        {
            time_1.text = startTime.ToString("F2");
            acc = Mathf.Sqrt(startTime) / 2 * 13.58f;
            vk = Mathf.Sqrt(2 * acc * 13.58f);
            vk_1.text = vk.ToString("F2");
        }
        if (!other.CompareTag("car"))
        {
            time_2.text = startTime.ToString("F2");
            acc = Mathf.Sqrt(startTime) / 2 * 13.58f;
            vk = Mathf.Sqrt(2 * acc * 13.58f);
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
