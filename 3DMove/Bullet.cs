using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public int per;
    //public Vector3 aimPos;
    public bool isFlame;
    public WaitForSeconds wait;

    public Rigidbody2D rigid;
    void Awake()
    {
        wait = new WaitForSeconds(0.2f);
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Init(Vector3 dir)
    {
        transform.parent = GameManager.instance.pool.transform;
        //aimPos = GameManager.instance.aim.transform.position;
        rigid.linearVelocity = dir;

        
    }
    IEnumerator FlameCoroutine()
    {
        Debug.Log("d");
        yield return wait;
        gameObject.SetActive(false);
    }
    public void Disapear() //flame 없앨려고 만든함수
    {
        if (isFlame)
        {
            StartCoroutine(FlameCoroutine());
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Area"))
        {
            gameObject.SetActive(false);
        }
    }
}
