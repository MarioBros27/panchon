using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public int life = 3;
    public Text lifeText;

    void OnTriggerEnter2D(Collider2D other){
         if(other.gameObject.tag == "enemy"){
             Destroy(other.gameObject);
             life -= 1;
             lifeText.text = "" + life;
             if(life <= 0){
                 SceneManager.LoadScene("Start");
             }
         }
     }
}
