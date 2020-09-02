using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Ally;

sealed class WolfMen : Npc
{
     Vector3 direction;
     public int pointLife = 100;
  

    
    void Start()
    {
      gameObject.transform.tag = "wolfmen";
      transform.name = "Wolf Men";
      gameObject.GetComponent<MeshRenderer>().material.color = Color.gray;
      StartCoroutine(AzarMoveVar());
      state = State.idle;

    }

    void Update()
    {
        if (pointLife <= 0)
        {
            Die();
        }

        GameObject aldeanoSerca = null;
        float zombieDistance = 5;


        foreach (var citizen in FindObjectsOfType<Citizen>())
        {
            float temporalDistan = (citizen.transform.position - transform.position).magnitude;

            if (temporalDistan <= zombieDistance)
            {
                zombieDistance = temporalDistan;
                aldeanoSerca = citizen.gameObject;
            }
        }

        if (HeroControl.mGameOver == true)
        {
            if (aldeanoSerca != null)
            {
                zombieDistance = (aldeanoSerca.transform.position - transform.position).magnitude;
                Vector3 zombieDirection = (aldeanoSerca.transform.position - transform.position).normalized;
                transform.position += (zombieDirection * 3f * Time.deltaTime);
            }
            else if ((General.hero.transform.position - transform.position).magnitude <= 5f)
            {
                direction = Vector3.Normalize(General.hero.transform.position - transform.position);
                transform.position += direction * 0.1f;
            }
            else
            {
                Move();
            }

        }
    }
        private void OnCollisionEnter(Collision collision)
        {

            if (collision.transform.tag ==  "machete")
            {
                
                pointLife = pointLife - 30; 
            }
            if (collision.transform.tag == "aldeano")
            {
                collision.transform.GetComponent<Citizen>().Die();

            }
        } 
}
  
        