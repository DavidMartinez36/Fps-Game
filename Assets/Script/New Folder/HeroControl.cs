using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Ally;
using NPC.Enemy;

public class HeroControl : MonoBehaviour
{
    
    public bool colisionBandera = true; 
    public int touch = 0;
    public static int vidaTotal = 100;
    public static bool mGameOver = true; 
    public static Vector3 pos;
    public Color col;
    public readonly float veloHero = General.veloHero;
    GameObject empty;
    public GameObject WolfMenSerca;
    public General myGeneral;
    public Npc myNpc; 
    float zombieDistance;
    float WolfMenDistance; 
    void Start()
    {
        empty = new GameObject();
        empty.name = "Camera";
        empty.AddComponent<Camera>();
        empty.AddComponent<FPSAmi>();
        empty.transform.SetParent(this.transform);
        empty.transform.localPosition = new Vector3(0, 0.5f, 0);
        GetComponent<MeshRenderer>().material.color = col;
        gameObject.AddComponent<HeroMove>();
        gameObject.GetComponent<HeroMove>().mVelo = veloHero;
        myGeneral = GameObject.FindObjectOfType<General>();
    }

    void Update()
    {
         float rata = empty.transform.eulerAngles.y;
         transform.rotation = Quaternion.Euler(0f, rata, 0f);

           GameObject zombieSerca  = null;
           zombieDistance = 6f;
           WolfMenSerca = null;
           WolfMenDistance = 6f;
           
           //forech para detectar a los zombies
            foreach (var Zombie in FindObjectsOfType<Zombie>())
            {
                float temporalDistan = (Zombie.transform.position - transform.position ).magnitude;

                if  (temporalDistan < zombieDistance)
                {
                    zombieDistance = temporalDistan; 
                    zombieSerca = Zombie.gameObject;
                }                
            }
            foreach (var WolfMen in FindObjectsOfType<WolfMen>())
            {
              float temporalDistan = (WolfMen.transform.position - transform.position).magnitude;
                if (temporalDistan < WolfMenDistance)
                {
                    WolfMenDistance = temporalDistan;
                    WolfMenSerca = WolfMen.gameObject;
                }
            }
            if (zombieSerca != null)
            {
                string myInformacion = "Waaaarrrr quiero comer " + zombieSerca.GetComponent<Zombie>().zombie.taste;
                myGeneral.MostrarMensaje(myInformacion);
            }
            else if (WolfMenSerca != null)
            {
               string myMessage = "Soy un hombre lobo, no un golden retriever";
               myGeneral.MostrarMensaje(myMessage);
            }
            else
            {
                myGeneral.MostrarMensaje(""); 
            }

        myGeneral.PuntosDeVida("Vida: " + vidaTotal);


    }
    private void OnCollisionEnter(Collision col)
    {
        if (General.eresUnHeroe == false)
        {

            if (col.transform.tag == "zombie" )
            {
                vidaTotal -= 10;
            }
            if (col.transform.tag == "wolfmen")
            {
                vidaTotal -= 20;
            }
            else if (vidaTotal <= 0)
            {
                mGameOver = false;
                string message = "WASTED";
                myGeneral.ShowMessage(message);
                myGeneral.PlaySoundDead();
            }
        }
        if (col.transform.tag == "tienda")
        {        
                string myInfAldeano = "Mi nombre es Alvaro Uribe, y como no me funciono lo de la politica mejor monte una tienda";
                myGeneral.MostrarInformacion(myInfAldeano);       
          
        }
        if (col.transform.tag == "yurani")
        {
            string myInfAldeano = "Hola mi amor en la esquina hay basuko";
                myGeneral.MostrarInformacion(myInfAldeano); 
        }
         if (col.transform.tag == "lucumi")
        {
            string myInfAldeano = "AJA, Tu que en la esquina hay un machete";
                myGeneral.MostrarInformacion(myInfAldeano); 
        }
        
        if (col.transform.tag == "bandera" && colisionBandera == true)
        {
            myGeneral.PlaySoundHimno();
            colisionBandera = false; 
        }
        if(col.transform.tag == "basuko")
        {
            vidaTotal = vidaTotal + 50;
            
        }
        if (General.eresUnHeroe == true)
        {
            if (col.transform.tag == "zombie")
            {
                General.p--; 
                col.transform.GetComponent<Zombie>().Die();
            }
            if (col.transform.tag == "wolfmen")
            {
                General.j--;
                col.transform.GetComponent<WolfMen>().Die();
            }
        }
    }
}
