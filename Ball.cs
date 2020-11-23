using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector2 ballPaddleCoordDiff;
    [SerializeField] private Paddle paddle1;
    Vector2 paddlePos;
    private Boolean clickOnMouse = false;
    [SerializeField] private float ballVelx;
    [SerializeField] private float ballVely;
    [SerializeField] AudioClip[] ballAudioClip;
    [SerializeField] float randomFactor = 0.2f;
    Rigidbody2D myRigidBody2d;
    Vector2 paddle2;


    

     AudioSource ballSound;
    

    private void Start()
    {
        ballPaddleCoordDiff = new Vector2(transform.position.x - paddle1.transform.position.x, transform.position.y - paddle1.transform.position.y);

        ballSound = GetComponent<AudioSource>();

        myRigidBody2d = GetComponent<Rigidbody2D>();

        paddle2 = new Vector2(paddle1.transform.position.x, transform.position.y + 0.09f);
        


    }

    private void Update()
    {
        //LockingBallToPaddle();
        //FireTheBallClickOnMouse();

       

        ClickOrGlue();
        
      
        
        

    }

    

    void LockingBallToPaddle()
    {
        paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = ballPaddleCoordDiff + paddlePos;
    }

    private void FireTheBallClickOnMouse()
    {
        if(Input.GetMouseButtonDown(0))
        {
            clickOnMouse = true;
            myRigidBody2d.velocity = new Vector2(ballVelx, ballVely);

        }
        
    }

    private void ClickOrGlue()
    {
        if(clickOnMouse == false)
        {
            LockingBallToPaddle();
            FireTheBallClickOnMouse();
        }
       
          
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0, randomFactor), UnityEngine.Random.Range(0, randomFactor));

       



        AudioClip clip = ballAudioClip[UnityEngine.Random.Range(0, ballAudioClip.Length)];
        ballSound.PlayOneShot(clip);
        myRigidBody2d.velocity += velocityTweak;


    }

    public void PowerUp2()
    {
        Instantiate(GameObject.FindGameObjectWithTag("Ball"), paddle2 , GameObject.FindGameObjectWithTag("Paddle").transform.rotation);
    }








}
