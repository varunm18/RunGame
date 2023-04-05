using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    float y = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (tag.Equals("Obstacle"))
        {
            y = 0.5f;
        }
        else
        {
            y = 6.5f;
        }
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * 0.02f);
    }
}
