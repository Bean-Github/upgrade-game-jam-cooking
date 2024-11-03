using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    public bool victory;
    public TMP_Text timeText;
    
    public void Setup(float endTime)
    {
        if (victory)
        {
            System.TimeSpan time = System.TimeSpan.FromSeconds(endTime);
            string displayTime = string.Format("{0:0}:{1:00}.{2:00}", time.Minutes, time.Seconds, time.Milliseconds);
            timeText.text = "COMPLETED IN " + displayTime;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
}
