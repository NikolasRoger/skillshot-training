using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;
    private Vector3 cameraOffset;

    private bool follow;

    [Range(0.01f, 1.0f)]
    public float smoothness = 0.5f;

    public float camSpeed = 20;
    public float screenSizeThickness;

    // Start is called before the first frame update
    void Start()
    {
        follow = true;
        screenSizeThickness = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(!player) {
            if(GameObject.FindGameObjectWithTag("Player")) {
                player = GameObject.FindGameObjectWithTag("Player").gameObject;
                cameraOffset = transform.position - player.transform.position;
            }
        } else {
            if(follow) {
                Vector3 newPos = player.transform.position + cameraOffset;
                transform.position = Vector3.Slerp(transform.position, newPos, smoothness);
            }
            if(Input.GetKeyDown(KeyCode.Y))
            {
                follow = follow == true ? false : true;
            }

            if(!follow)
            {
                if(Input.GetKey(KeyCode.Space))
                {
                    Vector3 newPos = player.transform.position + cameraOffset;
                    transform.position = Vector3.Slerp(transform.position, newPos, smoothness);
                } else {
                    MovementCamera();
                }
            }
        }
    }

    void MovementCamera()
    {
        Vector3 pos = transform.position;

        //Up
        if (Input.mousePosition.y >= Screen.height - screenSizeThickness)
        {
            pos.x -= camSpeed * Time.deltaTime;

            //OR
            //pos.z += camSpeed * Time.deltaTime;
        }

        //Down
        if (Input.mousePosition.y <= screenSizeThickness)
        {
            pos.x += camSpeed * Time.deltaTime;

            //OR
            //pos.z -= camSpeed * Time.deltaTime;
        }

        //Right
        if (Input.mousePosition.x >= Screen.width - screenSizeThickness)
        {
            pos.z += camSpeed * Time.deltaTime;
            //OR
            //pos.x += camSpeed * Time.deltaTime;
        }

        //Left
        if (Input.mousePosition.x <= screenSizeThickness)
        {
            pos.z -= camSpeed * Time.deltaTime;
            //OR
            //pos.z -= camSpeed * Time.deltaTime;
        }

        transform.position = pos;
    }
}
