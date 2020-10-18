using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyLife : MonoBehaviour
{
    private int life;
    private float timeToSelfDestroy = 15;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        life = Random.Range(1,3);
         time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //
        
    }
     void OnTriggerEnter2D(Collider2D other){
         if(other.gameObject.tag == "weapon"){
             life -= 1;
             if(life <= 0){
                 //Stop velocity of the rigidbody of the weapon
                 Destroy(other.gameObject);
                 Destroy(gameObject);
             }
         }
     }
     void FixedUpdate(){
        time += Time.deltaTime;

        if (time >= timeToSelfDestroy)
        {
            Destroy(gameObject);
        }
    }

}
