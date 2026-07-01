using UnityEngine;
using UnityEngine.EventSystems;
public class Aiming : MonoBehaviour
{
    private Camera cam;
    Vector2 startMousePos;
    Vector2 currentMousePos;
    public SpriteRenderer spriteRenderer;
    public Vector2 dir;
    [Header("body")]
    public bool isBody;
    public bool isHead;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         //Vector2 dir = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition); 
    }
    void Awake()
    {
        cam = Camera.main; //  한 번만 저장
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Aim();
        }
        Aim();
    }

    void Aim()
    {
        dir = cam.ScreenToWorldPoint(Input.mousePosition)- transform.position;
        if (isHead)
        {
            transform.right = dir;

        }
        if (dir.x > 0)
        {
            if (isBody)
            {
                spriteRenderer.flipX = false;
            }
            if (isHead)
            {
                spriteRenderer.flipY = false;
            }

        }
        else
        {
            if (isBody)
            {
                spriteRenderer.flipX = true;
            }
            if (isHead)
            {
                spriteRenderer.flipY = true;
            }
        }
    }
}
