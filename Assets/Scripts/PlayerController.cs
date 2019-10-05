﻿using System.Collections;
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
    bool grounded = true;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        Vector3 move = transform.right * (x * Time.deltaTime * movementSpeed);
        rb.velocity = new Vector3(move.x,rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            grounded = false;
            rb.AddForce(transform.up * jumpSpeed, ForceMode2D.Impulse);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            TemporaryBlock();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogError("Hit stuff");
        if (collision.gameObject.tag=="Ground" || collision.gameObject.tag == "Dead" || collision.gameObject.tag == "Tempblock")
        {
            grounded = true;
        }
    }

    public void KillPlayer()
    {
        var c = gameObject;
        gameObject.tag = "Dead";
        Destroy(c.GetComponent<Rigidbody2D>());
        Destroy(c.GetComponent<PlayerController>());
        c.GetComponent<SpriteRenderer>().color = Color.green;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().SpawnPlayer();
        
    }

    private void TemporaryBlock()
    {
        var block = GameObject.FindGameObjectWithTag("Tempblock");
        if (block != null)
        {
            Destroy(block);
        }
        KillPlayer();
        gameObject.tag = "Tempblock";
        gameObject.GetComponent<SpriteRenderer>().color = Color.black;
    }
}
