using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float jumpSpeed;
    Rigidbody2D rb;
    bool jump = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        Vector3 move = transform.right * (x * Time.deltaTime)*movementSpeed;
        transform.Translate(move.x,move.y,move.z);
        print(Physics2D.Raycast(transform.position, -transform.up, 0.5f,1));
        if (Input.GetKeyDown(KeyCode.Space) && !jump)
        {
            rb.AddForce(transform.up*jumpSpeed);
            jump = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            jump = false;
        }
    }
}
