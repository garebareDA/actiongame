﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whieelEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float gravity;
    public string gravityMode;
    private Transform gravityDown;
    private Animator animator;
    private Vector2 movementNomal = new Vector2(0, 0);

    private float speedUp;
    public float moveInput;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Transform gravityTrandform = transform.Find("Gravity").gameObject.transform;
        gravityDown = gravityTrandform.Find("gravityDown").gameObject.transform;
        speedUp = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gravityMode == "down" || gravityMode == "up")
        {
            move(moveInput * speed * speedUp - movementNomal.x);
        }
        else if (gravityMode == "left" || gravityMode == "right")
        {
            move(moveInput * speed * speedUp - movementNomal.y);
        }
    }

    private void move(float speed)
    {
        if (gravityMode == "up")
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y - movementNomal.y);
        }
        else if (gravityMode == "down")
        {
            rb.velocity = new Vector2(speed, rb.velocity.y - movementNomal.y);
        }
        else if (gravityMode == "right")
        {
            rb.velocity = new Vector2(rb.velocity.x - movementNomal.x, -speed);
        }
        else if (gravityMode == "left")
        {
            rb.velocity = new Vector2(rb.velocity.x - movementNomal.x, speed);
        }
    }

    private void rayGravity()
    {
        Ray ray = new Ray(gravityDown.position, -gravityDown.up);
        RaycastHit2D[] hits = new RaycastHit2D[2];
        int h = Physics2D.RaycastNonAlloc(ray.origin, ray.direction, hits);
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
        if (h > 0)
        {
            int index = 0;
            if (hits[index].collider.tag == "ground")
            {
                movementNomal = new Vector2(hits[index].normal.x, hits[index].normal.y);
                Quaternion q = Quaternion.FromToRotation(
                        transform.up,
                        hits[index].normal);
                transform.rotation *= q;
            }
        }
    }
}
