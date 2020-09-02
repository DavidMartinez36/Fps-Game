using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandera : MonoBehaviour
{
    public GameObject bandera; 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "heroe")
        {
            Destroy(bandera);
        }

    }

}
