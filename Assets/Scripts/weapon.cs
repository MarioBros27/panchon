using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class weapon : MonoBehaviour
{
    public float speed;
    private Rigidbody2D body;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        body.velocity = direction*speed;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void initialize(Vector2 direction){
        this.direction = direction;
    }
    void OnBecameInvisible(){
        Destroy(gameObject);
    }
    
}
