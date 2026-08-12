using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System;
public class Player : MonoBehaviour
{
    public Rigidbody2D rigid;
    public Collider2D col;

    public Vector2 inputVec;
    public float moveSpeed;
    public float jumpPower;
    public float dashPower;

    public bool onFly = false;
    public bool onSpider = false;
    public bool normal = false;

    public bool canJump= false;
    void Awake()
    {
        col = GetComponent<Collider2D>();   
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * moveSpeed * Time.fixedDeltaTime;
        //rigid.MovePosition(rigid.position + nextVec);
        rigid.linearVelocity = new Vector2(nextVec.x * moveSpeed, rigid.linearVelocityY);
        if(onSpider)
        {

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
    }
    void OnJump()
    {
        if (canJump)
        {
            //transform.position = Vector3.zero;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            canJump = false;
        }
    }

    void OnSprint()
    {
        StartCoroutine(DashCoroutine());
    }

    IEnumerator DashCoroutine()
    {
        //float originalGravity = rigid.gravityScale;
        //rigid.gravityScale = 0;
        Vector2 dashVec = new Vector2(inputVec.x * dashPower, 0);
        rigid.MovePosition(rigid.position + dashVec);

        Debug.Log("Dash!");
        yield return new WaitForSeconds(0.2f);

        //rigid.gravityScale = originalGravity;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }

        if(collision.gameObject.CompareTag("Wall") && onSpider)
        {
            rigid.gravityScale = 0;   
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") && onSpider)
        {
            rigid.gravityScale = 1;
        }
    }

}
