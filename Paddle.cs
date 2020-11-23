using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

 public class Paddle : MonoBehaviour
{
    Vector2 mousePos;
    float mouseSpeed = 0.05f;
    [SerializeField] private float screenWidthUIWorld = 27;
    Ball ball;
    GameStatus gameStatus;
    BlockSquare blckSpecPow;
    
    




    private void Start()
    {
        ball = FindObjectOfType<Ball>();
        gameStatus = FindObjectOfType<GameStatus>();
        blckSpecPow = GetComponent<BlockSquare>();
        blckSpecPow = FindObjectOfType<BlockSquare>();
    }

    private void Update()
    {
        
        MovingPaddleByMouse();
        //MovingPaddleByBall();
        


       

    }

    void MovingPaddleByMouse()
    {
       // mousePos = new Vector2(Input.mousePosition.x / Screen.width * screenWidthUIWorld, transform.position.y);

        mousePos.x = Mathf.Clamp(GetXPos(), 2, 30);

        transform.position = new Vector2(mousePos.x, transform.position.y);
    }

    /*private void MovingPaddleByBall()
    {
        if(autoPlayEnabled == true)
        {
            transform.position = new Vector2(ball.transform.position.x, transform.position.y);
        }
    }
    */
        

    private float GetXPos()
    {
        if(gameStatus.AutoPlayEnabled())
        {
            return ball.transform.position.x;
            
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthUIWorld;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Spc"))
        {
            Destroy(other.gameObject);
            StartCoroutine(PowerUp());

        }


        if(other.gameObject.CompareTag("UpBall"))
        {
            Destroy(other.gameObject);

            ball.PowerUp2();
            
        }

       

    }

    



    IEnumerator PowerUp()
    {
        transform.localScale = new Vector3(2, 1, 1);
        yield return new WaitForSeconds(20f);
        transform.localScale = new Vector3(1, 1, 1);
    }

    


















}
    /*private void WrappingPaddle()
    {
        if (transform.position.x < -screenLeft)
        {
            rb.velocity = new Vector2(screenLeft, direction.y);
        }

        if (transform.position.x > screenRight)
        {
            rb.velocity = new Vector2(screenRight, direction.y);
        }
    }*/

