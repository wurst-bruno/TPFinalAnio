using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupobject : MonoBehaviour
{
    public Transform destination;
    private void OnMouseDown()
    {
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = destination.position;
        this.transform.parent = GameObject.Find("destinationofobj").transform;
    }
    void OnMouseUp()
    {
        GetComponent<BoxCollider>().enabled = true;
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }
}
