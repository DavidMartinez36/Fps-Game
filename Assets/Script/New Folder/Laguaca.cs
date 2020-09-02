using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laguaca : MonoBehaviour
{
    
    private void Start()
    {
        foreach (Transform item in transform)
        {
            item.GetComponent<Rigidbody>().useGravity = true;
            item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        }

    }

}
