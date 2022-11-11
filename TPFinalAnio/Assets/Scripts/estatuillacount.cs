using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class estatuillacount : MonoBehaviour
{

    public static bool estauilla = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.CompareTag("estatuilla"))
        {
            estauilla = true;
        }
    }

}
