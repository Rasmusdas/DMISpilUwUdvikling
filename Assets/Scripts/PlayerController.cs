using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float jumpLeniancy = 0.1f;
    public float jumpSpeed;
    public bool control = true;
    Rigidbody2D rb;
    bool jump = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(control)
        {
            float x = Input.GetAxis("Horizontal");
            Vector3 move = transform.right * (x * Time.deltaTime * movementSpeed);
            rb.velocity = new Vector3(move.x,rb.velocity.y);
            Debug.Log(Mathf.Approximately(rb.velocity.y, 0));
            if (Input.GetKeyDown(KeyCode.Space) && Math.Sqrt(rb.velocity.y*rb.velocity.y) < jumpLeniancy )
            {
                rb.AddForce(transform.up * jumpSpeed,ForceMode2D.Impulse);
            }
        }
    }
}
