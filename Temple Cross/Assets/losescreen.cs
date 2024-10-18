using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class losescreen : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(waitseconds());
    }
    IEnumerator waitseconds()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Start");
    }
    //yield return new WaitForSeconds(3f);
    //SceneManager.LoadScene("Start");
}
