using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class menubutton : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadGame()
    {
        PlayerPrefs.SetInt("score", 0);
        SceneManager.LoadScene("Game");
    }


}