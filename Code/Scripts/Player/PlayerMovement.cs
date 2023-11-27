using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 touchOrigin;
    private bool touched;
    private Animator anim;
    private SpriteRenderer sp;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        sp = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        HandleTouchInput();
    }

    void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchOrigin = touch.position;
                    touched = true;
                    break;

                case TouchPhase.Ended:
                    touched = false;
                    rb.velocity = Vector2.zero; 
                    SetAnimations(Vector2.zero); 
                    break;
            }

            if (touched)
            {
                Vector2 direction = (touch.position - touchOrigin).normalized;
                MovePlayer(direction);
            }
        }
        else
        {
            touched = false;
            rb.velocity = Vector2.zero; 
            SetAnimations(Vector2.zero);
            anim.SetBool("isMove", false);
            anim.SetFloat("X", 0f);
            anim.SetFloat("Y", 0f);
        }
    }

    void MovePlayer(Vector2 direction)
    {
        rb.velocity = direction * speed;

       
        SetAnimations(direction);
    }

    void SetAnimations(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            anim.SetBool("isMove", true);

            
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                anim.SetFloat("X", direction.x);
                anim.SetFloat("Y", 0f);

                
                if (direction.x > 0)
                {
                    sp.flipX = true;
                }
                else
                {
                    sp.flipX =false;
                }
            }
            else
            {
                anim.SetFloat("X", 0f);
                anim.SetFloat("Y", direction.y);
            }
        }
        else
        {
            anim.SetBool("isMove", false);
        }
    }
}

