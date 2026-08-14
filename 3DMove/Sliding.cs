using UnityEngine;

public class Sliding : MonoBehaviour
{
    [Header(" Reference")]
    
    public Transform oriantatiom;
    public Transform playerObj;
    public Rigidbody rb;
    public PlayerMovement pm;

    [Header("Sliding")]
    public float maxSlideTime;
    public float slideforce;
    public float slideTimer;
   

    public float slideYScale;
    public float startYsacle;

    [Header("Input")]
    public KeyCode slideKey = KeyCode.LeftControl;
    public float horizontalInput;
    public float verticalInput;

    public bool sliding;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<PlayerMovement>();

        startYsacle = playerObj.localScale.y;
    }
    private void FixedUpdate()
    {
        if (pm.sliding)
        {
            SlidingMovement();
        }

    }

    public void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(slideKey) && (horizontalInput != 0 || verticalInput != 0))
        {
            StartSlide();
        }
        
        if (Input.GetKeyUp(slideKey) && pm.sliding) //슬라이딩 중이면서 슬라이드키에서 손을 뗐을 때
        {
            StopSlide();
        }
    }

    public void StartSlide()
    {
        pm.sliding = true;
        playerObj.localScale = new Vector3(playerObj.localScale.x, slideYScale, playerObj.localScale.z); //슬라이딩 시작하면 플레이어의 y축 스케일을 슬라이딩 스케일로 바꿔줌
        rb.AddForce(Vector3.down * 5f, ForceMode.Impulse); //슬라이딩 시작할 때 플레이어가 땅에 붙도록 아래로 힘을 가해줌

        slideTimer = maxSlideTime; //슬라이드 타이머를 최대 슬라이드 시간으로 초기화
        //Debug.Log("슬라이딩 시작");
    }
    public void StopSlide()
    {
        pm.sliding = false;

        playerObj.localScale = new Vector3(playerObj.localScale.x, startYsacle, playerObj.localScale.z); //슬라이딩 멈추면 플레이어의 y축 스케일을 원래대로 바꿔줌
    }
    public void SlidingMovement()
    {          
        
        Vector3 inputDirection = oriantatiom.forward * verticalInput + oriantatiom.right * horizontalInput; //슬라이딩 중에 플레이어가 입력한 방향을 계산
        // sliding normal
        if (!pm.OnSlope() || rb.linearVelocity.y > -0.1f)
        {
            rb.AddForce(inputDirection.normalized * slideforce, ForceMode.Force);
            slideTimer -= Time.deltaTime;
            //Debug.Log("평지에서 슬라이딩 중");
        }
        // slinding down a slope
        else
        {
            rb.AddForce(pm.GetSlopeMoveDirection(inputDirection) * slideforce, ForceMode.Force); //슬로프에서 슬라이딩할 때는 슬로프의 방향으로 힘을 가해줌
            //Debug.Log("슬로프에서 슬라이딩 중");
        }

       
        if (slideTimer <= 0 )
        {
            StopSlide();
        }

    }
}
