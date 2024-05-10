using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Ending : MonoBehaviour
{
    public TextMeshProUGUI gameEndingText;
    public int score; 
    
    private void Awake() {
        score = StaticData.valueToKeep;
        Debug.Log("넘어간 후 score" + score.ToString());
        if (score <= 10)
        {
            gameEndingText.text = score.ToString() + " 표로 낙선...";
        }
        else if(score <= 30)
        {
            gameEndingText.text = score.ToString() + " 표로 국회의원 당선!";
        }
        else
        {
            gameEndingText.text = score.ToString() + " 표로 대통령 당선!!!";
        }
    }
}
