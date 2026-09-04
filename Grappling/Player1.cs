using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System;
public class Player1 : MonoBehaviour
{
    public Rigidbody2D rigid;
    public Collider2D col;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Grappling grappling;

    public Vector2 inputVec;
    public float moveSpeed;
    public float jumpPower;
    public float dashPower;
    public bool canJump = true;
    public bool Hookmode;
    public float plusfloat; 
    void Awake()
    {   
        animator = GetComponent<Animator>();    
        col = GetComponent<Collider2D>();
        grappling = GetComponent<Grappling>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * moveSpeed * Time.fixedDeltaTime;
        //rigid.MovePosition(rigid.position + nextVec);
        if (grappling.isAttach) 
        {
            rigid.AddForce(nextVec * moveSpeed* plusfloat*0.1f  , ForceMode2D.Impulse);
        }
        else
        {
            rigid.linearVelocity = new Vector2(nextVec.x * moveSpeed*plusfloat, rigid.linearVelocityY);
        }
        
        
        
    }
    /*void Move()
    {
        float moveX = Input.GetAxis("Horizontal"); // A, D Ű �Է� (-1~1 ����)
        rigid.linearVelocity = new Vector2(moveX * moveSpeed, rigid.linearVelocityY);

    }*/
    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
        if(inputVec.x> 0)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);

        }
        else if(inputVec.x<0)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        }
        else {  animator.SetBool("Run", false);
        }
     }
    void OnJump()
    {
        if (canJump)
        {
            //transform.position = Vector3.zero;
            rigid.AddForce(Vector2.up * jumpPower* 0.01f, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
            canJump = false;
            Debug.Log("Jumped");
        }
        
    }

    void OnDash()
    {
        StartCoroutine(DashCoroutine());
    }

    IEnumerator DashCoroutine()
    {
        //float originalGravity = rigid.gravityScale;
        //rigid.gravityScale = 0;
        Vector2 dashVec = new Vector2(inputVec.x * dashPower, 0);
        rigid.MovePosition(rigid.position + dashVec);



        yield return new WaitForSeconds(0.2f);

        //rigid.gravityScale = originalGravity;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
            animator.SetTrigger("Isground");
            //Debug.Log("Grounded");
        }
    }

}
