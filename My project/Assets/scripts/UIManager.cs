using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score = 0;

    private void Awake() {
        
    }

    private void UpdateScoreText(int score) {
        scoreText.text = score.ToString();
    }
}
