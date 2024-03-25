using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] float topspeed = 5f;
    [SerializeField] float acceleration = 10f;
    [SerializeField] float decceleration = 10f;
    [SerializeField] float velPower = 0.9f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    float moveinput = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        moveinput = Input.GetAxisRaw("Horizontal");
        
    
        animator.SetFloat("ismoving", Mathf.Abs(moveinput));

        if( moveinput > 0f)
        gameObject.transform.localScale = new Vector3(1,1,1);
        if(moveinput < 0f) 
        gameObject.transform.localScale = new Vector3(-1,1,1);
        
    }

    private void FixedUpdate() 
    {
        //calculation of acceleration and decceleration of the character
        float target_speed = moveinput * topspeed;
        float speed_diff = target_speed - rb.velocity.x;

        float accelRate = Mathf.Abs(speed_diff) > 0.01f? acceleration:decceleration;

        float movement = Mathf.Pow(Mathf.Abs(speed_diff) * accelRate, velPower) * Mathf.Sign(speed_diff);

        rb.AddForce(movement * Vector2.right);

    }
}
