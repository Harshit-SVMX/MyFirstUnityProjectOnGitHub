using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KT : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.F)){
            Debug.Log("get key");
        }

        if (Input.GetKeyUp(KeyCode.U))
        {
            Debug.Log("get keyUP");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("get keyDOWN");
        }
    }
}
