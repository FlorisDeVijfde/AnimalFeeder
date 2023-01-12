using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    //public TMP_InputField playerName;
    public TextMeshProUGUI playerName;

    public void StartGame()
    {
        PersistanceManager.Instance.playerName = playerName.text;
        PersistanceManager.Instance.LoadTopScore();
        SceneManager.LoadScene("MainScene");
    }

    public void ExitGame()
    {

    }
}
