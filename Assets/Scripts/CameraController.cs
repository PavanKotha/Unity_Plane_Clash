using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.Lerp(transform.position, player.position + player.forward * offset.z + player.up * offset.y, 5f * Time.deltaTime);
        transform.position = player.position + player.forward * offset.z + player.up * offset.y;
        transform.LookAt(player.position + player.forward*0.5f);
    }
}
