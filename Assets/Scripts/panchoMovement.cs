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
    private bool facingRight = true;
    public Animator animator;

    Vector3 oldPosition = new Vector3(0,0,0);
    void FixedUpdate()
    {
        // if(Input.GetKey(KeyCode.RightArrow))
        Vector3 newPosition = transform.position;
        if(newPosition == oldPosition){
            animator.SetBool("walking", false);
            oldPosition = newPosition;
        }

        if (rightBool == true && leftBool == false)

        {

            moveRight();
            oldPosition = transform.position;
        }
        if (leftBool == true && rightBool == false)
        {

            moveLeft();
            
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            throwWeapon();
        }
    }

    public void throwWeapon()
    {
        if (facingRight)
        {
            GameObject tmp = (GameObject)Instantiate(weapon, transform.position, Quaternion.identity);
            tmp.GetComponent<weapon>().initialize(Vector2.right);
        }
        else
        {
            GameObject tmp = (GameObject)Instantiate(weaponLeft, transform.position, Quaternion.identity);
            tmp.GetComponent<weapon>().initialize(Vector2.left);
        }
    }
    void moveCameraRight(Vector3 desiredPosition)
    {
        // Vector3 smoothedPosition = Vector3.Lerp(cam.position, desiredPosition + offset, moveSpeed*Time.deltaTime);
        Vector3 smoothedPosition = desiredPosition + offset;
        
        cam.position = smoothedPosition;
        background.position = new Vector3(cam.position.x, background.position.y, background.position.z);
    }
    public void moveLeft()
    {
        facingRight = false;
        spriteRenderer.flipX = true;
        if (Mathf.Abs(cam.position.x - transform.position.x) < escapingDistance)
        {
            transform.position += Vector3.right * -moveSpeed * Time.deltaTime;
            oldPosition = transform.position;
            animator.SetBool("walking",true);
        }

    }
    public void moveRight()
    {

        facingRight = true;
        
        Vector3 desiredPosition = Vector3.right * moveSpeed * Time.deltaTime;
        transform.position += desiredPosition;
        oldPosition = transform.position;
        animator.SetBool("walking", true);
        if (transform.position.x - cam.position.x > deltaDistance)
        {
            moveCameraRight(transform.position);
        }

        spriteRenderer.flipX = false;
    }
    public void setRightTrue()
    {
        this.rightBool = true;
    }
    public void setRightFalse()
    {
        this.rightBool = false;
    }
    public void setLeftTrue()
    {
        this.leftBool = true;
    }
    public void setLeftFalse()
    {
        this.leftBool = false;
    }
}
