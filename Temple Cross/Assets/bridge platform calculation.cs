using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bridgeplatformcalculation : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("platform"))
        {
            print("win");
            GameManager.instance.hit = true;

            //PUT THIS IN LATER
            //GameManager.instance.DeletePlatform();
        }
    }
}
