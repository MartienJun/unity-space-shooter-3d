using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    Text ScoreText;
    public static int Score;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GetComponent<Text>();
        Score = 0;
        ScoreText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "" + Score;
    }

    
    
}
