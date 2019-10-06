using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public GameObject cam;
    public GameObject blob;
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
        Vector3 move = transform.right * (x * movementSpeed);
        rb.velocity = new Vector3(move.x,rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            grounded = false;
            rb.velocity = new Vector2(rb.velocity.x,jumpSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("auwutist");
            TemporaryBlock();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag=="Ground" || collision.gameObject.tag == "Dead" || collision.gameObject.tag == "Tempblock")
        {
            grounded = true;
        }
    }

    public void KillPlayer()
    {
        PlayerShaderManipulation.UpdateShader();
        var c = gameObject;
        gameObject.tag = "Dead";
        c.GetComponent<PlayerController>().enabled = false;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().SpawnPlayer();
        Destroy(c.GetComponent<Rigidbody2D>());
        Destroy(blob.GetComponent<PlayerShaderManipulation>());
        Destroy(cam);
        Destroy(c.GetComponent<BoxCollider2D>());
        Destroy(c.GetComponent<AudioListener>());
        Destroy(c.GetComponent<AudioSource>());
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
