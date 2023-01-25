using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AI_Behaviour
{
    side,
    chase
}
public class BasicAI : MonoBehaviour
{
    public AI_Behaviour behaviour;
    public float chaseRadius;
    public Vector3 startPos;

    public float moveSpeed;
    Transform playerTarget;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        playerTarget = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(behaviour == AI_Behaviour.chase)
        {
            if(Vector3.Distance(transform.position, playerTarget.position) <= chaseRadius)
            {
                transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, playerTarget.position.x, 2), Mathf.MoveTowards(transform.position.y, playerTarget.position.y, 2), transform.position.z);
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            if(Vector3.Distance(startPos, transform.position) >= 8)
            {
                moveSpeed = -moveSpeed;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            GameManager.instance.GameOver();
            other.GetComponent<PlayerController>().GetComponent<Collider>().enabled = false;
        }
    }
}
