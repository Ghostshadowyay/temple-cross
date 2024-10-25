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
    [SerializeField] Playerscript player;
    GameObject endBarrier;
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
        GameObject platform=Instantiate(platformprefab, new Vector3(platformSpawnCoords.x + Random.Range(-2, 7), -2.859f, 0f), Quaternion.identity);
        endBarrier = platform.transform.Find("EndBarrier").gameObject;
    }

    public void StartTimers()
    {
        StartCoroutine(WinLossTimer());
    }

    IEnumerator WinLossTimer()
    {
        print("starttimer");
        //wait to check if bridge is touching
        yield return new WaitForSeconds(5f);
        endBarrier.SetActive(hit);
        player.StartWalking();
        //start walking and wait seconds to walk across
        yield return new WaitForSeconds(4f);
        if (hit == false)
        {
            //disable end barrier
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
