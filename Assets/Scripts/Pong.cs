using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong : MonoBehaviour
{
    private Vector2 screenBounds;
    public GameObject paddle1;
    public GameObject paddle2;
    public GameObject circle;
    private GameObject ball;
    public float speed;
    private Touch touch1;
    private Touch touch2;
    private bool started;
    public GameObject startText;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        paddle1.transform.position = new Vector2(screenBounds.x - 0.5f, 0);
        paddle2.transform.position = new Vector2(screenBounds.x * -1 + 0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (!started)
        {
            if(Input.touchCount > 1)
            {
                ball = Instantiate(circle, Vector3.zero, Quaternion.identity);
                ball.GetComponent<Ball>().StartGame();
                startText.SetActive(false);
                started = true;
            }
        }

        if (Input.touchCount > 0)
        {
            touch1 = Input.GetTouch(0);
            var pos1 = Camera.main.ScreenToWorldPoint(touch1.position);
            if (touch1.phase == TouchPhase.Moved)
            {
                if (pos1.x > 0)
                {

                    paddle1.transform.position = new Vector2(paddle1.transform.position.x,
                        paddle1.transform.position.y + touch1.deltaPosition.y * Time.deltaTime * speed);
                }

                else
                {
                    paddle2.transform.position = new Vector2(paddle2.transform.position.x,
                        paddle2.transform.position.y + touch1.deltaPosition.y * Time.deltaTime * speed);
                }
            }
        }


        if (Input.touchCount > 1)
        {
            //touch1 = Input.GetTouch(0);
            //var pos1 = Camera.main.ScreenToWorldPoint(touch1.position);
            //touch1.position = Camera.main.ScreenToWorldPoint(new Vector3(touch1.position.x, touch1.position.y, 0));
            //if (touch1.phase == TouchPhase.Moved)
            //{
            //    if (pos1.x > 0)
            //    {

            //        paddle1.transform.position = new Vector2(paddle1.transform.position.x,
            //            paddle1.transform.position.y + touch1.deltaPosition.y * Time.deltaTime * speed);
            //    }

            //    else
            //    {
            //        paddle2.transform.position = new Vector2(paddle2.transform.position.x,
            //            paddle2.transform.position.y + touch1.deltaPosition.y * Time.deltaTime * speed);
            //    }
            //}

            touch2 = Input.GetTouch(1);
            var pos2 = Camera.main.ScreenToWorldPoint(touch2.position);
            if (touch2.phase == TouchPhase.Moved)
            {
                if (pos2.x > 0)
                {

                    paddle1.transform.position = new Vector2(paddle1.transform.position.x,
                        paddle1.transform.position.y + touch2.deltaPosition.y * Time.deltaTime * speed);

                }
                else
                {

                    paddle2.transform.position = new Vector2(paddle2.transform.position.x,
                        paddle2.transform.position.y + touch2.deltaPosition.y * Time.deltaTime * speed);

                }
            }
        }


    }


    public void Score()
    {
        Destroy(ball);
        ball = Instantiate(circle, Vector3.zero, Quaternion.identity);
    }

}
