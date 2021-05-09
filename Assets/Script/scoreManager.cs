using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreManager : MonoBehaviour
{
    public static scoreManager ScoreManager;
    public Text scoreText;
    int score = 0;

    void Start()
    {
        if (ScoreManager == null)

        {
            ScoreManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Update()
    {
        if (scoreText == null)
        {
            scoreText = GameObject.Find("Points").GetComponent<Text>();
            scoreText.text = score + "";
        }
    }

    public void RaiseScore(int p)
    {
        score += p;

        //Debug.Log(score);
        scoreText.text = score + "";
        if (score == 10)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
