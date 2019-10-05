using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float jumpLeniancy = 0.1f;
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
        Vector3 move = transform.right * (x * Time.deltaTime * movementSpeed);
        rb.velocity = new Vector3(move.x,rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && Math.Sqrt(rb.velocity.y * rb.velocity.y) < jumpLeniancy)
        {
            rb.AddForce(transform.up * jumpSpeed, ForceMode2D.Impulse);
        }
    }

    public void KillPlayer()
    {
        var c = gameObject;
        Destroy(c.GetComponent<Rigidbody2D>());
        Destroy(c.GetComponent<PlayerController>());
        c.GetComponent<SpriteRenderer>().color = Color.green;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().SpawnPlayer();
    }
}
