using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Rigidbody2D ball;
    private float moveSpeed = 10f;
    public bool isBallNotStart;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject bola = GameObject.FindWithTag("Ball");
        ball = bola.GetComponent<Rigidbody2D>();
        isBallNotStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveX * moveSpeed, 0);
        if(isBallNotStart) {
            ball.transform.position = new Vector3(transform.position.x, ball.transform.position.y,0);
        }
        if(Input.GetMouseButtonDown(0) && isBallNotStart) {
            isBallNotStart = false;
            //ball.velocity = Vector2.up * 10f;
            ball.velocity = Vector2.up * 10f;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball") {
            float hitPoint = collision.GetContact(0).point.x - transform.position.x;
            ball.velocity = new Vector2(hitPoint * 5f, ball.velocity.y);
        }
    }

}
