using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basuko : MonoBehaviour
{
    public int myRotation = 1;
    public GameObject basuko;
    public GameObject pablo;
    void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, myRotation++, 0));
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "heroe")
        {
            Destroy(basuko);
            pablo.SetActive(true);
           
        }

    }
}
