using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panchoMovement : MonoBehaviour
{
    public float moveSpeed = 0.2f;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     }
    void FixedUpdate(){
        if(Input.GetKey(KeyCode.RightArrow))
              {
                  transform.position += Vector3.right * moveSpeed * Time.deltaTime;
                  spriteRenderer.flipX = false;
              }
              else if(Input.GetKey(KeyCode.LeftArrow))
              {
                  transform.position += Vector3.right * -moveSpeed * Time.deltaTime;
                  spriteRenderer.flipX = true;
              }
    }
}
