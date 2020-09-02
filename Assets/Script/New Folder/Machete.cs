using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Machete : MonoBehaviour
{
    public Animator anim;
    
    
    void Start()
    {
      anim = GetComponent<Animator>();
        
    }
    void Update()
    {
         if(Input.GetMouseButtonDown(0))
        {
            int n = Random.Range(0,2);
 
            if(n == 0)
            {
                anim.Play ("attack2",-1,0f);
            }
            else
            {
                anim.Play ("attack",-1,0f);
            }
        }
        
    }
          
}
