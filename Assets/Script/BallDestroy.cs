using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroy : MonoBehaviour
{
    public Transform ballLocationStart;
    public Transform PaddleLocationStart;
    private Vector3 ballStart;
    private Vector3 paddleStart;
    private Rigidbody2D ballRB;
    private PaddleMovement PM;
    private GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        ballStart = ballLocationStart.position; 
        paddleStart = PaddleLocationStart.position;
        ballRB = ballLocationStart.GetComponent<Rigidbody2D>();
        PM = PaddleLocationStart.GetComponent<PaddleMovement>();
        GameObject Game_M = GameObject.FindWithTag("GameManager");
        GM = Game_M.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball") {
            ballLocationStart.position =  ballStart;
            PaddleLocationStart.position = paddleStart;
            ballRB.velocity = Vector2.zero;
            ballRB.angularVelocity = 0f;
            PM.isBallNotStart = true;
            GM.health -= 1;
        }
    }


}
