using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float pitchSpeed = 50f;
    [SerializeField]
    private float yawSpeed = 50f;
    [SerializeField]
    private float rollSpeed = 50f;
    [SerializeField]
    private float maxRollAngle = 30f;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * speed;
        yaw();
    }

    public void Pitch(float verticalInput)
    {
        //Debug.Log("Pitch called");
        transform.Rotate(verticalInput * pitchSpeed * Time.deltaTime, 0f, 0f);
    }

    public void Roll(float horizontalInput)
    {

        float z_rotation = transform.rotation.eulerAngles.z;
        if (z_rotation > 180) z_rotation = z_rotation - 360;

        if ((z_rotation > -maxRollAngle || horizontalInput < 0) && (z_rotation < maxRollAngle || horizontalInput > 0))
            {
            //Debug.Log("Rotated");
            transform.Rotate(0f, 0f, -horizontalInput * rollSpeed * Time.deltaTime);
        }


        
    }
    private void yaw()
    {
        float roll_angle  = 90 - Vector3.Angle(Vector3.up, transform.right);

        
        transform.Rotate(0f, -(roll_angle/180f) * yawSpeed * Time.deltaTime, 0f, Space.World);
        
    }

   
}
