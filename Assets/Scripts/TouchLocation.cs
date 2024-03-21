using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchLocation : MonoBehaviour
{
    public int touchId;
    public GameObject circle;
    public Color color;
    public TouchLocation(int newTouchId, GameObject newCircle, Color _randomColor)
    {
        touchId = newTouchId;
        circle = newCircle;
        color = _randomColor;
    }


}
