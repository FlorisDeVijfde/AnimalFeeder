using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    private int rejects = 0;
    private int maxRejects = 3;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI rejectedText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Score()
    {
        score++;
        scoreText.text = "Score: " + score;
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

    void GameOver()
    {

    }
}
