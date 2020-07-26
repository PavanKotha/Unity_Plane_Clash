using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ObstanceVisibility : MonoBehaviour
{
    public Transform player;
    private MeshRenderer meshRenderer;
    private Color oldColor;
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    // Update is called once per frame
    void Update()
    { 
        if (player.position.z > transform.position.z-transform.localScale.z/2)
        {
            ToggleVisibility();
        }

    }
    private void ToggleVisibility()
    {
        if (meshRenderer.material.color.a == 1f)
        {
            oldColor = meshRenderer.material.color;
            meshRenderer.material.color = new Color(oldColor.r, oldColor.g, oldColor.b,0.3f);
        }
            
    }

}
