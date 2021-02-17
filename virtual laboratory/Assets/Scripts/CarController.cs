using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    public List<WheelCollider> throttleWheels;
    public List<GameObject> steeringWheels;
    public float strenghtCoefficient = 10000f;
    public float maxTurn = 20f;
    public Transform CM;
    public Rigidbody rb;

    public List<GameObject> meshes;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(CM)
        {
           //rb.centerOfMass = CM.position;

        }
    }

    
    void FixedUpdate()
    {
        foreach (WheelCollider wheel in throttleWheels)
        {
            //swheel.motorTorque = strenghtCoefficient * Time.deltaTime; 
        }

        foreach (GameObject wheel in steeringWheels)
        {
            //wheel.steerAngle = maxTurn; 
            //wheel.transform.localEulerAngles = new Vector3(maxTurn, 0f, 0f);
        }

        foreach(GameObject mesh in meshes)
        {
            mesh.transform.Rotate(rb.velocity.magnitude * (transform.InverseTransformDirection(rb.velocity).z >= 0 ? 1 : -1) / (2 * Mathf.PI * 0.4f),0f,0f);
        }
    }
}
