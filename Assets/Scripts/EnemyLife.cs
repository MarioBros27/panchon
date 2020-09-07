using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyLife : MonoBehaviour
{
    private int life;
    // Start is called before the first frame update
    void Start()
    {
        life = Random.Range(1,3);
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

}
