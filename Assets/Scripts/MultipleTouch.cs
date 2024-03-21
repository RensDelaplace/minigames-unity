using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultipleTouch : MonoBehaviour
{
    public GameObject circle;
    public List<TouchLocation> touches = new List<TouchLocation>();
    private bool noChanges;
    Color randomColor;
    private int index = 0;
    private GameObject winColor;
    private GameObject mask;
    private bool chosen;
    TouchLocation winningTouch;
    private void Start()
    {
        winColor = GameObject.Find("WinColor");
        mask = GameObject.Find("Mask");
        mask.transform.position = new Vector3(0, 0, 0);
        mask.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }


    void Update()
    {

        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch t = Input.GetTouch(i);
            if (t.phase == TouchPhase.Began)
            {
                Debug.Log("Touch began");
                randomColor = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
                touches.Add(new TouchLocation(t.fingerId, createCircle(t), randomColor));
                CancelInvoke("NoChanges");
                Invoke("NoChanges", 5f);
            }
            else if (t.phase == TouchPhase.Ended)
            {
                Debug.Log("Touch ended");
                TouchLocation thisTouch = touches.Find(TouchLocation => TouchLocation.touchId == t.fingerId);
                if (!chosen)
                    Destroy(thisTouch.circle);
                touches.RemoveAt(touches.IndexOf(thisTouch));
                CancelInvoke("NoChanges");
                Invoke("NoChanges", 5f);
            }
            else if (t.phase == TouchPhase.Moved)
            {
                Debug.Log("Touch is moving");
                TouchLocation thisTouch = touches.Find(touchLocation => touchLocation.touchId == t.fingerId);
                if(!chosen)
                    thisTouch.circle.transform.position = getTouchPosition(t.position);
            }

        }
        Vector2 getTouchPosition(Vector2 touchPosition)
        {
            return GetComponent<Camera>().ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, transform.position.z));
        }


        GameObject createCircle(Touch t)
        {
            GameObject c = Instantiate(circle) as GameObject;

            c.GetComponent<SpriteRenderer>().color = randomColor;
            c.name = "Touch" + t.fingerId;
            c.transform.position = getTouchPosition(t.position);
            return c;
        }

    }

    void NoChanges()
    {
        if(touches.Count > 1)
        {
            winningTouch = touches[Random.Range(0, touches.Count)];
            winColor.GetComponent<SpriteRenderer>().color = winningTouch.color;
            mask.transform.position = winningTouch.circle.transform.position;
            mask.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
            chosen = true;
            Invoke("Reset", 5f);

        }
    }


    void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
