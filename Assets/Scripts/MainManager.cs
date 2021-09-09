using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MainManager : MonoBehaviour
{
    public SaveData saveData;
    public TMP_InputField NameInputField= null;
    public Animator NameEmptyWarning = null;
    public string PlayerName{get;set;}

    public UnityEvent<SaveData> NewHighScore;
    private int highScore;
    public int HighScore{get=>highScore;set{
        NewHighScore?.Invoke(saveData);
    }}
    public float duration = 1.5f;
    /// <summary>
    /// Singleton
    /// </summary>
    static public MainManager Instance = null;
    private MainManager(){}
    private void Awake() {
        if (Instance != null){
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(Instance);     
    }

    private void Start() {
        //for name input field
        if (NameInputField == null)
            NameInputField = GameObject.Find("InputField").GetComponent<TMP_InputField>();
        if (NameEmptyWarning == null)
            NameEmptyWarning = GameObject.Find("NameEmptyWarning/Text").GetComponent<Animator>();
    }
    //these 2 for menu
    public void StartGame(){
        //get name
        Debug.Log("MainManager StartGame Clicked");
        var nameStr = NameInputField.text;
        if (nameStr== ""|| nameStr == "Your name?"){
            //warning
            Debug.Log("MainManager Warning");
            NameEmptyWarning.SetTrigger("on");
        }else{
            Instance.PlayerName=nameStr;
            SceneManager.LoadScene("main",LoadSceneMode.Single);
        }
    }
    
    public void Quit(){
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
    //this one for in game.
    public void BackToMenu(){
        SceneManager.LoadScene("Enter Menu",LoadSceneMode.Single);

    }
}
