using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerAuth : MonoBehaviour
{
    public InputField Username;
    public InputField Password;

    public static string User = "";

    public Text Name;
    public Text Score;

    

    public void LoginAuth()
    {
        string UsernameKey = Username.text;
        string UsernameText = Username.text;
        string PasswordText = Password.text;
        
        if (Username.text == PlayerPrefs.GetString("username_" + UsernameKey))
        {
            if (Password.text == PlayerPrefs.GetString("password_" + UsernameKey))
            {
                ScoreController.Score = 0;
                User = Username.text;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                

            }
        }
    }

    public void RegisterAuth()
    {
        string UsernameKey = Username.text;

        PlayerPrefs.SetString("username_" + Username.text, Username.text);
        PlayerPrefs.SetString("password_" + Username.text, Password.text);

        
        
    }

    public void ScoreAuth()
    {
        string UsernameKey = Username.text;
        if(User.Length == 0)
        {
            Name.text = "Last Player";
        }
        else
        {
            Name.text = PlayerPrefs.GetString("username_" + User);
        }
        
        Score.text = PlayerPrefs.GetInt("Score", ScoreController.Score).ToString();
    }
}
