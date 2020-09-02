using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class TheBigMachete : MonoBehaviour
{
    public int myRotation = 1;
    public GameObject macheteEnLaMano;
   
  
    
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, myRotation++, 0));
     
    }
      private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "heroe")
        {
            collision.transform.GetChild(0).transform.gameObject.SetActive(true);
            Destroy(this.transform.gameObject);
            macheteEnLaMano.SetActive(true);
        }

    }
}
