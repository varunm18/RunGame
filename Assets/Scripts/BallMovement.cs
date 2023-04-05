using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    float delay;
    float time;
    bool canJump;

    float rotDelay;
    float rotTime;
    bool canRotate;
    float grav;
    // Start is called before the first frame update
    void Start()
    {
        delay = 0.75f;
        time = 0f;
        canJump = true;

        rotDelay = 1.4f;
        rotTime = 0f;
        canRotate = true;
        grav = -1;
        Physics.gravity = new Vector3(0, 20f * grav, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        if (transform.position.y < -0.7f || transform.position.y > 10.5f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            grav = -1;
            canJump = true;
            canRotate = true;
            time = 0;
            rotTime = 0;
            Physics.gravity = new Vector3(0, 20f * grav, 0);
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.left * 0.1f, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.right * 0.1f, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.Space)&&canRotate)
        {
            grav = -grav;
            Physics.gravity = new Vector3(0, 20f*grav, 0);
            canRotate = false;
        }

        if (rotTime > rotDelay)
        {
            canRotate = true;
            rotTime = 0;
        }

        if (!canRotate)
        {
            rotTime += Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow)&&canJump)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 500f * -grav);
            Debug.Log(-grav);
            canJump = false;
        }

        if (time > delay)
        {
            canJump = true;
            time = 0;
        }

        if (!canJump)
        {
            time += Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Obstacle")||collision.gameObject.tag.Equals("Obstacle2"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            grav = -1;
            canJump = true;
            canRotate = true;
            time = 0;
            rotTime = 0;
            Physics.gravity = new Vector3(0, 9.8f * grav, 0);
        }
    }
}
