using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ball : MonoBehaviour
{

    public float speed = 5f;
    private int player1Score = 0;
    private int player2Score = 0;
    private GameObject player1ScoreText;
    private GameObject player2ScoreText;
    private GameObject pong;
    Pong PongScript;
    // Start is called before the first frame update
    void Start()
    {
        player1ScoreText = GameObject.Find("Player1Score");
        player2ScoreText = GameObject.Find("Player2Score");
        pong = GameObject.Find("Pong");
        PongScript = pong.GetComponent<Pong>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("P1Goal"))
        {
            player1Score++;
            player1ScoreText.GetComponent<TMPro.TextMeshProUGUI>().text = player1Score.ToString();
            PongScript.Score();
        }
        else if (collision.transform.CompareTag("P2Goal"))
        {
            player2Score++;
            player2ScoreText.GetComponent<TMPro.TextMeshProUGUI>().text = player2Score.ToString();
            PongScript.Score();
        }
    }

    public void StartGame()
    {
        float sx = Random.Range(0, 2) == 0 ? -1 : 1;
        float sy = Random.Range(0, 2) == 0 ? -1 : 1;

        GetComponent<Rigidbody2D>().velocity = new Vector3(speed * sx, speed * sy, 0f);
    }



}
