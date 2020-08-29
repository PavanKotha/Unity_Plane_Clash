using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstacle;
    private MeshRenderer meshRenderer;
    public int maxHeight = 30;
    public int length = 4;
    public int width = 4;
    public int groundScaleX;
    public int groundScaleZ;

    private void Awake()
    {
        groundScaleX = (int)transform.localScale.x*10;
        groundScaleZ = (int)transform.localScale.z*10;
        for(int i=0; i < (groundScaleX / length);)
        {
            for (int j = 0; j < groundScaleZ / width;)
            {
                int height = Random.Range(1, maxHeight);
                Vector3 position = new Vector3((i+0.5f) * length , height / 2, (j+0.5f) * width );
                
                GameObject new_obstacle = Instantiate(obstacle, position, Quaternion.identity);
                new_obstacle.transform.localScale = new Vector3(length,height,width);
                new_obstacle.transform.parent = gameObject.transform;
                meshRenderer = new_obstacle.GetComponent<MeshRenderer>();
                int rand = Random.Range(0, 3);
                switch (rand)
                {
                    case (0):
                        meshRenderer.material.color = Color.black;
                        break;
                    case (1):
                        meshRenderer.material.color = Color.white;
                        break;
                    case (2):
                        meshRenderer.material.color = Color.grey;
                        break;
                }

                int rand_j = Random.Range(2, 5);
                j += rand_j;
               
            }
            int rand_i = Random.Range(1, 6);
            i += rand_i;
        }
    }


}
