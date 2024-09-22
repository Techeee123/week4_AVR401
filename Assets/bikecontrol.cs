using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bikecontrol : MonoBehaviour
{
    public WheelJoint2D wheeljoint;

    public float bikeSpeed = 250f;
    public float bikeTorqForce = 100f;

    float bikemovement;
    float bikeTorq;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        bikemovement = -Input.GetAxis("Horizontal") * bikeSpeed;
        bikeTorq = Input.GetAxis("Vertical") * bikeTorqForce;

        Debug.Log(bikemovement);
    }

    private void FixedUpdate()
    {
        if (bikemovement != 0)
        {

            wheeljoint.motor = new JointMotor2D { motorSpeed = bikemovement, maxMotorTorque = 10000 };
        }
        else
        {
            wheeljoint.useMotor = false;
        }


        rb.AddTorque(bikeTorq);
    }
}
