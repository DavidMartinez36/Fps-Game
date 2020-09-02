using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Ally;

namespace NPC
{
    namespace Enemy
    {
         sealed class Zombie : Npc
        {
            public  int pointLife = 100;
            Vector3 direction;
            public static Color[] zCol;
            public static string[] zTaste;
            public DataZombies zombie = new DataZombies();
            public Npc myNpc;
             
           
            private void Awake()
            {
              

                zTaste = new string[5]
                {
                    "páncreas ",
                    "cerebro ",
                    "hígados ",
                    "tumores ",
                    "aparatos reproductores "
                };
            }

            void Start()
            {
                gameObject.transform.tag = "zombie"; 
                transform.name = "zombie";
                zombie.taste = Zombie.zTaste[Random.Range(0, 5)];
                gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                StartCoroutine(AzarMoveVar());
                state = State.idle;
                myNpc = GameObject.FindObjectOfType<Npc>();
              
            }


            void Update()
            {
                if (pointLife <= 0)
                {
                  Die();
                }
                    
                GameObject aldeanoSerca  = null;
                float zombieDistance = 5;


                foreach (var citizen in FindObjectsOfType<Citizen>())
                {
                    float temporalDistan = (citizen.transform.position - transform.position ).magnitude;

                    if  (temporalDistan <= zombieDistance)
                    {
                        zombieDistance = temporalDistan; 
                        aldeanoSerca = citizen.gameObject;
                    }                
                }
               
                if (HeroControl.mGameOver == true)
                {
                    if (aldeanoSerca !=  null)
                    {
                        zombieDistance  = (aldeanoSerca.transform.position - transform.position ).magnitude;
                        Vector3 zombieDirection = (aldeanoSerca.transform.position - transform.position).normalized;
                        transform.position += (zombieDirection * 2f * Time.deltaTime);
                    }
                    else if ((General.hero.transform.position - transform.position).magnitude <= 5f )
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
                  pointLife = pointLife - 40; 
              }
              
            }
        }
      


        public struct DataZombies
        {
            
            public string taste;
            public int rota;
            public int edad; 
        }  
        


    }
}