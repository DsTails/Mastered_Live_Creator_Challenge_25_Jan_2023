using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform playerTarget;
    Rigidbody playerRB;
    public Vector3 offset;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        playerTarget = FindObjectOfType<PlayerController>().transform;
        playerRB = FindObjectOfType<PlayerController>().GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, playerRB.velocity.y > 0 ? playerTarget.position.y : transform.position.y, 0) + offset;
        Vector3 viewPos = cam.WorldToViewportPoint(playerTarget.position);

        if(viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
        {
            //Debug.Log("PLAYER IN VIEW");
        }
        else
        {
            
            GameManager.instance.GameOver();
            //Debug.Log("PLAYER IS GONE");
        }

    }


    
}
