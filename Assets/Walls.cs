using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    private Vector2 screenBounds;
    public GameObject WallLeft;
    public GameObject WallRight;
    public GameObject WallUp;
    public GameObject WallDown;
    private float objectWidth;
    private float objectHeight;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        objectHeight = WallUp.transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        objectWidth = WallLeft.transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;

        WallLeft.transform.position = new Vector2(screenBounds.x * -1 - objectWidth, 0);
        WallRight.transform.position = new Vector2(screenBounds.x + objectWidth, 0);
        WallUp.transform.position = new Vector2(0, screenBounds.y + objectHeight);
        WallDown.transform.position = new Vector2(0, screenBounds.y * -1 - objectHeight);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
