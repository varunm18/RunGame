using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{

    public GameObject prefab;
    public GameObject obstacle;
    public GameObject obstacle2;
    // Start is called before the first frame update
    void Start()
    {
        if (!tag.Equals("Start"))
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (Random.Range(1, 10) == 4)
                    {
                        Destroy(gameObject.transform.GetChild(i).GetChild(j).gameObject);
                    }
                    else if (Random.Range(1, 30) == 10)
                    {
                        if (transform.position.y == 0)
                        {
                            Instantiate(obstacle, gameObject.transform.GetChild(i).GetChild(j).transform.position, obstacle.transform.rotation);
                        }
                        else
                        {
                            Instantiate(obstacle2, gameObject.transform.GetChild(i).GetChild(j).transform.position, obstacle.transform.rotation);
                        }
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * 0.02f);
        if (tag.Equals("Start"))
        {
            if (transform.position.z < -7f)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (transform.position.z < -1.4f)
            {
                if (transform.position.y == 0)
                {
                    Instantiate(prefab, new Vector3(0, 0, 94), transform.rotation);
                }
                else
                {
                    Instantiate(prefab, new Vector3(0, 7, 94), transform.rotation);
                }
                Destroy(gameObject);
            }
        }
    }
}
