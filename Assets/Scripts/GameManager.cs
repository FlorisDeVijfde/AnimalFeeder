//Abstraction mostly here and in DispenseFood through methods

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//for button
//using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    private int rejects = 0;
    private int maxRejects = 5;
    private bool newTopScore = false;

    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI topScoreText;
    public TextMeshProUGUI rejectedText;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        playerNameText.text = PersistanceManager.Instance.playerName;

        //Read and update topscore
        PersistanceManager.Instance.LoadTopScore();
        topScoreText.text = "Topscore: " + PersistanceManager.Instance.topScorerName + " (" + PersistanceManager.Instance.topScore + ")";
    }

    public void Score()
    {
        score++;
        scoreText.text = "Score: " + score;

        if (score > PersistanceManager.Instance.topScore)
        {
            newTopScore = true;
            topScoreText.text = PersistanceManager.Instance.playerName + " (" + score + ")";
        }
    }

    public void AddReject()
    {
        rejects++;
        if (rejects > maxRejects)
        {
            GameOver();
        }
        rejectedText.text = "Rejects: " + rejects + "/" + maxRejects; 
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
        if (newTopScore)
        {
            PersistanceManager.Instance.SaveTopScore(score);
        }
    }

    void GameOver()
    {
        gameOver.SetActive(true);
    }

}
