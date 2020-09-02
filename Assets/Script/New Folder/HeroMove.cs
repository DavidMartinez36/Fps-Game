using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
  
    public float mVelo;

    void start()
    {
    }
    void Update()
    {
            Move();

    }
    private void Move()
    {
         if (HeroControl.mGameOver == true)
         {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * mVelo * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * mVelo * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * mVelo * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * mVelo * Time.deltaTime;
        }
         }

    } 
    private void AttackMachete()
    {
    

    }

}
