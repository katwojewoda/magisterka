using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Results : MonoBehaviour
{
    public Text time_1;
    public Text acc_1;
    public Text GetTime;

    private float acc;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        time_1.text = GetTime.text;
        acc = 9.81f * 1;
        acc_1.text = acc.ToString("F2");
    }
}
