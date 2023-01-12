using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

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
#if UNITY_EDITOR
        //testmode in Unity...compiled in Unity Editor
        EditorApplication.ExitPlaymode();
#else
        //Real application
        Application.Quit();
#endif
    }
}
