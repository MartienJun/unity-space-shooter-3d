using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAtStart : MonoBehaviour
{
    public void ResetScore()
    {
        PlayerPrefs.SetInt("Score", 0);
    }
}
