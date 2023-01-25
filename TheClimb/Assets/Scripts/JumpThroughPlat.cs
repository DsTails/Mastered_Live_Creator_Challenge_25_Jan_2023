using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpThroughPlat : MonoBehaviour
{
    public float checkRadius;
    public LayerMask playerLayer;

    
    [SerializeField] Collider colliderBox;

    Rigidbody playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        colliderBox = GetComponent<Collider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        bool playerDetected = Physics.CheckSphere(transform.position, checkRadius, playerLayer);

        if (playerDetected)
        {
            if(playerRigidbody == null)
            {
                playerRigidbody = FindObjectOfType<PlayerController>().GetComponent<Rigidbody>();
            }

            if(playerRigidbody.velocity.y > 0)
            {
                colliderBox.enabled = false;
            }
            else
            {
                colliderBox.enabled = true;
            }
        }
        else
        {
            if(playerRigidbody != null)
            {
                playerRigidbody = null;
                colliderBox.enabled = true;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
