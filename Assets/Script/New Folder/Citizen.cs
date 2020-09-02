using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Enemy;
namespace NPC
{
    namespace Ally
    {
        sealed class Citizen : Npc
        {

            public sCitizen citizen = new sCitizen();
            public static string[] cNames;
            public GameObject myParet = General.paret;
            public static int age; 
            float temporalDistan; 
            float zombieDistance;
            float WolfMenDistance;
            void Start()
            {
                    gameObject.transform.tag = "aldeano"; 
                    transform.name = "aldeano";
                    citizen.age = Random.Range(15, 101);
                    age = citizen.age; 
                    gameObject.GetComponent<Renderer>().material.color = Color.red;
                    StartCoroutine(AzarMoveVar());
                    state = State.idle;
            }

            
            void Update()
            {
                GameObject zombieSerca  = null;
                zombieDistance = 5f;
                GameObject WolfMenSerca = null;
                WolfMenDistance = 6f;
                foreach (var Zombie in FindObjectsOfType<Zombie>())
                   {
                        temporalDistan = (Zombie.transform.position - transform.position ).magnitude;

                        if  (temporalDistan <= zombieDistance)
                        {
                          zombieDistance = temporalDistan; 
                          zombieSerca = Zombie.gameObject;

                        }                
                   }
                foreach (var WolfMen in FindObjectsOfType<WolfMen>())
                    {
                        temporalDistan = (WolfMen.transform.position - transform.position).magnitude;
                            if (temporalDistan < WolfMenDistance)
                            {
                                WolfMenDistance = temporalDistan;
                                WolfMenSerca = WolfMen.gameObject;
                            }
                    }

                if (HeroControl.mGameOver == true)
                {
                    if (zombieSerca !=  null)
                    {
                        zombieDistance  = (zombieSerca.transform.position - transform.position ).magnitude;
                        Vector3 zombieDirection = (zombieSerca.transform.position - transform.position).normalized;
                        transform.position -= (zombieDirection * (speed = ((15f * 3f) / Citizen.age)) * Time.deltaTime);
                    }
                    else if (WolfMenSerca != null)
                    {
                        WolfMenDistance = (WolfMenSerca.transform.position - transform.position).magnitude;
                        Vector3 wolfMenDirection = (WolfMenSerca.transform.position - transform.position).normalized;
                        transform.position -= (wolfMenDirection * (speed = ((15f * 3f) / citizen.age))* Time.deltaTime); 
                    }
                        
                    else 
                    {
                        
                        Move();

                    }
                }

            }
            private void OnCollisionEnter(Collision collision)
            {
                if (collision.gameObject.GetComponent<Zombie>() )
                {
                      Zombie z = gameObject.AddComponent<Zombie>(); 
                      z.zombie = (DataZombies)gameObject.GetComponent<Citizen>().citizen;
                      Destroy(gameObject.GetComponent<Citizen>()); 
                     
                      General.p++; 
                }
                if (collision.transform.tag == "paret")
                {
                    speed *= -1;
                }
            }
        }

        public struct sCitizen
        {
            public string name;
            public int age;

            public static explicit operator DataZombies(sCitizen ad)
            {
              DataZombies zd = new DataZombies();
              zd.edad = ad.age;
              return zd;

            }
          
        }


    }
}