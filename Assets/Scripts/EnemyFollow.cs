﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform targetPlayer;
    public float speed;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
 
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position,targetPlayer.position) >= distance){
        transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);    
        }
        if(transform.position.x< targetPlayer.position.x){
            transform.localScale = new Vector3(-0.8f,0.8f,0.8f);
        }else{
            transform.localScale = new Vector3(0.8f,0.8f,0.8f);
        }
    }

    //When touched by weapon trigger enter GameObject by tag == weapon || weaponright -> decrease life
    //If life is == 0 destroy 
}
