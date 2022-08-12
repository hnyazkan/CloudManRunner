using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager cloud;
    public TextMeshProUGUI text;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        if(cloud == null)
        {
            cloud = this;
        }
    }

     public void ChangeScore (int cloudValue)
    {
        score += cloudValue;
        text.text = "x" + score.ToString();
    }
}
