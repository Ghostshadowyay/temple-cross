using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{ 
    //making hit variable
    public bool hit = false;
    public static GameManager instance;
    [SerializeField] private Vector2 platformSpawnCoords;
    [SerializeField] GameObject platformprefab;
    [SerializeField] TMP_Text scoreText;
    public int score 
    {
        //this runs when you read the variable 
        get
        {
            return PlayerPrefs.GetInt("score");
        }
        //this runs when you change the variable 
        set
        {
            PlayerPrefs.SetInt("score", value);
            scoreText.text = score.ToString();
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        scoreText.text = score.ToString();

        // platform
        Spawn();

    }
    private void Spawn()
    {
        Instantiate(platformprefab, new Vector3(platformSpawnCoords.x + Random.Range(-2, 7), -2.859f, 0f), Quaternion.identity);
    }

    public void StartTimers()
    {
        StartCoroutine(WinLossTimer());
    }

    IEnumerator WinLossTimer()
    {
        print("starttimer");

        yield return new WaitForSeconds(8f);
        if (hit == false)
        {
            print("lose");
            score = 0;
            SceneManager.LoadScene("lose");
        }
        if (hit==true)
        {
            print("win");
            score++;
            //Reload game
            SceneManager.LoadScene("Game");
        }
    }
}
