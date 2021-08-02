using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public string currentPlayerName;


    public void StartNew()
    {
        SceneManager.LoadScene(1);
        
    }

    public void Exit()
    {   
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); // original code to quit Unity player
        #endif
    }
}
