using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgeextend : MonoBehaviour
{
    bridgeplatformcalculation calc;
    [SerializeField] float growthspeed;
    Rigidbody2D rb;
    //bridge= GameObject bridgePrefab;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        StartCoroutine(BridgeExtendingCoroutine());
        calc = GetComponentInChildren<bridgeplatformcalculation>();
    }
    
    IEnumerator BridgeExtendingCoroutine()
    {
        //mouse hold
        while (Input.GetMouseButton(0) == false)
        {

            yield return new WaitForEndOfFrame();
        }
        //bridge extend
        
        while (Input.GetMouseButton(0) == true)
        {
            //todo grow the bridge
            transform.localScale +=new Vector3(0, growthspeed, 0);
            
            print("grow");
             yield return new WaitForEndOfFrame();

        }

        //transform.localScale =new Vector3(0.15f,transform.localScale.y / 2,0);

        //fall bridge
        rb.constraints = RigidbodyConstraints2D.None;
        
        if (transform.localScale.y > 0.5)
        {
            rb.AddTorque(transform.localScale.y * -125);

        }
        else
        {
            rb.AddTorque(-65);
        }

        //rb.AddTorque(transform.localScale.y*-40);
        //player cross

    }

    
}
