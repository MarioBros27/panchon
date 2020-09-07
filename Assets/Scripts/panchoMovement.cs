using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panchoMovement : MonoBehaviour
{
    public float moveSpeed = 0.2f;
    public SpriteRenderer spriteRenderer;
    public GameObject weapon;
    public GameObject weaponLeft;
    public Vector3 offset;
    public Transform cam;
    public float deltaDistance;
    public float escapingDistance;
    public Transform background;
    public bool rightBool = false;
    public bool leftBool = false;
    public Text counter;
    private bool facingRight = true;

    private int distance = 0;

    void FixedUpdate(){
        // if(Input.GetKey(KeyCode.RightArrow))
        if(rightBool == true &&leftBool ==false)

              {
                 
                  moveRight();
              }
        if(leftBool == true && rightBool == false)
              {
                  moveLeft();
              }
        
        if(Input.GetKeyDown(KeyCode.Space)){
            throwWeapon();
        }
    }

    public void throwWeapon(){
        if(facingRight){
            GameObject tmp = (GameObject)Instantiate(weapon, transform.position, Quaternion.identity);
            tmp.GetComponent<weapon>().initialize(Vector2.right);
        }else{
            GameObject tmp = (GameObject)Instantiate(weaponLeft, transform.position, Quaternion.identity);
            tmp.GetComponent<weapon>().initialize(Vector2.left);
        }
    }
    void moveCameraRight(Vector3 desiredPosition){
            // Vector3 smoothedPosition = Vector3.Lerp(cam.position, desiredPosition + offset, moveSpeed*Time.deltaTime);
            Vector3 smoothedPosition =  desiredPosition + offset;
            distance += 1;
            counter.text = ""+distance;
            cam.position = smoothedPosition;
            background.position = new Vector3(cam.position.x, background.position.y, background.position.z);
    }
    public void moveLeft(){
        facingRight = false;
                  spriteRenderer.flipX = true;
                  if(Mathf.Abs(cam.position.x - transform.position.x) < escapingDistance){
                        transform.position += Vector3.right * -moveSpeed * Time.deltaTime;
                  }
               
    }
    public void moveRight(){

        facingRight = true;
        Vector3 desiredPosition = Vector3.right * moveSpeed * Time.deltaTime;
        transform.position += desiredPosition;
        if(transform.position.x - cam.position.x > deltaDistance){
        moveCameraRight(transform.position);
        }
        
        spriteRenderer.flipX = false;
    }
    public void setRightTrue(){
        this.rightBool = true;
    }
    public void setRightFalse(){
        this.rightBool = false;
    }
    public void setLeftTrue(){
        this.leftBool = true;
    }
    public void setLeftFalse(){
        this.leftBool = false;
    }
}
