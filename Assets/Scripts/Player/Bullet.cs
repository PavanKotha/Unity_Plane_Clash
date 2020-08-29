using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public Rigidbody rb;

    
    public void setVelocity(float speed)
    {
        Debug.Log("SetVelocity Called");
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }


}
