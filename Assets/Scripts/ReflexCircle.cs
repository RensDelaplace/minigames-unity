using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflexCircle : MonoBehaviour
{

    Reflex reflexScript;

    // Start is called before the first frame update
    void Start()
    {
        reflexScript = GameObject.Find("Reflex").GetComponent<Reflex>();
        GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
    }


    void OnMouseDown()
    {
        reflexScript.First(this.gameObject);
    }

}
