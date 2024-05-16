using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public float LimitTime;
    public TextMeshProUGUI timerText;

    public string SceneToLoad;


    public void Update()
    {
        if (LimitTime <= 0 )
        {
            TimeOver();
            SceneManager.LoadScene(SceneToLoad);
        }
        else
        {
            LimitTime -= Time.deltaTime;
            timerText.text = Mathf.Round(LimitTime).ToString();
        }
        
    }

    private void TimeOver()
    {
        FindObjectOfType<character_move>().TimeOver();
    }
}