using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerscript : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartWalking()
    {
        StartCoroutine(Walk());
    }

    IEnumerator Walk()
    {
        while (true)
        {
            rb.velocity = new Vector2(3, rb.velocity.y);
            yield return new WaitForFixedUpdate();
        }
    }
}
