using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class WASDInputController : MonoBehaviour
{
    

    public float speed;

    private Vector2 dir;
    [SerializeField]
    private Animator anim;

    public SpriteRenderer sp;

   
   

    void Start()
    {
        dir = Vector2.zero;
    }

    void Update()
    {
       
        Movement();
        if (dir.x > 0)
        {
            sp.flipX = true;
        }
        else
        {
            sp.flipX = false;
        }
        SetAnimations(dir);
        transform.Translate(dir * speed * Time.deltaTime);
        

    }

    public void Movement()
    {
        dir = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {

            dir += Vector2.up;
        }
        

        if (Input.GetKey(KeyCode.S))
        {
            dir += Vector2.down;
        }

        if (Input.GetKey(KeyCode.D))
        {
            dir += Vector2.right;
        }

        if (Input.GetKey(KeyCode.A))
        {
            dir += Vector2.left;
        }
        
    }

    public void SetAnimations(Vector2 aux)
    {
        if(dir != Vector2.zero)
        {
            anim.SetBool("isMove", true);
        }
        else
        {
            anim.SetBool("isMove", false);
        }
        anim.SetFloat("X",aux.x);
        anim.SetFloat("Y",aux.y);
    }
}
