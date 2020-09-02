using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Vigilante : MonoBehaviour
{
    public float putinSpeed;
    public int direccion = 1;
    public int rotationM = 1;

  /*  private void Start()
    {
        
        transform.position += new Vector3(5, 0, 0);

    }*/


    private void Update()
    {
        transform.position += new Vector3(putinSpeed * Time.deltaTime * direccion, 0, 0);
        transform.rotation = Quaternion.Euler(new Vector3(0, rotationM++,0));

        if (transform.position.x >5) 
        {
            direccion = -1;
       
        }
        if (transform.position.x < -5)
        {
            direccion = 1;
        }
    }
}
