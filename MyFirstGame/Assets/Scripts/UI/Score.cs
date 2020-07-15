using UnityEngine.UI;
using UnityEngine;
using System;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public Text highScore;
    private float scoreCounter = 0;
    public ObjectSpawner speed;
    // Start is called before the first frame update
    void Start()
    {
        highScore.text = highScore.text+PlayerPrefs.GetFloat("HighScore",0).ToString("0");
        scoreCounter = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scoreCounter= speed.speed/2 * Time.timeSinceLevelLoad;
        scoreText.text = (scoreCounter).ToString("0");


        if(scoreCounter> PlayerPrefs.GetFloat("HighScore", 0))
         {
            PlayerPrefs.SetFloat("HighScore", scoreCounter);
            highScore.text = "HIGH SCORE: " + PlayerPrefs.GetFloat ("HighScore", 0).ToString("0");
        }

        //adust difficulty the longer the game goes on
        Debug.Log(scoreCounter % 100);
        if (scoreCounter%200 >= 199 && speed.speed <80)
        {
            float speedIncrease = UnityEngine.Random.Range(0f, 6f);

            Debug.Log("Increasing Speed");
            speed.speed = speed.speed + speedIncrease;
        }
        
    }
}
