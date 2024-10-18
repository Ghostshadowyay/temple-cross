using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    //making hit variable
    public bool hit = false;
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

    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
    [SerializeField] private Vector2 platformSpawnCoords;
    [SerializeField] GameObject platformprefab;
    [SerializeField] TMP_Text scoreText;

    private void Spawn()
    {
        Instantiate(platformprefab, new Vector3(platformSpawnCoords.x + Random.Range(-2, 7), -2.859f, 0f), Quaternion.identity);
    }
    void Start()
    {
        StopCoroutine(WinLossTimer());
        scoreText.text = score.ToString();
        StartCoroutine(WinLossTimer());

        // platform
        Spawn();

    }


    //PUT THIS IN LATER
    /*
    public void DeletePlatform()
    {
        Debug.Log(hit);
        if (hit == true)
        {
            
            GameObject[] platforms = GameObject.FindGameObjectsWithTag("platform");
            foreach (GameObject platform in platforms)
            {
                Destroy(platform);
            }
        }
    }
    */

    IEnumerator WinLossTimer()
    {
        print("starttimer");

        yield return new WaitForSeconds(10f);
        if (hit == false)
        {
            print("lose");
            StartCoroutine(GameOverCoroutine());
        }
        if (hit==true)
        {
            print("win");
            //DeletePlatform();
            //Reload game or send to lose scene
            
            StartCoroutine(GameOverCoroutine());

            score++;
        }
    }
    private IEnumerator GameOverCoroutine()
    {
        if (hit == false)
        {
            print("SENd to lose");
            SceneManager.LoadScene("lose");
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene("Start");
            score = 0;
        }

        else
        {


            SceneManager.LoadScene("Game");
        }

        StartCoroutine(WinLossTimer());

    }

}
