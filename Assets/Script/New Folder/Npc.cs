using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Enemy;
using NPC.Ally;
public class Npc : MonoBehaviour
{
   
    public State state;
    public int rotationM = 1;
    public Data zombie = new Data();
    public float speed = 1f;
    public enum State
    {
        idle,
        move
    }
    public IEnumerator AzarMoveVar()
    {    
        for (; ; )
        {
            int myIndex = Random.Range(0, 2);
            state = (State)myIndex;
            yield return new WaitForSeconds(5);
        }
    }
    public void Move()
    {
        switch (state)
        {
            case State.idle:
                //...
                break;
            case State.move:
                transform.position += transform.forward * speed * Time.deltaTime;
                //transform.Rotate(new Vector3(0,Random.Range(-1,1) * Time.deltaTime,0));
                break;
            default:
                break;
        }
    }
    public struct Data
    {
        public Color col;
        public string taste;
        public float rotY;
        public int rota;
       
    }
   
    public void Die ()
    {
        Destroy(this.gameObject); 
    }
}
