using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Reflex : MonoBehaviour
{

    private float spawnRate;
    private float nextSpawn = 0f;
    private Vector2 spawnPoint1;
    private Vector2 spawnPoint2;
    private GameObject circle1;
    private GameObject circle2;
    public GameObject circlePref;
    private int player1Score = 0;
    private int player2Score = 0;
    public GameObject player1ScoreText;
    public GameObject player2ScoreText;
    private bool spawned = false;
    public GameObject winPanel1;
    public GameObject winPanel2;
    public GameObject losePanel1;
    public GameObject losePanel2;
    private bool done = false;
    // Start is called before the first frame update
    void Start()
    {
        nextSpawn = Random.RandomRange(0.5f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (done)
            return;
        if (Time.time > nextSpawn)
        {
            if (spawned)
                return;
            spawnPoint1 = new Vector2(Random.Range(-1f, -7.8f), Random.Range(-4f, 4f));
            spawnPoint2 = new Vector2(Random.Range(1f, 7.8f), Random.Range(-4f, 4f));
            circle1 = Instantiate(circlePref, spawnPoint1, Quaternion.identity);
            circle2 = Instantiate(circlePref, spawnPoint2, Quaternion.identity);
            circle1.transform.name = "Circle1";
            circle2.transform.name = "Circle2";
            spawned = true;

        }
    }

    public void First(GameObject whichCircle)
    {
        spawnRate = Random.RandomRange(0.5f, 10f);
        nextSpawn = Time.time + spawnRate;
        spawned = false;
        Destroy(circle1);
        Destroy(circle2);
        if (whichCircle.transform.name == "Circle1")
        {
            player1Score++;
            player1ScoreText.GetComponent<TMPro.TextMeshProUGUI>().text = player1Score.ToString();
            if(player1Score >= 5)
            {
                winPanel1.SetActive(true);
                losePanel2.SetActive(true);
                done = true;
            }
        }

        if (whichCircle.transform.name == "Circle2")
        {
            player2Score++;
            player2ScoreText.GetComponent<TMPro.TextMeshProUGUI>().text = player2Score.ToString();
            if (player2Score >= 5)
            {
                winPanel2.SetActive(true);
                losePanel1.SetActive(true);
                done = true;
            }


        }

    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void Leave()
    {
        SceneManager.LoadScene(0);
    }

}
