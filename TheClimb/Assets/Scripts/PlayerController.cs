using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float jumpingGravity;
    public float fallingGravity;

    public float moveSpeed;
    public float jumpHeight;

    PlayerActionMap _input;

    public Vector2 xMove;
    Vector3 velocity;

    Rigidbody _rb;

    bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _input = new PlayerActionMap();
        _input.Player.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        xMove = _input.Player.Move.ReadValue<Vector2>();
        //Debug.Log(xMove);
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    //Hor Movement
    private void MovePlayer()
    {
        _rb.velocity = new Vector3(xMove.x * moveSpeed, _rb.velocity.y, 0);
    }

    //Vert Movement

    public void Jump()
    {
        float jumpSpeed = Mathf.Sqrt(-2 * Physics.gravity.y * jumpHeight);

        _rb.velocity = new Vector3(_rb.velocity.x, jumpSpeed, 0);
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            foreach(ContactPoint point in other.contacts)
            {
                if(point.normal.x == 0 && point.normal.y == 1)
                {
                    //Testing having the player jump after hitting compatible ground
                    if (other.gameObject.GetComponent<Platform>().type != Platform_Type.Break)
                    {
                        Jump();
                    }

                    other.gameObject.GetComponent<Platform>().PlatformAction();
                }
            }

            

        }
    }
}
