using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMass : MonoBehaviour
{
    private float mass;
    public float min;
    public float max;
    public Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {   
        mass = Random.Range(min, max);
        rb = GetComponent<Rigidbody>();
        rb.mass = mass;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
