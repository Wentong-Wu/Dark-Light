using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    Rigidbody2D rb2d;
    bool isGrounded;

    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    Transform groundCheckL;
    [SerializeField]
    Transform groundCheckR;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
    }

    private void FixedUpdate()
    {
        if(Physics2D.Linecast(transform.position,groundCheck.position, 1 << LayerMask.NameToLayer("/Ground")) || Physics2D.Linecast(transform.position, groundCheckL.position, 1 << LayerMask.NameToLayer("Ground")) || Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Ground")) ||
           Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Platform")) || Physics2D.Linecast(transform.position, groundCheckL.position, 1 << LayerMask.NameToLayer("Platform")) || Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Platform")))
        {
            isGrounded = true;
            animator.SetBool("Ground", true);
        }
        else
        {
            isGrounded = false;
            animator.SetBool("Ground", false);
        }
        if(Input.GetKey("d"))
        {
            rb2d.velocity = new Vector2(2, rb2d.velocity.y);
            rb2d.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (Input.GetKey("a"))
        {
            rb2d.velocity = new Vector2(-2, rb2d.velocity.y);
            rb2d.transform.eulerAngles = new Vector3(0, -180, 0);
        }
        else
        {
            animator.SetFloat("Speed", 0);
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);         
        }

        if(Input.GetKey("space") && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 4);
        }
    }

}
