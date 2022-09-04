using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public int score;

    [SerializeField] TextMeshProUGUI scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.SetText("Score : " + score);
    }
}
