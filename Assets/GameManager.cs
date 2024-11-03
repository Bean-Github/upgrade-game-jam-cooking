using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float startTime;
    public TMP_Text timerText;
    private float gameTime;

    private void Start()
    {
        DontDestroyOnLoad(this);
        gameTime = startTime;
    }
    
    private void Update()
    {
        if (gameTime <= 0f)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(2);
            return;
        }
        
        gameTime = Mathf.Max(gameTime - Time.deltaTime, 0f);
        System.TimeSpan time = System.TimeSpan.FromSeconds(gameTime);
        string displayTime = string.Format("{0:0}:{1:00}.{2:00}", time.Minutes, time.Seconds, time.Milliseconds);
        timerText.text = displayTime;
    }

    public void Win()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(1);
    }
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
            return;
        GameObject.Find("End Screen Manager").GetComponent<EndManager>().Setup(gameTime);
        Destroy(this);
    }
}
