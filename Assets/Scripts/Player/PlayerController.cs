using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public PlayerMotor motor;
    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") != 0f)
        {
            motor.Pitch(Input.GetAxis("Vertical"));
            
        }
        if (Input.GetAxis("Horizontal") != 0f)
        {
            motor.Roll(Input.GetAxis("Horizontal"));
        }
    }
}
