using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private Vector3 moveVector;
    private CharacterController controller;
    private float speed = 5.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;
    private bool isDead = false;
    public int health;
    private Text label; 
    

    private float animationDuration = 2.0f;
    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        label = GameObject.Find("Health").GetComponent<Text>();
        label.text = " ";
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;

        }
        moveVector = Vector3.zero;
        if (controller.isGrounded)
        {
            verticalVelocity = 0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        //X left Right
        moveVector.x = Input.GetAxis("Horizontal") * speed;
        //Y Up Down
        moveVector.y = verticalVelocity;
        //Z Fwr Bck
        moveVector.z = speed;
        controller.Move(moveVector * Time.deltaTime);
    }
    public void SetSpeed(float z)
    {
        speed = 5.0f + z;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.point.z > transform.position.z + controller.radius)
        {
            health--;
            if(health<=0)
                  Death();
            

            }
        label.text = "Health  : " + health;

    }
    private void Death()
    {
        
     isDead = true;        
    GetComponent<Scoring>().OnDeath();
        
    }
    private void Health()
    {
        health--;
        if (health<=0)
        {
            Death();
        }
        
        
    }
}
