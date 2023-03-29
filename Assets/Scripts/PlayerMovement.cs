using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;

    private Animator animator;
    
    
    void Start()
    {
        animator = GetComponent<Animator>();
      
    }

    void Update()
    {
        Vector3 direction = new Vector3(
            InputManager.HorisontalAxisRow,
            InputManager.VerticalAxisRow
        ) * (Time.deltaTime * speed);

        if(direction != Vector3.zero)
        {
            transform.position += direction;
            AnimateMovement(direction);
        }
        
        animator.SetBool("Moving", direction != Vector3.zero);
        
        
    }

    void AnimateMovement(Vector3 direction)
    {
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
    }
    
    
}