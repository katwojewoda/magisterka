using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject destination;
    public Text timerText;
    private float startTime;

    bool timerActive = false;

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = startTime.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            startTime += Time.deltaTime;
            timerText.text = startTime.ToString("F2");
        }

          (transform.position == destination.transform.position) && (transform.rotation == destination.transform.rotation)      
    }
}
