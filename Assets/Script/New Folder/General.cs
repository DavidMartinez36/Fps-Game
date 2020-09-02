using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NPC.Ally;
using NPC.Enemy;
public class General : MonoBehaviour
{
    /* variables para generar texto*/
    public static string vida; 
    public Text infAlde; 
    public Text puntosVida;
    public Text mensajeText;
    public Text informacionText;
    public Text posibleHeroe; 
    public Text numeroVillager;
    public Text numeroZombies;
    public Material eresHeroe;
    public Material eresUnFracaso;
    public GameObject machete; 
    public static GameObject hero , paret; 
    public static float veloHero;
    public static int j = 0;// variables para contar los aldeanos y zombies que aparecen en el mapa 
    public static int p = 0;
    public static bool eresUnHeroe = false; 
    const int mMaximo = 25;//variable contante que 
    public readonly int minimumCreat = myRandomcito.Next(5, 16);
    static System.Random myRandomcito = new System.Random();
    /* variables que permiten el uso del audio */
    public AudioClip audioMuerte;
    public AudioClip himnoNacional;
    public AudioClip himnoFRC;
    AudioClip Himno;
    private void Awake()
    {
        veloHero  = Random.Range(5f, 7f);

    }
    void Start()
    {
       
        int mRandom = Random.Range(minimumCreat, mMaximo - 1);
        //se crea el heroe 
        hero = Instantiate(machete,Vector3.zero,Quaternion.identity);
        hero.transform.localScale = new Vector3(1, 1, 1);
        hero.name = "heroe";
        hero.transform.tag = "heroe";
        hero.AddComponent<HeroControl>();
        hero.transform.position = new Vector3(-42f, 0.5f, -44f);
        hero.GetComponent<Rigidbody>().drag = 5;
       
    

        for (int i = 0; i < mRandom-1 ; i++)
       {
           GameObject Cubes  = GameObject.CreatePrimitive(PrimitiveType.Cube);
           Cubes.AddComponent<Rigidbody>();
           Cubes.transform.position = new Vector3(Random.Range(-20, 20), 0.5f, Random.Range(-20, 20));
           int creadorRandom = Random.Range(0,3);  
           switch (creadorRandom)
           {
             case 0: 
                     Cubes.AddComponent<WolfMen>();
                     j++;
              break; 
             case 1:
                     Cubes.AddComponent<Zombie>();
                     p++;
              break;
             case 2: 
                     Cubes.AddComponent<Citizen>();
              break; 

           }

       }        
    }
    void Update()
    {
        numeroZombies.text = " Zombies: "+ p;  
        numeroVillager.text = " Wolf Men: "+ j;
        if (j == 0 && p == 0)
        {
            HeroControl.mGameOver = false;
            mensajeText.text = "WINNER";
        }
        
      
    }
    public void PuntosDeVida(string vida)
    {
      puntosVida.text = vida;
         
    }
    public void ShowMessage(string message)
    {
        mensajeText.text = message;
    }
    public void MostrarMensaje(string myInformacion)
    {
        informacionText.text = myInformacion; 
    }
    public void MostrarInformacion (string myInfAldeano)
    {
       infAlde.text = myInfAldeano;
    }
    public void PlaySoundDead()
    {
       AudioSource.PlayClipAtPoint(audioMuerte,Camera.main.transform.position);
    }
    public void PlaySoundHimno()
    {
        int randomHimno = Random.Range(0, 100);
        if (randomHimno <= 50)
        {
            eresUnHeroe = true; 
            Himno = himnoNacional;
            posibleHeroe.text = "Eres un HEROE NACIONAL!!";
            hero.GetComponent<MeshRenderer>().material = eresHeroe;
        }
        else if(randomHimno >= 50)
        {
            Himno = himnoFRC;
            posibleHeroe.text = "Eres un fracaso";
            hero.GetComponent<MeshRenderer>().material = eresUnFracaso;

        }
        AudioSource.PlayClipAtPoint(Himno, Camera.main.transform.position);
    }
   
   
}


